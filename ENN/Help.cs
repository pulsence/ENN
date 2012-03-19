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

namespace ENN.Runtime
{
	/// <summary>
	/// Contains all the string values that are used by the help tool.
	/// </summary>
	static class Help
	{
		public const string application =
@"-a command allows you to launch separate tools that come with ENN.
-s launches the settings builder
-t launches the topology builder";

		public const string command =
@"The -c command allows you to load a command script file into the runtime.
These file are a series of commands in a file. Each command goes onto a
single line and are the same and if you were to enter them into the command
line. The -c command expects a -f parameter which specifies the file to
read from.

Example: -c -f Scripts/myScript.script";

		public const string intro = 
@"Enter one of the following commands with parameters. If you want to learn
more about a commands type -h <command>

<command>	Command Name	Description
---------------------------------------------------------------------------
   -r		Run		Runs the loaded network
   -l		Load tool	Launches the load tool
   -u		Update tool	Launches the update tool
   -s		Save tool	Launches the save tool
   -i		Info & Status	Show information and status
   -c		Command Script	Executes a file containing commands
   -a		App Launcher	Launcher Apps packaged with ENN
   -e		Exit		Exits the program";

		public const string load = 
@"Load Tool
This tool loads user defined binaries, settings files and topology files.
The type of file that is being loaded is defined by a command parameter.
<command>	Command Name	Description
---------------------------------------------------------------------------
   -s		Settings	Loads a settings file
   -t		Topology	Loads a topology file
   -b		Binary		Loads a user defined binary file

Command specific information:

-s command
This command overrights the current settings with the settings found in the
file.
<parameter>	parameter name	Description
---------------------------------------------------------------------------
 -f		file path	The path to the file
 -b		binary flag	Identifies if the file is a binary file. If
				this flag is not set, then the file is
				loaded based on its extention.

Example: -l -s -f C:\\ENN\\Settings\\mysettings.nns

-t command
The -b and -n commands can be in any order but they must come after the -f
command though. Also if there is a topology that is already loaded with the
same name as the one being loaded, the loaded topology will be overwritten
by the new topology.
<parameter>	parameter name	Description
---------------------------------------------------------------------------
 -f		file path	The path to the file
 -b		binary flag	Identifies if the file is a binary file. If
				this flag is not set, then the file is
				loaded based on its extention.
 -n		name command	This sets the name that the will be used to
				reference the topology internally. If this
				is not set then the name is determined by
				the name set in the file or an
				autogenerated name.

Example: -l -t -f C:\\ENN\\Topologies\\topology.nntc -n myTopology

-b command
The -n command must come after the -f command.
<parameter>	parameter name	Description
---------------------------------------------------------------------------
 -f		file path	The path to the file
 -n		name command	This sets the name that will be used to
				refer to you library internally. If this is
				not set then class name will be loaded.

Example: -l -b -f C:\\ENN\\UserBin\\myLib.dll -n myLib";

		public const string save=
@"Save Tool
This tool allows you to save settings and topology to file
The command takes another command, -s or -t to determine what is being
saved.

-s refers to settings and -t refers to topology
For -t also add -n {name of topology} to save a specific topology. If this
is not included then no topologies will be saved.

The commands also takes another command -f which specifies the file
location. They also take the -b flag which when added tells the tool to
create a binary file. If this is not included then a binary or text file
is created based upon the file extention.

Note: if -f is not specified a stock name is used and the file is saved in
either the Settings or Topologies folder.

Examples:
-s -s
-s -s -f C:\\ENN\\Settings\\mySettings.nnsc -b
-s -t -n mainTopology -f C:\\ENN\\Topologies\\mainTopology.nnt";

		public const string update = 
@"Update Tool
This tool updates the currently loaded settings.

This command takes two parameters which are outlined below. The paremeters
must be order in the following fashion, -k <value> -v <value>. If -k does
not come immediatly before -v then the command will not be processed.
<parameter>	Parameter Name	Description
---------------------------------------------------------------------------
   -k		Key		The name of the key to change
   -v		Value		The new value to set to key to

Note that every key expects different values so please look up proper value
before using this tool.

Keys and Values
Key Name		Value Expected
---------------------------------------------------------------------------
networkmode		training or computational
networktype		traditional or evolving
inputlayer		Name of the default class to use
node			Name of the default class to use
nodelayer		Name of the default class to use
outputlayer		Name of the default class to use
enabletiming		true or false
trainingaccuracy	Decimal value for accuracy ex: 0.9
trainingiterations	Integer value
trainingpool		Integer value

Example: -u -k networkmode -v training";
	}
}
