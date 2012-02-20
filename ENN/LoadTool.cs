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
using System.Reflection;
using ENN.Framework;
using ENN.Framework.Tools;

namespace ENN.Runtime
{
    class LoadTool
    {
        NetworkSettings settings;
        Dictionary<string, NetworkTopology> topologies;
        Dictionary<string, IUserObjectFactory> objectFactory;

        public LoadTool(ref NetworkSettings settings,
            ref Dictionary<string, NetworkTopology> topologies,
            ref Dictionary<string, IUserObjectFactory> objectFactory)
        {
            this.settings = settings;
            this.topologies = topologies;
            this.objectFactory = objectFactory;
        }

		/// <summary>
		/// Executes some command based upon the parameters passed.
		/// </summary>
		/// <param name="commands">Used to determine the sub-commands that
		/// can be executed.</param>
        public void RunCommand(List<RawCommand> commands)
        {
            if (commands.Count == 1)
            {
                Console.WriteLine(
                    "This tool allows you to load settings, topolgy, and user binary from a file");
                Console.WriteLine("To learn more about how to use this tool type the command -h -l");
            }
            else if (commands[1].CommandChar == 't')
            {
                TopologyHandler(commands);
            }
            else if (commands[1].CommandChar == 's')
            {
                SettingsHandler(commands);
            }
            else if (commands[1].CommandChar == 'b')
            {
                BinaryHandler(commands);
            }
            else
            {
                Console.WriteLine("Command passed is not recognized.");
                Console.WriteLine("To learn about the recognized commands type -h -l");
            }
        }

		/// <summary>
		/// Loads a topology from a file.
		/// </summary>
		/// <param name="commands">Commands used to customize the behavior of the
		/// command</param>
        void TopologyHandler(List<RawCommand> commands)
        {
            Console.WriteLine("Loading topology...");
			if (commands[2].CommandChar != 'f')
			{
				Console.WriteLine("Topology could not be loaded");
				Console.WriteLine("No file was specified");
				return;
			}

            try
            {
				bool binary = false;
				string name = "";

				for (int i = 3; i < commands.Count; i++)
				{
					if (commands[i].CommandChar == 'b')
					{
						binary = true;
					}
					else if (commands[i].CommandChar == 'n')
					{
						name = commands[i].Value;
					}
				}

				if(!binary)
				{
					binary = commands[2].Value.EndsWith("nntc", true, null);
				}

                NetworkTopology topology = Topology.Load(commands[2].Value,
					ref objectFactory, ref settings, binary);

				if (name == "")
				{
					if (topology.MetaData.ContainsKey("name"))
					{
						name = topology.MetaData["name"];
					}
					else
					{
						int i = 0;
						bool topologyAdded = false;
						while (!topologyAdded)
						{
							if (!topologies.ContainsKey("topology" + i))
							{
								name = "topolog" + i;
								topologyAdded = true;
							}
						}
					}
				}


				if (topologies.ContainsKey(name))
				{
					topologies[name] = topology;
				}
				else
				{
					topologies.Add(name, topology);
				}
                Console.WriteLine("Finished loading.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Topology could not be loaded");
                Console.WriteLine("There was an error with the file");
                #if(DEBUG)
                Console.WriteLine("Message: {0}\nSource: {1}", ex.Message, ex.Source);
                #endif
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Topology could not be loaded");
                Console.WriteLine("There was an error parsing the file");
                #if(DEBUG)
                Console.WriteLine("Message: {0}\nSource: {1}", ex.Message, ex.Source);
              #endif
            }
        }

		/// <summary>
		/// Loads settings from a file.
		/// </summary>
		/// <param name="commands">Commands used to customize the behavior of the
		/// command</param>
        void SettingsHandler(List<RawCommand> commands)
        {
			Console.WriteLine("Loading settings...");
			if (commands[2].CommandChar != 'f')
			{
				Console.WriteLine("Settings could not be loaded");
				Console.WriteLine("No file was specified");
				return;
			}

            try
            {
				bool binary = false;
				if (commands.Count > 3)
				{
					if (commands[3].CommandChar == 'b')
					{
						binary = true;
					}
					else
					{
						binary = commands[2].Value.EndsWith("nnsc", true, null);
					}
				}

                settings = Settings.Load(commands[2].Value, binary);
                Console.WriteLine("Loading has finished");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Settings could not be loaded");
                Console.WriteLine("There was an error loading the file");
                #if(DEBUG)
                Console.WriteLine("Message: {0}\nSource: {1}", ex.Message, ex.Source);
                #endif

            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Settings could not be loaded");
                Console.WriteLine("There was an error in the file file formatting.");
                #if(DEBUG)
                Console.WriteLine("Message: {0}\nSource: {1}", ex.Message, ex.Source);
                #endif
            }
        }

		/// <summary>
		/// Loads a user binary file from disk.
		/// </summary>
		/// <param name="commands">Commands used to customize the behavior of the
		/// command</param>
        void BinaryHandler(List<RawCommand> commands)
        {
			Console.WriteLine("Loading binary...");
			if (commands[2].CommandChar != 'f')
			{
				Console.WriteLine("User binary could not be loaded");
				Console.WriteLine("No file was specified");
				return;
			}

			try
			{
				string name = "";
				if (commands.Count > 3)
				{
					if (commands[3].CommandChar == 'n')
					{
						name = commands[3].Value;
					}
				}

				Assembly assembly = Assembly.LoadFrom(commands[2].Value);
				IUserObjectFactory factory = null;
					//(IUserObjectFactory)assembly.CreateInstance("IUserObjectFactory");

				foreach (Type type in assembly.GetTypes())
				{
					if (type.GetInterface("IUserObjectFactory") != null)
					{
						factory = (IUserObjectFactory)Activator.CreateInstance(type);
						if (name == "")
						{
							name = type.Name;
						}
						break;
					}
				}

				if (factory == null)
				{
					Console.WriteLine("The binary was not loaded successfully.");
					return;
				}
				else
				{
					if (objectFactory.ContainsKey(name))
					{
						objectFactory[name] = factory;
					}
					else
					{
						objectFactory.Add(name, factory);
					}
				}
				Console.WriteLine("Finished loading the binary.");
			}
			catch(Exception ex)
			{
				Console.WriteLine("The user binary file could not be loaded.");
				Console.WriteLine("There was an error reading the file");
			}
        }
    }
}