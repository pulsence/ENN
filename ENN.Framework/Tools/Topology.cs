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
using System.Linq;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using ENN.Framework;

namespace ENN.Framework.Tools
{
    /// <summary>
    /// Static tool class that has functions for manipulating topologies.
    /// </summary>
    static public class Topology
    {
        static public NetworkTopology Load(
            string file,
            ref Dictionary<string, IUserObjectFactory> objectFactory,
            ref NetworkSettings settings,
            bool binary = false)
        {
            if (binary)
                return LoadBinary(file);
            return LoadText(file, ref objectFactory, ref settings);
        }

        static private NetworkTopology LoadText(
            string file,
            ref Dictionary<string, IUserObjectFactory> objectFactory,
            ref NetworkSettings settings)
        {
            NetworkTopology topology = new NetworkTopology();
            List<RawType> rawTypes = GetRawTypes(file);
            Dictionary<string, IHiddenLayer> hiddenLayers = new Dictionary<string, IHiddenLayer>();
            string factoryName;
            for (int i = 0; i < rawTypes.Count; i++)
            {
                factoryName = settings.DefaultFactory;
                if (rawTypes[i].Fields.ContainsKey("factory")) factoryName = rawTypes[i].Fields["factory"];
                if (rawTypes[i].Type == "layer")
                {

                    if (rawTypes[i].Fields["type"] == "hidden")
                    {
                        hiddenLayers.Add(rawTypes[i].Fields["layerName"],
                            objectFactory[factoryName].CreateUserObject<IHiddenLayer>(
                            rawTypes[i].Fields["dataType"],
                            rawTypes[i].Fields));
                    }
                    else if (rawTypes[i].Fields["type"] == "output")
                    {
                        topology.OutputLayer =
                            objectFactory[factoryName].CreateUserObject<IOutputLayer>(
                            rawTypes[i].Fields["dataType"], rawTypes[i].Fields);
                    }
                    else if (rawTypes[i].Fields["type"] == "input")
                    {
                        topology.InputLayer =
                            objectFactory[factoryName].CreateUserObject<IInputLayer>(
                            rawTypes[i].Fields["dataType"], rawTypes[i].Fields);
                    }
                }
                else if (rawTypes[i].Type == "node")
                {
                    INode node = objectFactory[factoryName].CreateUserObject<INode>(
                        rawTypes[i].Fields["dataType"], rawTypes[i].Fields);
                    if (hiddenLayers.ContainsKey(rawTypes[i].Fields["layer"]))
                    {
                        hiddenLayers[rawTypes[i].Fields["layer"]].SetNode(node, -1);
                    }
                }
                else if (rawTypes[i].Type == "preprocessor")
                {
                    topology.PreProcessor =
                        objectFactory[factoryName].CreateUserObject<IPreProcessor>(
                        rawTypes[i].Fields["dataType"], rawTypes[i].Fields);
					if(settings.Mode == NetworkMode.Training)
						topology.TrainingPreProcessor =
							objectFactory[factoryName].CreateUserObject<ITrainingPreProcessor>(
								rawTypes[i].Fields["dataType"], rawTypes[i].Fields);
                }
                else if (rawTypes[i].Type == "postprocessor")
                {
                    topology.PostProcessor = objectFactory[factoryName].
                        CreateUserObject<IPostProcessor>(rawTypes[i].Fields["dataType"], rawTypes[i].Fields);
                }
				else if (rawTypes[i].Type == "topology")
				{
					topology.MetaData = rawTypes[i].Fields;
					topology.TrainingAlgorithm = objectFactory[rawTypes[i].Fields["algorithmFactory"]].
						CreateUserObject<ITrainingAlgorithm>(
							rawTypes[i].Fields["trainingAlgorithm"],
							rawTypes[i].Fields);
				}
            }

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

        static private List<RawType> GetRawTypes(string file)
        {
            StreamReader fs = File.OpenText(file);

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
                if (!line.StartsWith("#") && line != "")
                {
                    if (!openFound)
                    {
                        if (line[line.Length - 1] == '{')
                        {
                            line = line.Trim(newLine.ToCharArray());
                            rawType.Type = line;
                            openFound = true;
                        }
                    }
                    else if (line[0] == '}')
                    {
                        openFound = false;
                        rawTypes.Add(rawType);
                        rawType = new RawType();
                    }
                    else
                    {
                        splitLine = line.Split(':');
                        rawType.Fields.Add(splitLine[0].Trim(), splitLine[1].Trim());
                    }
                }
            }

            fs.Close();
            return rawTypes;
        }

        static private NetworkTopology LoadBinary(string file)
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
        static public void Save(string file, NetworkTopology topology, bool binary = false)
        {
            if(binary)
                SaveBinary(file, ref topology);
            else
                SaveText(file, ref topology);
        }

        static private void SaveText(string file, ref NetworkTopology topology)
        {
            StreamWriter writer = new StreamWriter(file);

            writer.WriteLine("#Created on {0}", DateTime.Now);
            writer.WriteLine();

            //Set up topology
            writer.WriteLine("#Topology");
            writer.WriteLine("topology{");
            PrintMeta(ref writer, topology.MetaData);
            writer.WriteLine("}");
            writer.WriteLine();

            //Add layers
            writer.WriteLine("#Topology Layers");
            //Input
            writer.WriteLine("layer{");
            PrintMeta(ref writer, topology.InputLayer.MetaData);
            writer.WriteLine("}");
            writer.WriteLine();

            //Output
            writer.WriteLine("layer{");
            PrintMeta(ref writer, topology.OutputLayer.MetaData);
            writer.WriteLine("}");
            writer.WriteLine();

            //Hidden Layers
            foreach (IHiddenLayer hidden in topology.HiddenLayers)
            {
				writer.WriteLine("layer{");
				PrintMeta(ref writer, hidden.MetaData);
				writer.WriteLine("}");
				writer.WriteLine();
            }

            //Add pre/post processors
            writer.WriteLine("#Pre and Post processors");
            //Pre
            writer.WriteLine("preprocessor{");
            PrintMeta(ref writer, topology.PreProcessor.MetaData);
            writer.WriteLine("}");
            writer.WriteLine();

            //Post
            writer.WriteLine("postprocessor{");
            PrintMeta(ref writer, topology.PostProcessor.MetaData);
            writer.WriteLine("}");
            writer.WriteLine();

            //Add nodes
            writer.WriteLine("#Nodes");
            foreach (IHiddenLayer layer in topology.HiddenLayers)
            {
                foreach (INode node in layer.Nodes)
                {
                    writer.WriteLine("node{");
                    PrintMeta(ref writer, node.MetaData);
                    writer.WriteLine("}");
                    writer.WriteLine();
                }
            }
			writer.Close();
        }

        static private void PrintMeta(ref StreamWriter writer, Dictionary<string, string> meta)
        {
            foreach (KeyValuePair<string, string> el in meta)
            {
                writer.WriteLine("\t{0}:{1}", el.Key, el.Value);
            }
        }

        static private void SaveBinary(string file, ref NetworkTopology topology)
        {
            Stream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(fs, topology);
            fs.Close();
        }
    }
}
