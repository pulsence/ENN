This project is an attempt to impliment an evolving neural network algorithm. In addition to the
evolution algorithm, it is also an attempt to create a solid plateform to create andrun neural networks
on. There three sections to the project: Framework, Runtime, GUI Apps.The framework contains classes,
functions and interfaces which are used as basic buildingblocks for networks and user created
extentions. The runtime is used through the command line and has a variety of tools to help with
settings and topologies. It also runs networks.GUI Apps are applications that assist in the creation of
settings files and topologies.

Version: preBeta 1.0.0 2.17.2012
Newly Added:
Framework:
-Hill Climb Algorithm was implimented for training

Runtime:
-Clean up settings file specification
-Define binary settings file
-Load binary settings file
-Save binary settings file
-Clean up topology file specification
-Define binary topology file
-Load binary topology file
-Save binary topology file

GUI Apps:
-seettingsbuilder:
	-added support for newer settings file specification
-topologybuilder:
	-can create topology hierarchy

Finished:
Framework:
-Basic classes
-Main interfaces
-Combination functions
-Activation functions
-Standard library factory
-Create learning algorithm interface
-Impliment hill climbing algorithm
-Created topology helper class
	-load/save topologies
-Created settings helper class
	-load/save settings

Runtime:
-load tool
	-can load binary and text files
	-now uses a helper class in the runtime
-update tool
	-can only change settings
-save tool
	-can load binary and text files
	-now uses a helper class in the runtime
-run
	-can run a specified topology
	-can test topologies
	-can run topology in either mode
-help tool
	-full load
	-full save
	-full run
	-partial update
		-only settings
-commands tool
-Clean up settings file specification
-Clean up topology file specification


GUI Apps:
-Settings Builder nearly finished
-Topology Builder started

To Do:
Framework:
-Allow user defined combination functions
-Allow user defined activation functions
-Impliment evolution algorithm
-Allow multiple topologies to be loaded
-Allow multiple user defined binaries to be loaded
-Add comments
-Add more data validation tests

Runtime:
-Update topology from command line
-Optimize topology loading
-Add comments
-Add more data validation tests
-Use default time when acceptable

GUI Apps:
-Update Settings Builder to reflect any changes in the settings file specification
-Topology Builder
	-Load and Save topology
	-specifiy data types for each topology item
	-finish implimenting menu items