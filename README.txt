This project is an attempt to impliment an evolving neural network algorithm. In addition to the
evolution algorithm, it is also an attempt to create a solid plateform to create andrun neural networks
on. There three sections to the project: Framework, Runtime, GUI Apps.The framework contains classes,
functions and interfaces which are used as basic buildingblocks for networks and user created
extentions. The runtime is used through the command line and has a variety of tools to help with
settings and topologies. It also runs networks.GUI Apps are applications that assist in the creation of
settings files and topologies.

To read the topology and settings file specification, go to the following address:
https://docs.google.com/open?id=0B-lvvNhCn-WJNzU4ZDYyMWUtMDVmMS00NDJmLWE0NzItNjA0NTg0YmE1MDY4

Version: 1.0.0 3.18.2012

Finished:
Framework:
-Basic classes
-Main interfaces
-Combination functions
-Activation functions
-Standard library factory
-Create learning algorithm interface
-Impliment evolution algorithm
-Impliment hill climbing algorithm
-Created topology helper class
	-load/save topologies
-Created settings helper class
	-load/save settings

Runtime:
-load tool
	-can load binary and text files
	-can load multiple user binaries and topologies
	-now uses a helper class in the runtime
-update tool
	-can modify settings
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
-commands tool

GUI Apps:
-Settings Builder finished
-Topology Builder started