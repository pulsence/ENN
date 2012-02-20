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
	/// Command line tool used to update the loaded settings.
	/// </summary>
    class UpdateTool
    {
        NetworkSettings settings;
        Dictionary<string, NetworkTopology> topologies;

        public UpdateTool(ref NetworkSettings settings,
            ref Dictionary<string, NetworkTopology> topologies)
        {
            this.settings = settings;
            this.topologies = topologies;
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
                Console.WriteLine("This tool allows you to update the current settings and topolgy");
                Console.WriteLine("To learn more about how to use this tool type the command -h -u");
            }
            else if (commands[1].CommandChar == 'k' && commands[2].CommandChar == 'v')
            {
                SettingsHandler(commands);
            }
            else
            {
                Console.WriteLine("Command passed is not recognized.");
                Console.WriteLine("To learn about the recognized commands type -h -u");
            }
        }

		/// <summary>
		/// Updates the settings that are currently loaded.
		/// </summary>
		/// <param name="commands">Commands used to customize the behavior of the
		/// command</param>
        void SettingsHandler(List<RawCommand> commands)
        {
            string key = commands[1].Value;
            string value = commands[2].Value;

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
                case "networkstyle":
                    if (value == "traditional")
                    {
                        settings.NetworkType = NetworkType.Traditional;
                    }
                    else
                    {
                        settings.NetworkType = NetworkType.Evolving;
                    }
                    break;
                case "trainingstyle":
                    if (value == "traditional")
                    {
                        settings.NetworkType = NetworkType.Traditional;
                    }
                    else
                    {
                        settings.NetworkType = NetworkType.Evolving;
                    }
                    break;
                case "inputlayer":
                    settings.DefaultInputLayer = value;
                    break;
                case "node":
                    settings.DefaultNode = value;
                    break;
                case "nodelayer":
                    settings.DefaultHiddenLayer = value;
                    break;
                case "outputlayer":
                    settings.DefaultOutputLayer = value;
                    break;
                case "enabletiming":
                    settings.EnableTiming = (value.ToLower() == "true");
                    break;
                case "trainingiterations":
                    int trainIter = 0;
                    int.TryParse(value, out trainIter);
                    settings.TrainingIterations = trainIter;
                    break;
                case "trainingaccuracy":
                    float trainAccuracy = 0;
                    float.TryParse(value, out trainAccuracy);
                    settings.TrainingAccuracy = trainAccuracy;
                    break;
                case "trainingpool":
                    int trainPool = 0;
                    int.TryParse(value, out trainPool);
                    settings.TraininPool = trainPool;
                    break;
                default:
                    if(settings.Other.ContainsKey(key))
                    {
						settings.Other[key] = value;
                    }
                    else
                    {
						settings.Other.Add(key, value);
                    }
                    break;
            }

            Console.WriteLine("Settings Updated");
        }
    }
}
