using System;
using System.Collections.Generic;
using System.Diagnostics;
using ENN.Framework;

namespace ENN.Runtime
{
    partial class Program
    {
        static NetworkSettings settings;
        static NetworkTopology topology;

        static LoadTool loadTool;
        static UpdateTool updateTool;
        static SaveTool saveTool;

        static Dictionary<string, IUserObjectFactory> objectFactory;

        static void Main(string[] args)
        {
            settings = new NetworkSettings();
            topology = new NetworkTopology();

            objectFactory = new Dictionary<string, IUserObjectFactory>();
            objectFactory.Add("standard", new StandLibFactory());

            loadTool = new LoadTool(ref settings, ref topology, ref objectFactory);
            updateTool = new UpdateTool(ref settings, ref topology);
            saveTool = new SaveTool(ref settings, ref topology);

            Console.WriteLine(
                "The ENN runtime has been succesfully started. You may now enter commands");
            Console.WriteLine("If you are not sure where to start enter -h.");
            
            Command command = RetrieveCommand(Console.ReadLine());
            while (command.BaseType != CommandType.Exit)
            {
                ProcessCommand(command);
                command = RetrieveCommand(Console.ReadLine());
            }
        }

        static Command RetrieveCommand(string raw)
        {
            string[] split = raw.Split(' ');
            List<RawCommand> rawCommands = new List<RawCommand>();

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

        static void ProcessCommand(Command command)
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
