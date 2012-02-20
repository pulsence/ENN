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
	/// <summary>
	/// Allows for the user to save topologies and settings from the command line.
	/// </summary>
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

		/// <summary>
		/// Handles the commands.
		/// </summary>
		/// <param name="commands">The commands and parameters passed with the
		/// save command</param>
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

		/// <summary>
		/// Saves a topology to disk.
		/// </summary>
		/// <param name="commands">Commands used to customize the behavior of the
		/// command</param>
        private void TopologyHandler(List<RawCommand> commands)
        {
            Console.WriteLine("Saving topology...");

            string filePath = "";
			string name = "";
			bool binary = false;

            foreach (RawCommand command in commands)
            {
                if (command.CommandChar == 'f')
                {
                    filePath = command.Value;
                }
				else if (command.CommandChar == 'b')
				{
					binary = true;
				}
				else if(command.CommandChar == 'n')
				{
					name = command.Value;
				}
            }

			if (name == "")
			{
				Console.WriteLine("Could not save topology");
				Console.WriteLine("No topology was choosen to save");
				return;
			}

			if (filePath == "")
			{
				filePath =
				"Topologies\\" + name + "_" + DateTime.Today.Day + "-" +
											  DateTime.Today.Month + "-" +
											  DateTime.Today.Year + ".";
				if (binary)
				{
					filePath += "nntc";
				}
				else
				{
					filePath += "nnt";
				}
			}

			if (!binary)
			{
				binary = filePath.EndsWith("nntc", true, null);
			}

            try
            {
				if (topologies.ContainsKey(name))
				{
					Topology.Save(filePath, topologies[name], binary);
					Console.WriteLine("The topology was saved.");
				}
				else
				{
					Console.WriteLine("The topology was not saved.");
					Console.WriteLine(
						"There was not topology loaded with the name {0}.",
						name);
				}
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

		/// <summary>
		/// Saves the settings to disk.
		/// </summary>
		/// <param name="commands">Commands used to customize the behavior of the
		/// command</param>
        private void SettingsHandler(List<RawCommand> commands)
        {
            Console.WriteLine("Saving settings...");

			string filePath = "";
			bool binary = false;

			foreach (RawCommand command in commands)
			{
				if (command.CommandChar == 'f')
				{
					filePath = command.Value;
				}
				else if (command.CommandChar == 'b')
				{
					binary = true;
				}
			}

			if (filePath == "")
			{
				filePath =
				"Topologies\\settings_" + DateTime.Today.Day + "-" +
											  DateTime.Today.Month + "-" +
											  DateTime.Today.Year + ".";
				if (binary)
				{
					filePath += "nnsc";
				}
				else
				{
					filePath += "nns";
				}
			}

			if (!binary)
			{
				binary = filePath.EndsWith("nnsc", true, null);
			}

            try
            {
                Settings.Save(settings, filePath);
                Console.WriteLine("Settings were saved.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("The settings could not be saved.");
                Console.WriteLine("There was an error writing to the file.");
                #if(DEBUG)
                Console.WriteLine("Message: {0}\nSource: {1}", ex.Message, ex.Source);
                #endif
            }
        }
    }
}
