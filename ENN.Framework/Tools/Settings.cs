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
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using ENN.Framework;

namespace ENN.Framework.Tools
{
    /// <summary>
    /// Static class that contains method that are helpful in manipulating NetworkSettings.
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Loads NetworkSettings from a file. Can load either text or binary representations.
        /// In addition in text mode, older file versions can be used loaded. Note no exceptions
        /// are caught by this method you will need to do this your self.
        /// </summary>
        /// <param name="filePath">The full path to the file.</param>
        /// <param name="binary">Detirmines if a binary file or text file will be used to create
        /// the NetworkSettings. True means the file is a binary file.</param>
        /// <returns>Returns the NetworkSettings found in the file specified. If the object
		/// could not be successfully loaded a null value is returned.</returns>
		/// <exception cref="IOException">System.IO.IOException</exception>
        public static NetworkSettings Load(string filePath, bool binary = false)
        {
            if (binary)
                return LoadBinary(filePath);
            return LoadText(filePath);
        }

		/// <summary>
		/// Loads NetworkSettings from a text file. Determines the settings version to load.
		/// </summary>
		/// <param name="filePath">The file path to the settings file.</param>
		/// <returns>Returns the NetworkSettings that were loaded from the file. Returns null
		/// if the file could no be parsed.</returns>
		/// <exception cref="IOException">System.IO.IOException</exception>
        private static NetworkSettings LoadText(string filePath)
        {
            NetworkSettings settings = new NetworkSettings();

			//strips the key-value pairs out of the text file
            Dictionary<string, string> raw = rawText(filePath);
            if (raw.Count == 0) return null;

			//if know version was specified then the latest file version is specified
            if (!raw.ContainsKey("version")) raw.Add("version", "1.0");
            if (raw["version"] != "1.0") return null;
			raw.Remove("version");
			//parses the key-value pairs by maping the key to the proper settings field
            foreach (KeyValuePair<string, string> key in raw)
            {
                switch (key.Key)
                {
                    case "networkmode":
                        if (key.Value == "training")
                        {
                            settings.Mode = NetworkMode.Training;
                        }
                        else
                        {
                            settings.Mode = NetworkMode.Computational;
                        }
                        break;
                    case "networktype":
                        if (key.Value == "traditional")
                        {
                            settings.NetworkType = NetworkType.Traditional;
                        }
                        else
                        {
                            settings.NetworkType = NetworkType.Evolving;
                        }
                        break;
                    case "inputlayer":
                        settings.DefaultInputLayer = key.Value;
                        break;
                    case "node":
                        settings.DefaultNode = key.Value;
                        break;
                    case "nodelayer":
                        settings.DefaultHiddenLayer = key.Value;
                        break;
                    case "outputlayer":
                        settings.DefaultOutputLayer = key.Value;
                        break;
                    case "factory":
                        settings.DefaultFactory = key.Value;
                        break;
                    case "enabletiming":
                        settings.EnableTiming = (key.Value.ToLower() == "true");
                        break;
                    case "trainingaccuracy":
                        float trainAccuracy = 0;
                        float.TryParse(key.Value, out trainAccuracy);
                        settings.TrainingAccuracy = trainAccuracy;
                        break;
                    case "trainingiterations":
                        int iterations = 0;
                        int.TryParse(key.Value, out iterations);
                        settings.TrainingIterations = iterations;
                        break;
                    case "trainingpool":
                        int pool = 0;
                        int.TryParse(key.Value, out pool);
                        settings.TraininPool = pool;
                        break;
                    default:
						//if no field is found to place the value into then it is
 						//added to the catch-all Other field
                        settings.Other.Add(key.Key, key.Value);
                        break;
                }
            }
            return settings;
        }

		/// <summary>
		/// Loads network settings from a binary file.
		/// </summary>
		/// <param name="filePath">Location of the file.</param>
		/// <returns>Returns the NetworkSettings found in the file. If there was an something
		/// wrong with reading the file null will be returned.</returns>
		/// <exception cref="IOException">System.IO.IOException</exception>
        private static NetworkSettings LoadBinary(string filePath)
        {
            Stream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryFormatter binary = new BinaryFormatter();
            Object temp = binary.Deserialize(fs);
            fs.Close();
            return (NetworkSettings)temp;
        }

		/// <summary>
		/// Saves a NetworkSettings object to file. The object can be saved to either a binary
		/// file or text file.
		/// </summary>
		/// <param name="settings">The object to save to file.</param>
		/// <param name="filePath">The location to save the file.</param>
		/// <param name="binary">If true a binary file will be created. Else a text file will
		/// be generated. By default this parameter is false.</param>
		/// <exception cref="IOException">System.IO.IOException</exception>
        public static void Save(NetworkSettings settings, string filePath, bool binary = false)
        {
            if (binary)
                SaveBinary(ref settings, filePath);
            else
                SaveText(ref settings, filePath);
        }

		/// <summary>
		/// Saves the NetworkSettings object to a text file.
		/// </summary>
		/// <param name="settings">The NetworkSettings object to save to disk.</param>
		/// <param name="filePath">The location to save the file to.</param>
		/// <exception cref="IOException">System.IO.IOException</exception>
        private static void SaveText(ref NetworkSettings settings, string filePath)
        {
            StreamWriter writer = new StreamWriter(filePath);
			writer.WriteLine("version:1.0\n");
            writer.WriteLine("networkmode:{0}", settings.Mode);
			writer.WriteLine("networktype:{0}", settings.NetworkType);
            writer.WriteLine("\n#User Defined Binary settings");
            writer.WriteLine("\n#Default data types");
			writer.WriteLine("inputlayer:{0}", settings.DefaultInputLayer);
			writer.WriteLine("node:{0}", settings.DefaultNode);
			writer.WriteLine("nodelayer:{0}", settings.DefaultHiddenLayer);
			writer.WriteLine("outputlayer:{0}", settings.DefaultOutputLayer);
			writer.WriteLine("factory:{0}", settings.DefaultFactory);
            writer.WriteLine("\n#Debugging");
			writer.WriteLine("enabletiming:{0}", settings.EnableTiming);
            writer.WriteLine("\nTraining Settings");
			writer.WriteLine("trainingiterations:{0}", settings.TrainingIterations);
			writer.WriteLine("trainingaccuracy:{0}", settings.TrainingAccuracy);
			writer.WriteLine("trainingpool:{0}", settings.TraininPool);
            writer.WriteLine("\n#User Defined Settings");
			//Writes all the key-value pairs that couldn't be matched to a settings
			//field to disk.
            foreach (KeyValuePair<string, string> key in settings.Other)
            {
                writer.WriteLine("{0}:{1}", key.Key, key.Value);
            }
            writer.Close();
        }

		/// <summary>
		/// Save the NetworkSettings object to a binary file.
		/// </summary>
		/// <param name="settings">The NetworkSettings object that will be saved to
		/// disk in a binary file.</param>
		/// <param name="filePath">The location to save the file.</param>
		/// <exception cref="IOException">System.IO.IOException</exception>
        private static void SaveBinary(ref NetworkSettings settings, string filePath)
        {
            Stream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(fs, settings);
            fs.Close();
        }

		/// <summary>
		/// Strips the key-value pairs out of the file.
		/// </summary>
		/// <param name="filePath">The text file to search</param>
		/// <returns>Returns a dictionary of key-value pairs found inside of
		/// the file</returns>
		/// <exception cref="IOException">System.IO.IOException</exception>
        private static Dictionary<string, string> rawText(string filePath)
        {
            Dictionary<string, string> raw = new Dictionary<string, string>();
            StreamReader reader = new StreamReader(filePath);
            string line;
            string[] pieces;
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                if (line == "" || line[0] == '#') continue;

                pieces = line.Split(':');
                if (pieces.Length != 2) continue;

                pieces[0] = pieces[0].Trim();
                pieces[1] = pieces[1].Trim();

                if (!raw.ContainsKey(pieces[0]))
                {
                    raw.Add(pieces[0], pieces[1]);
                }
            }
			reader.Close();
            return raw;
        }
    }
}