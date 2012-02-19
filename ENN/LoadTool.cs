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
            if (commands.Count < 2)
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
            try
            {
                NetworkTopology topology = Topology.Load(commands[2].Value, ref objectFactory, ref settings);
                if (topologies.ContainsKey(topology.MetaData["name"]))
                {
                    topologies[topology.MetaData["name"]] = topology;
                }
                else
                {
                    topologies.Add(topology.MetaData["name"], topology);
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
            try
            {
                settings = Settings.Load(commands[2].Value);
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
            Assembly assembly = Assembly.LoadFrom(settings.UserBinaryLocation);
            IUserObjectFactory factory =
                (IUserObjectFactory)assembly.CreateInstance(settings.UserBinaryClassName);
            if (objectFactory == null) Console.WriteLine("The binary was not loaded successfully");
            else
            {
                if (objectFactory.ContainsKey(settings.UserBinaryName))
                {
                    objectFactory[settings.UserBinaryName] = factory;
                }
                else
                {
                    objectFactory.Add(settings.UserBinaryName, factory);
                }
            }
            Console.WriteLine("Finished");
        }
    }
}