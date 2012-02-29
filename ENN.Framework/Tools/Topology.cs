/*This file is part of ENN.
* Copyright (C) 2012  Tim Eck II
* 
* ENN is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as
* published by the Free Software Foundation, version 3 of the License.
* 
* ENN is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Lesser General Public License for more details.
* 
* You should have received a copy of the GNU Lesser General Public License
* along with ENN.  If not, see <http://www.gnu.org/licenses/>.*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using ENN.Framework;

namespace ENN.Framework.Tools
{
    /// <summary>
    /// Static tool class that has functions for manipulating topologies.
    /// </summary>
    public static class Topology
    {
		/// <summary>
		/// Loads a NetwokTopology from either a text file or binary file.
		/// </summary>
		/// <param name="file">The path to the file the contains the
		/// NetworkTopology</param>
		/// <param name="objectFactories">The object factories that will be
		/// used to transform types specified in a text file into objects.
		/// </param>
		/// <param name="settings">The currently loaded NetworkSettings.</param>
		/// <param name="binary">If true a binary file will be loaded, else
		/// a text file will be loaded. By default this is false.</param>
		/// <returns></returns>
		/// <exception cref="IOException">System.IO.IOException</exception>
        public static NetworkTopology Load(
            string file,
            ref Dictionary<string, IUserObjectFactory> objectFactories,
            ref NetworkSettings settings, bool binary = false)
        {
            if (binary)
                return LoadBinary(file);
            return LoadText(file, ref objectFactories, ref settings);
        }

		/// <summary>
		/// Creates a NetworkTopology from a text file.
		/// </summary>
		/// <param name="file">The location of the file to read from.</param>
		/// <param name="objectFactories">The object factories that will
		/// be used to tranform the text types into objects.</param>
		/// <param name="settings">The currently loaded NetworkSettings.</param>
		/// <returns>Returns the NetworkTopology located inside of the file.
		/// If the file can not be parsed null is returned.</returns>
		/// <exception cref="IOException">System.IO.IOException</exception>
        private static NetworkTopology LoadText(
            string file,
            ref Dictionary<string, IUserObjectFactory> objectFactories,
            ref NetworkSettings settings)
        {
			//Check to varify that the file can be loaded.
			if (GetVersion(file) != "1.0") return null;

            NetworkTopology topology = new NetworkTopology();
			//Retrieves the RawTypes from the file
            List<RawType> rawTypes = GetRawTypes(file);

            Dictionary<string, IHiddenLayer> hiddenLayers = new Dictionary<string, IHiddenLayer>();
			//Factory to create the object with
            string factoryName;

			//Transforms all the rawTypes into objects
            for (int i = 0; i < rawTypes.Count; i++)
            {
                factoryName = settings.DefaultFactory;
                if (rawTypes[i].Fields.ContainsKey("factory")) factoryName = rawTypes[i].Fields["factory"];
                if (rawTypes[i].Type == "layer")
                {

                    if (rawTypes[i].Fields["type"] == "hidden")
                    {
                        hiddenLayers.Add(rawTypes[i].Fields["layerName"],
                            objectFactories[factoryName].CreateUserObject<IHiddenLayer>(
                            rawTypes[i].Fields["dataType"],
                            rawTypes[i].Fields));
                    }
                    else if (rawTypes[i].Fields["type"] == "output")
                    {
                        topology.OutputLayer =
                            objectFactories[factoryName].CreateUserObject<IOutputLayer>(
                            rawTypes[i].Fields["dataType"], rawTypes[i].Fields);
                    }
                    else if (rawTypes[i].Fields["type"] == "input")
                    {
                        topology.InputLayer =
                            objectFactories[factoryName].CreateUserObject<IInputLayer>(
                            rawTypes[i].Fields["dataType"], rawTypes[i].Fields);
                    }
                }
                else if (rawTypes[i].Type == "node")
                {
                    INode node = objectFactories[factoryName].CreateUserObject<INode>(
                        rawTypes[i].Fields["dataType"], rawTypes[i].Fields);
                    if (hiddenLayers.ContainsKey(rawTypes[i].Fields["layer"]))
                    {
                        hiddenLayers[rawTypes[i].Fields["layer"]].SetNode(node, -1);
                    }
                }
                else if (rawTypes[i].Type == "preprocessor")
                {
                    topology.PreProcessor =
                        objectFactories[factoryName].CreateUserObject<IPreProcessor>(
                        rawTypes[i].Fields["dataType"], rawTypes[i].Fields);
					if(settings.Mode == NetworkMode.Training)
						topology.TrainingPreProcessor =
							objectFactories[factoryName].CreateUserObject<ITrainingPreProcessor>(
								rawTypes[i].Fields["dataType"], rawTypes[i].Fields);
                }
                else if (rawTypes[i].Type == "postprocessor")
                {
                    topology.PostProcessor = objectFactories[factoryName].
                        CreateUserObject<IPostProcessor>(rawTypes[i].Fields["dataType"], rawTypes[i].Fields);
                }
				else if (rawTypes[i].Type == "topology")
				{
					topology.MetaData = rawTypes[i].Fields;
					if(!rawTypes[i].Fields.ContainsKey("algorithmFactory"))
					{
						rawTypes[i].Fields.Add("algorithmFactory", factoryName);
					}
					topology.TrainingAlgorithm = objectFactories[rawTypes[i].Fields["algorithmFactory"]].
						CreateUserObject<ITrainingAlgorithm>(
							rawTypes[i].Fields["trainingAlgorithm"],
							rawTypes[i].Fields);
				}
            }

			//This tranformation is required because nodes are linked to hidden layers
			//by names. The name of the layer is the key in the dictionary.
            IHiddenLayer[] layer = new IHiddenLayer[hiddenLayers.Count];
            int j = 0;
            foreach (KeyValuePair<string, IHiddenLayer> temp in hiddenLayers)
            {
                layer[j] = temp.Value;
                j++;
            }
            topology.HiddenLayers = layer;
            return topology;
        }

		/// <summary>
		/// Strips out the raw types from the file and prepares them for being parsed
		/// into objects.
		/// </summary>
		/// <param name="file">Location of the file to open.</param>
		/// <returns>Returns a list of raw types found in the file.</returns>
		/// <exception cref="IOException">System.IO.IOException</exception>
        private static List<RawType> GetRawTypes(string file)
        {
            StreamReader fs = File.OpenText(file);

			//Used when triming the end of a line that starts a type
            string newLine = " \t\n{";
            string line;
            string[] splitLine;
            List<RawType> rawTypes = new List<RawType>();
            RawType rawType = new RawType();
            bool openFound = false;
			while (!fs.EndOfStream)
			{
				line = fs.ReadLine();
				line = line.Trim();

				//skip commented or empty lines;
				if (line.StartsWith("#") || line == "") continue;

				//check for the start of a type
				if (!openFound)
				{
					if (line[line.Length - 1] == '{')
					{
						line = line.Trim(newLine.ToCharArray());
						rawType.Type = line;
						openFound = true;
					}
				}
				else if (line[0] == '}')//check for the closing of a type
				{
					openFound = false;
					rawTypes.Add(rawType);
					rawType = new RawType();
				}
				else if (openFound)//addes the fields if a type has be opened
				{
					splitLine = line.Split(':');
					rawType.Fields.Add(splitLine[0].Trim(), splitLine[1].Trim());
				}
				else
				{
					splitLine = line.Split(':');
					splitLine[0] = splitLine[0].Trim();
					splitLine[1] = splitLine[1].Trim();

					//checks to see if there is an include file command
					if (splitLine[0] == "include")
					{
						rawTypes.AddRange(GetRawTypes(splitLine[1]));
					}
				}
			}

            fs.Close();
			return rawTypes;
        }

		/// <summary>
		/// Retrieves the file specification version of the topology file.
		/// </summary>
		/// <param name="file">The file containing the topology.</param>
		/// <returns>Returns the string version number. Example 1.0</returns>
		/// <exception cref="IOException">System.IO.IOException</exception>
		private static string GetVersion(string file)
		{
			StreamReader reader = new StreamReader(file);
			string version = reader.ReadLine();
			reader.Close();

			string[] line = version.Split(':');
			line[0] = line[0].Trim();
			line[1] = line[1].Trim();

			if (line[0] == "version")
				version = line[1];
			else //Some default version that will never pass
				version = "0.0";

			return version;
		}

		/// <summary>
		/// Loads a NetworkTopology from a binary file. Note the the version of the
		/// framework that created the binary must be used to load the file. Only
		/// text files can be used with different framework versions.
		/// </summary>
		/// <param name="file">The location of the file to load the NetworkTopology
		/// from.</param>
		/// <returns>Returns the NetworkTopology found in the file. If the was some
		/// trouble loading the file then null will be returned.</returns>
		/// <exception cref="IOException">System.IO.IOException</exception>
        private static NetworkTopology LoadBinary(string file)
        {
            Stream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            BinaryFormatter binary = new BinaryFormatter();
            Object temp = binary.Deserialize(fs);
            fs.Close();
            return (NetworkTopology)temp;
        }

        /// <summary>
        /// Save a NetworkTopology to file. 
        /// </summary>
        /// <param name="file">Location to save the file.</param>
		/// <param name="topology">The topology to save to file.</param>
		/// <exception cref="IOException">System.IO.IOException</exception>
        public static void Save(string file, NetworkTopology topology, bool binary = false)
        {
            if(binary)
                SaveBinary(file, ref topology);
            else
                SaveText(file, ref topology);
        }

		/// <summary>
		/// Saves a topology to a file in the form of text. Not that the topology must
		/// have its meta data properly set or you will not be able to load the topology
		/// from the text file. The only way that you can garuntee that the file will
		/// save successfully is to have had the topology loaded from a text file at some
		/// point in time in the past.
		/// </summary>
		/// <param name="file">The location of the file</param>
		/// <param name="topology">The NetworkTopology object to persist</param>
		/// <exception cref="IOException">System.IO.IOException</exception>
        private static void SaveText(string file, ref NetworkTopology topology)
        {
            StreamWriter writer = new StreamWriter(file);

			writer.WriteLine("version:1.0");
            writer.WriteLine("#Created on {0}", DateTime.Now);
            writer.WriteLine();

            //Set up topology
            writer.WriteLine("#Topology");
            writer.WriteLine("topology{");
            WriteMeta(ref writer, topology);
            writer.WriteLine("}");
            writer.WriteLine();

            //Add layers
            writer.WriteLine("#Topology Layers");

            //Input
            writer.WriteLine("layer{");
            WriteMeta(ref writer, topology.InputLayer);
            writer.WriteLine("}");
            writer.WriteLine();

            //Output
            writer.WriteLine("layer{");
            WriteMeta(ref writer, topology.OutputLayer);
            writer.WriteLine("}");
            writer.WriteLine();

            //Hidden Layers
            foreach (IHiddenLayer hidden in topology.HiddenLayers)
            {
				writer.WriteLine("layer{");
				WriteMeta(ref writer, hidden);
				writer.WriteLine("}");
				writer.WriteLine();
            }

            //Add pre/post processors
            writer.WriteLine("#Pre and Post processors");

            //Pre
            writer.WriteLine("preprocessor{");
            WriteMeta(ref writer, topology.PreProcessor);
            writer.WriteLine("}");
            writer.WriteLine();

            //Post
            writer.WriteLine("postprocessor{");
            WriteMeta(ref writer, topology.PostProcessor);
            writer.WriteLine("}");
            writer.WriteLine();

            //Add nodes
            writer.WriteLine("#Nodes");
            foreach (IHiddenLayer layer in topology.HiddenLayers)
            {
                foreach (INode node in layer.Nodes)
                {
                    writer.WriteLine("node{");
                    WriteMeta(ref writer, node);
                    writer.WriteLine("}");
                    writer.WriteLine();
                }
            }
			writer.Close();
        }

		/// <summary>
		/// Helper method that writes meta data to disk.
		/// </summary>
		/// <param name="writer">Reference to the StreamWriter that is being used
		/// to write to disk</param>
		/// <param name="metaData">The object whoes meta data should be writen to disk</param>
		/// <exception cref="IOException">System.IO.IOException</exception>
        private static void WriteMeta(ref StreamWriter writer, IMetaData metaData)
        {
            foreach (KeyValuePair<string, string> el in metaData.MetaData)
            {
                writer.WriteLine("\t{0}:{1}", el.Key, el.Value);
            }
        }

		/// <summary>
		/// Saves a topology to file in binary format.
		/// </summary>
		/// <param name="file">Location to save the topology.</param>
		/// <param name="topology">The topology object to persist to disk.</param>
		/// <exception cref="IOException">System.IO.IOException</exception>
        private static void SaveBinary(string file, ref NetworkTopology topology)
        {
            Stream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(fs, topology);
            fs.Close();
        }
    }
}