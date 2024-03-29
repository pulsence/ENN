﻿/*This file is part of ENN.
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
using System.Diagnostics;
using System.IO;
using System.Threading;
using ENN.Framework;

namespace ENN.Runtime
{
	/// <summary>
	/// Handles responce to specific commands.
	/// </summary>
    partial class Program
    {
		/// <summary>
		/// The default respond if the base command is not recognized.
		/// </summary>
        private static void DefaultHandler()
        {
            Console.WriteLine("You have not placed a valid command. Please try again.");
            Console.WriteLine("If you are not sure what command to use, enter the help " +
                "command, -h");
        }

		/// <summary>
		/// Handles the running and testing of neural networks.
		/// </summary>
		/// <param name="commands"></param>
		private static void RunHandler(List<RawCommand> commands)
        {
            NetworkTopology topology = new NetworkTopology();

			string name = "";
			bool test = false;

			foreach(RawCommand command in commands)
			{
				if(command.CommandChar == 't')
				{
					test = true;
				}
				else if(command.CommandChar == 'n')
				{
					name = command.Value;
				}
			}

			if (name == "")
            {
				Console.WriteLine("Could not process request becuase no name was set");
				return;
            }

			if (topologies.ContainsKey(name))
			{
				topology = topologies[name];
			}
			else
			{
				Console.WriteLine("No topology by the name {0} is loaded", name);
				return;
			}

            if (test)
            {
				//tests to see is the specified topology is ready to be used.

                if (topology.HiddenLayers == null ||
                    topology.InputLayer == null ||
                    topology.OutputLayer == null ||
                    topology.PostProcessor == null ||
                    topology.PreProcessor == null)
                {
                    Console.WriteLine(
                        "The network is not ready to run because the" +
                        "topology is not completely loaded");
                    return;
                }

                bool error = false;
                int i = 0;
                int j = 0;
                INode[] nodes;
                while(i < topology.HiddenLayers.Length && error == false)
                {
                    nodes = topology.HiddenLayers[i].Nodes;
                    while (j < nodes.Length && error == false)
                    {
                        error = nodes[j] == null;
                        j++;
                    }
                    i++;
                }

                if (error)
                {
                    Console.WriteLine("The network is not ready to run");
                    Console.WriteLine("In layer number {0}, node {1} is null", --i, --j);
                    return;
                }
                
                Console.WriteLine("The network is ready to run");
            }
            else
            {
				//runs the specified topology
                Console.WriteLine("The network is starting...");
                NeuralNetwork network = new NeuralNetwork(topology, settings);
                ThreadPool.QueueUserWorkItem(network.StartNetwork);
                Console.WriteLine("The network was started");
            }
        }

		/// <summary>
		/// Outputs the current status and information about the system.
		/// </summary>
		/// <param name="commands">Details of what type of information
		/// should be outputed.</param>
		private static void StatusHandler(List<RawCommand> commands)
        {
            if (commands.Count > 1)
            {
                for (int i = 1; i < commands.Count; i++)
                {
                    if (commands[i].CommandChar == 's')
                    {
                        Console.WriteLine();
                        Console.WriteLine("Current settings:");
                        Console.WriteLine(settings.ToString());
                    }
                    else if (commands[i].CommandChar == 't')
                    {
                        Console.WriteLine();
                        Console.WriteLine("Current Topologies:");
                        foreach (KeyValuePair<string, NetworkTopology> key in topologies)
                        {
                            Console.WriteLine("{0}:", key.Key);
                            Console.WriteLine(key.Value);
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

		/// <summary>
		/// Reads a scripts file and the runs the scripts. Scripts are just
		/// text file with command line commands on individual lines.
		/// </summary>
		/// <param name="commands">Information about the scripts</param>
		private static void CommandScriptHandler(List<RawCommand> commands)
        {
            if (commands[1].CommandChar == 'f')
            {
                try
                {
                    StreamReader fs = File.OpenText(commands[1].Value);
                    Command command;
					string line;
                    do
                    {
						line = fs.ReadLine();
						Console.WriteLine(line);
                        command = RetrieveCommand(line);
                        ProcessCommand(command);
                    } while (command.BaseType != CommandType.Exit && !fs.EndOfStream);
                    fs.Close();
                    if (command.BaseType == CommandType.Exit)
                    {
                        Environment.Exit(Environment.ExitCode);
                    }
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("File: {0} could not be found", commands[1].Value);
                }
                catch (DirectoryNotFoundException ex)
                {
                    Console.WriteLine("File: {0} could not be found", commands[1].Value);
                }
            }
        }

		/// <summary>
		/// Launchs packaged gui applications from the command line.
		/// </summary>
		/// <param name="commands">The applications to launch.</param>
		private static void AppLauncherHandler(List<RawCommand> commands)
        {
            try
            {
                if (commands[1].CommandChar == 's')
                {
                    Process.Start("SettingsBuilder.exe");
                }
                else if (commands[1].CommandChar == 't')
                {
                    Process.Start("TopologyBuilder.exe");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error launching the application.");
                Console.WriteLine("Please make sure that it exists and try again.");
            }
        }

		/// <summary>
		/// Displays help on a all the valid commands that can be entered from
		/// the command line based up the commands passed to the function.
		/// </summary>
		/// <param name="commands">Determines what help information is displayed.</param>
		private static void HelpHandler(List<RawCommand> commands)
        {
            if (commands.Count < 2)
            {
                Console.WriteLine(Help.intro);
            }
            else if (commands[1].CommandChar == 'r')
            {
                Console.WriteLine("This commands runs the network that has been loaded");
                Console.WriteLine("Expects an -n argument which specifies the name to run");
                Console.WriteLine("There is one command that can be passed, -t. The -t "+
                    "command runs a test to check if the network is loaded correctly");
            }
            else if (commands[1].CommandChar == 'l')
            {
                Console.WriteLine(Help.load);
            }
            else if (commands[1].CommandChar == 'u')
            {
				Console.WriteLine(Help.update);
            }
            else if (commands[1].CommandChar == 's')
            {
				Console.WriteLine(Help.save);
            }
            else if (commands[1].CommandChar == 'i')
            {
                Console.WriteLine("This command displays information about the software");
                Console.WriteLine("This command takes no parameters");
            }
            else if (commands[1].CommandChar == 'e')
            {
                Console.WriteLine(
                    "This command takes no parameters and immidiatly stops the program");
            }
            else if (commands[1].CommandChar == 'c')
            {
				Console.WriteLine(Help.command);
            }
            else if (commands[1].CommandChar == 'a')
            {
				Console.WriteLine(Help.application);
            }
            else
            {
                Console.WriteLine("The " + commands[1].CommandChar +
                    " is not one of the accepted commands");
				Console.WriteLine(Help.intro);
            }
        }
    }
}