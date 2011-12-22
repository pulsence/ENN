using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ENN.Framework;

namespace ENN.Runtime
{
    class SaveTool
    {
        NetworkSettings settings;
        NetworkTopology topology;

        public SaveTool(ref NetworkSettings settings, ref NetworkTopology topology)
        {
            this.settings = settings;
            this.topology = topology;
        }

        public void RunCommand(List<RawCommand> commands)
        {
            if (commands.Count < 2)
            {
                Console.WriteLine("This tool allows you to save settings and topolgy to a file");
                Console.WriteLine("To learn more about how to use this tool type the command -h -s");
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
                Console.WriteLine("To learn about the recognized commands type -h -s");
            }
        }

        void TopologyHandler(List<RawCommand> commands)
        {
            Console.WriteLine("Save topology");
        }

        void SettingsHandler(List<RawCommand> commands)
        {
            Console.WriteLine("Saving settings...");
            string filePath =
                "Settings\\settings_" + DateTime.Today.Day + "-" +
                                        DateTime.Today.Month + "-" +
                                        DateTime.Today.Year + ".nns";
            foreach (RawCommand command in commands)
            {
                if (command.CommandChar == 'f') filePath = command.Value;
            }
            StreamWriter writer = new StreamWriter(filePath);
            writer.WriteLine("networkmode:" + settings.Mode);
            writer.WriteLine("userbinarylocation:" + settings.UserBinaryLocation);
            writer.WriteLine("userbinaryclassname:" + settings.UserBinaryClassName);
            writer.WriteLine("userbinaryname:" + settings.UserBinaryName);
            writer.WriteLine("useuserbinary:" + settings.UseUserBinaries);
            writer.WriteLine("inputlayer:" + settings.DefaultInputLayer);
            writer.WriteLine("node:" + settings.DefaultNode);
            writer.WriteLine("nodelayer:" + settings.DefaultNodeLayer);
            writer.WriteLine("outputlayer:" + settings.DefaultOutputLayer);
            writer.WriteLine("enabletiming:" + settings.EnableTiming);
            writer.WriteLine("trainingtype:" + settings.TrainingStyle);
            writer.WriteLine("trainingmeasurement:" + settings.TrainingMeasure);
            writer.WriteLine("trainingpoint:" + settings.TrainingPoint);
            writer.Close();
            Console.WriteLine("Saving finished");
        }
    }
}
