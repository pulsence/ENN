using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENN.Framework;

namespace ENN.Runtime
{
    class UpdateTool
    {
        NetworkSettings settings;
        NetworkTopology topology;

        public UpdateTool(ref NetworkSettings settings, ref NetworkTopology topology)
        {
            this.settings = settings;
            this.topology = topology;
        }

        public void RunCommand(List<RawCommand> commands)
        {
            if (commands.Count < 2)
            {
                Console.WriteLine("This tool allows you to update the current settings and topolgy");
                Console.WriteLine("To learn more about how to use this tool type the command -h -u");
            }
            else if (commands[1].CommandChar == 't')
            {
                TopologyHandler(commands);
            }
            else if (commands[1].CommandChar == 's')
            {
                SettingsHandler(commands);
            }
            else
            {
                Console.WriteLine("Command passed is not recognized.");
                Console.WriteLine("To learn about the recognized commands type -h -u");
            }
        }

        void SettingsHandler(List<RawCommand> commands)
        {
            string key = "";
            string value = "";

            foreach (RawCommand command in commands)
            {
                if (command.CommandChar == 'k') key = command.Value;
                else if (command.CommandChar == 'v') value = command.Value;
            }

            switch (key)
            {
                case "networkmode":
                    if (value == "training")
                    {
                        settings.Mode = NetworkMode.Training;
                    }
                    else
                    {
                        settings.Mode = NetworkMode.Computational;
                    }
                    break;
                case "trainingstyle":
                    if (value == "traditional")
                    {
                        settings.TrainingStyle = TrainingType.Traditional;
                    }
                    else
                    {
                        settings.TrainingStyle = TrainingType.Evolving;
                    }
                    break;
                case "userbinarylocation":
                    settings.UserBinaryLocation = value;
                    break;
                case "userbinaryclassname":
                    settings.UserBinaryClassName = value;
                    break;
                case "userbinaryname":
                    settings.UserBinaryName = value;
                    break;
                case "useusesbinary":
                    settings.UseUserBinaries = (value.ToLower() == "true");
                    break;
                case "inputlayer":
                    settings.DefaultInputLayer = value;
                    break;
                case "node":
                    settings.DefaultNode = value;
                    break;
                case "nodelayer":
                    settings.DefaultNodeLayer = value;
                    break;
                case "outputlayer":
                    settings.DefaultOutputLayer = value;
                    break;
                case "enabletiming":
                    settings.EnableTiming = (value.ToLower() == "true");
                    break;
                case "trainingmeasurement":
                    if (value == "interations")
                    {
                        settings.TrainingMeasure = TrainingMeasurement.Iterations;
                    }
                    else
                    {
                        settings.TrainingMeasure = TrainingMeasurement.Accuracy;
                    }
                    break;
                case "trainingpoint":
                    int trainPoint = 0;
                    int.TryParse(value, out trainPoint);
                    settings.TrainingPoint = trainPoint;
                    break;
            }

            Console.WriteLine("Settings Updated");
        }

        void TopologyHandler(List<RawCommand> commands)
        {
            Console.WriteLine("Update topology");
        }
    }
}
