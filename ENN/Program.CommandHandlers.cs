using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Threading;
using ENN.Framework;

namespace ENN.Runtime
{
    partial class Program
    {
        static void DefaultHandler()
        {
            Console.WriteLine("You have not placed a valid command. Please try again.");
            Console.WriteLine("If you are not sure what command to use, enter the help " +
                "command, -h");
        }

        static void RunHandler(List<RawCommand> commands)
        {
            if (commands.Count > 1 && commands[1].CommandChar == 't')
            {
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
                    nodes = topology.HiddenLayers[i].GetNodes();
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
                Console.WriteLine("The network is starting...");
                NeuralNetwork network = new NeuralNetwork(topology, settings);
                ThreadPool.QueueUserWorkItem(network.StartNetwork);
                Console.WriteLine("The network was started");
            }
        }

        static void StatusHandler(List<RawCommand> commands)
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
                        Console.WriteLine("Current Topology:");
                        Console.WriteLine(topology.ToString());
                    }
                }
            }
        }

        static void CommandScriptHandler(List<RawCommand> commands)
        {
            if (commands[1].CommandChar == 'f')
            {
                try
                {
                    StreamReader fs = File.OpenText(commands[1].Value);
                    Command command;
                    do
                    {
                        command = RetrieveCommand(fs.ReadLine());
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

        static void AppLauncherHandler(List<RawCommand> commands)
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

        static void HelpHandler(List<RawCommand> commands)
        {
            if (commands.Count < 2)
            {
                printToCommand(File.ReadAllLines("Help\\Intro.txt"));
            }
            else if (commands[1].CommandChar == 'r')
            {
                Console.WriteLine("This commands runs the network that has been loaded");
                Console.WriteLine("There is one command that can be passed, -t. The -t "+
                    "command runs a test to check if the network is loaded correctly");
            }
            else if (commands[1].CommandChar == 'l')
            {
                printToCommand(File.ReadAllLines("Help\\Load.txt"));
            }
            else if (commands[1].CommandChar == 'u')
            {
                printToCommand(File.ReadAllLines("Help\\Update.txt"));
            }
            else if (commands[1].CommandChar == 's')
            {
                printToCommand(File.ReadAllLines("Help\\Save.txt."));
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
                printToCommand(File.ReadAllLines("Help\\Command.txt"));
            }
            else if (commands[1].CommandChar == 'a')
            {
                printToCommand(File.ReadAllLines("Help\\Application.txt"));
            }
            else
            {
                Console.WriteLine("The " + commands[1].CommandChar +
                    " is not one of the accepted commands");
                printToCommand(File.ReadAllLines("Help\\Intro.txt"));
            }
        }

        static void printToCommand(string[] strings)
        {
            foreach (string s in strings)
            {
                Console.WriteLine(s);
            }
        }
    }
}