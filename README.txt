This project is an attempt to impliment an evolving neural network algorithm. In addition to the evolution algorithm, it is also an attempt to create a
solid plateform to create and run neural networks on. There three sections to the project: Framework, Runtime, GUI Apps. The framework contains classes,
functions and interfaces which are used as basic building blocks for networks and user created extentions. The runtime is used through the command line and
has a variety of tools to help with settings and topologies. It also runs networks. GUI Apps are applications that assist in the creation of settings files
and topologies.

Version: preBeta 1.0.0
Finished:
Framework:
-Basic classes
-Main interfaces
-Combination functions
-Activation functions
-Standard library factory

Runtime:
-load tool
	-only text files
-update tool
	-only settings
-save tool
	-only text files
-run
	-runs computational networks
	-can test if network can be run
-help tool
	-full load
	-full save
	-full run
	-partial update
		-only settings
-commands tool


GUI Apps:
-Settings Builder finished

ToDo:
Framework:
-Allow user defined combination functions
-Allow user defined activation functions
-Create learning algorithm interface
-Impliment hill climbing algorithm
-Impliment evolution algorithm
-Allow multiple topologies to be loaded
-Allow multiple settings to be loaded
-Allow multiple user defined binaries to be loaded
-Add comments
-Add more data validation tests

Runtime:
-Clean up settings file specification
-Define binary settings file
-Load binary settings file
-Save binary settings file
-Clean up topology file specification
-Define binary topology file
-Load binary topology file
-Save binary topology file
-Update topology from command line
-Optimize topology loading
-Allow network training
-Add comments
-Add more data validation tests

GUI Apps:
-Update Settings Builder to reflect any changes in the settings file specification
-Create Topology Builder