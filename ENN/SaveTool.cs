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
using ENN.Framework;
using ENN.Framework.Tools;

namespace ENN.Runtime
{
    class SaveTool
    {
        NetworkSettings settings;
        Dictionary<string, NetworkTopology> topologies;

        public SaveTool(ref NetworkSettings settings,
            ref Dictionary<string, NetworkTopology> topologies)
        {
            this.settings = settings;
            this.topologies = topologies;
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

            string filePath =
                "Topologies\\topologies_" + DateTime.Today.Day + "-" +
                                        DateTime.Today.Month + "-" +
                                        DateTime.Today.Year + ".nnt";
            foreach (RawCommand command in commands)
            {
                if (command.CommandChar == 'f')
                {
                    filePath = command.Value;
                    break;
                }
            }

            try
            {
                foreach (KeyValuePair<string, NetworkTopology> topology in topologies)
                {
                    Topology.Save(filePath, topology.Value);
                }
                Console.WriteLine("Saving finished");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Topology could not be saved");
                Console.WriteLine("There was an error writing to the file");
                #if(DEBUG)
                Console.WriteLine("Message: {0}\nSource: {1}", ex.Message, ex.Source);
                #endif
            }

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
                if (command.CommandChar == 'f')
                {
                    filePath = command.Value;
                    break;
                }
            }

            try
            {

                Settings.Save(settings, filePath);
                Console.WriteLine("Saving finished");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Settings could not be saved");
                Console.WriteLine("There was an error writing to the file");
                #if(DEBUG)
                Console.WriteLine("Message: {0}\nSource: {1}", ex.Message, ex.Source);
                #endif
            }
        }
    }
}
