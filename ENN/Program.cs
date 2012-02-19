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
using ENN.Framework;

namespace ENN.Runtime
{
	/// <summary>
	/// Main entry class for the runtime.
	/// </summary>
    partial class Program
    {
        static NetworkSettings settings;
        static Dictionary<string, NetworkTopology> topologies;

        static LoadTool loadTool;
        static UpdateTool updateTool;
        static SaveTool saveTool;

        static Dictionary<string, IUserObjectFactory> objectFactory;

        static void Main(string[] args)
        {
			//variable set up
            settings = new NetworkSettings();
            topologies = new Dictionary<string, NetworkTopology>();

            objectFactory = new Dictionary<string, IUserObjectFactory>();
            objectFactory.Add("standard", new StandLibFactory());

            loadTool = new LoadTool(ref settings, ref topologies, ref objectFactory);
            updateTool = new UpdateTool(ref settings, ref topologies);
            saveTool = new SaveTool(ref settings, ref topologies);

			//start up display information
            Console.WriteLine("ENN  Copyright (C) 2012  Tim Eck II");
            Console.WriteLine("This program comes with ABSOLUTELY NO WARRANTY.");
            Console.WriteLine("This is free software, and you are welcome to redistribute it");
            Console.WriteLine(
                "under certain conditions; which can be found in the COPYING.LESSER.txt file");
            Console.WriteLine("that was provided with the program.\n");
            Console.WriteLine(
                "The ENN runtime has been succesfully started. You may now enter commands");
            Console.WriteLine("If you are not sure where to start enter -h.");
            
			//command line processing loop
            Command command = RetrieveCommand(Console.ReadLine());
            while (command.BaseType != CommandType.Exit)
            {
                ProcessCommand(command);
                command = RetrieveCommand(Console.ReadLine());
            }
        }

		/// <summary>
		/// Creates a Command object from a line of text. This is usualy the next line from
		/// the command line.
		/// </summary>
		/// <param name="raw">The raw unprocessed string that contains the
		/// command line commands</param>
		/// <returns></returns>
        static private Command RetrieveCommand(string raw)
        {
            string[] split = raw.Split(' ');
            List<RawCommand> rawCommands = new List<RawCommand>();
			//Creates a list of raw commands
            for (int i = 0; i < split.Length; i++)
            {
                if (split[i][0] == '-' && split[i].Length > 1)
                {
                    RawCommand tempCommand = new RawCommand();
                    tempCommand.CommandChar = split[i][1];
                    rawCommands.Add(tempCommand);
                }
                else if(rawCommands.Count > 0)
                {
                    if (rawCommands[rawCommands.Count - 1].Value == "")
                    {
                        rawCommands[rawCommands.Count - 1].Value = split[i];
                    }
                    else
                    {
                        rawCommands[rawCommands.Count - 1].Value =
                            rawCommands[rawCommands.Count - 1].Value + " " + split[i];
                    }
                }
            }

            Command command = new Command();
			//maps the first command to the proper root command
            if (rawCommands.Count == 0)
            {
                command.BaseType = CommandType.Bad;
            }
            else if (rawCommands[0].CommandChar == 'h')
            {
                command.BaseType = CommandType.Help;
            }
            else if (rawCommands[0].CommandChar == 'r')
            {
                command.BaseType = CommandType.Run;
            }
            else if (rawCommands[0].CommandChar == 'l')
            {
                command.BaseType = CommandType.Load;
            }
            else if (rawCommands[0].CommandChar == 's')
            {
                command.BaseType = CommandType.Save;
            }
            else if (rawCommands[0].CommandChar == 'u')
            {
                command.BaseType = CommandType.Update;
            }
            else if (rawCommands[0].CommandChar == 'i')
            {
                command.BaseType = CommandType.Status;
            }
            else if (rawCommands[0].CommandChar == 'c')
            {
                command.BaseType = CommandType.Command;
            }
            else if (rawCommands[0].CommandChar == 'a')
            {
                command.BaseType = CommandType.App;
            }
            else if (rawCommands[0].CommandChar == 'e')
            {
                command.BaseType = CommandType.Exit;
            }
            else command.BaseType = CommandType.Bad;

            command.RawCommands = rawCommands;
            return command;
        }

		/// <summary>
		/// Process the command by the base command type. Calls the methods
		/// that are capable to responding to a particular base command.
		/// </summary>
		/// <param name="command">The command to process.</param>
        static private void ProcessCommand(Command command)
        {
            switch (command.BaseType)
            {
                case CommandType.Load:
                    loadTool.RunCommand(command.RawCommands);
                    break;
                case CommandType.Run:
                    RunHandler(command.RawCommands);
                    break;
                case CommandType.Save:
                    saveTool.RunCommand(command.RawCommands);
                    break;
                case CommandType.Status:
                    StatusHandler(command.RawCommands);
                    break;
                case CommandType.Update:
                    updateTool.RunCommand(command.RawCommands);
                    break;
                case CommandType.Help:
                    HelpHandler(command.RawCommands);
                    break;
                case CommandType.Command:
                    CommandScriptHandler(command.RawCommands);
                    break;
                case CommandType.App:
                    AppLauncherHandler(command.RawCommands);
                    break;
                case CommandType.Bad:
                default:
                    DefaultHandler();
                    break;
            }

        }
    }
}
