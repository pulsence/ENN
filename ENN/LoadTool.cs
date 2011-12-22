using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using ENN.Framework;

namespace ENN.Runtime
{
    class LoadTool
    {
        NetworkSettings settings;
        NetworkTopology topology;
        Dictionary<string, IUserObjectFactory> objectFactory;

        public LoadTool(ref NetworkSettings settings, ref NetworkTopology topology,
            ref Dictionary<string, IUserObjectFactory> objectFactory)
        {
            this.settings = settings;
            this.topology = topology;
            this.objectFactory = objectFactory;
        }

        public void RunCommand(List<RawCommand> commands)
        {
            if (commands.Count < 2)
            {
                Console.WriteLine(
                    "This tool allows you to load settings, topolgy, and user binary from a file");
                Console.WriteLine("To learn more about how to use this tool type the command -h -l");
            }
            else if (commands[1].CommandChar == 't')
            {
                TopologyHandler(commands);
            }
            else if (commands[1].CommandChar == 's')
            {
                SettingsHandler(commands);
            }
            else if (commands[1].CommandChar == 'b')
            {
                BinaryHandler(commands);
            }
            else
            {
                Console.WriteLine("Command passed is not recognized.");
                Console.WriteLine("To learn about the recognized commands type -h -l");
            }
        }

        void TopologyHandler(List<RawCommand> commands)
        {
            Console.WriteLine("Loading topology...");
            try
            {
                StreamReader fs = File.OpenText(commands[2].Value);

                string newLine = " \t\n{";
                string line;
                string[] splitLine;
                List<RawType> rawTypes = new List<RawType>();
                RawType rawType = new RawType();
                bool openFound = false;
                while (!fs.EndOfStream)
                {
                    line = fs.ReadLine();
                    line = line.Trim();
                    if (!line.StartsWith("#") && line != "")
                    {
                        if (!openFound)
                        {
                            if (line[line.Length - 1] == '{')
                            {
                                line = line.Trim(newLine.ToCharArray());
                                rawType.Type = line;
                                openFound = true;
                            }
                        }
                        else if (line[0] == '}')
                        {
                            openFound = false;
                            rawTypes.Add(rawType);
                            rawType = new RawType();
                        }
                        else
                        {
                            splitLine = line.Split(':');
                            rawType.Fields.Add(splitLine[0].Trim(), splitLine[1].Trim());
                        }
                    }
                }

                fs.Close();

                Dictionary<string, IHiddenLayer> hiddenLayers = new Dictionary<string, IHiddenLayer>();
                string factoryName;
                for (int i = 0; i < rawTypes.Count; i++)
                {
                    factoryName = "standard";
                    if(rawTypes[i].Fields.ContainsKey("factory")) factoryName = rawTypes[i].Fields["factory"];
                    if (rawTypes[i].Type == "layer")
                    {
                        if (rawTypes[i].Fields["type"] == "hidden")
                        {
                            hiddenLayers.Add(rawTypes[i].Fields["layerName"],
                                objectFactory[factoryName].CreateUserObject<IHiddenLayer>(
                                rawTypes[i].Fields["dataType"],
                                rawTypes[i].Fields));
                        }
                        else if (rawTypes[i].Fields["type"] == "output")
                        {
                            topology.OutputLayer =
                                objectFactory[factoryName].CreateUserObject<IOutputLayer>(
                                rawTypes[i].Fields["dataType"], rawTypes[i].Fields);
                        }
                        else if (rawTypes[i].Fields["type"] == "input")
                        {
                            topology.InputLayer =
                                objectFactory[factoryName].CreateUserObject<IInputLayer>(
                                rawTypes[i].Fields["dataType"], rawTypes[i].Fields);
                        }
                    }
                    else if (rawTypes[i].Type == "node")
                    {
                        INode node = objectFactory[factoryName].CreateUserObject<INode>(
                            rawTypes[i].Fields["dataType"], rawTypes[i].Fields);
                        if (hiddenLayers.ContainsKey(rawTypes[i].Fields["layer"]))
                        {
                            hiddenLayers[rawTypes[i].Fields["layer"]].SetNode(node, -1);
                        }
                    }
                    else if (rawTypes[i].Type == "preprocessor")
                    {
                        topology.PreProcessor =
                            objectFactory[factoryName].CreateUserObject<IPreProcessor>(
                            rawTypes[i].Fields["dataType"], rawTypes[i].Fields);
                    }
                    else if (rawTypes[i].Type == "postprocessor")
                    {
                        topology.PostProcessor = objectFactory[factoryName].
                            CreateUserObject<IPostProcessor>(rawTypes[i].Fields["dataType"], rawTypes[i].Fields);
                    }
                }

                IHiddenLayer[] layer = new IHiddenLayer[hiddenLayers.Count];
                int j = 0;
                foreach (KeyValuePair<string,IHiddenLayer> temp in hiddenLayers )
                {
                    layer[j] = temp.Value;
                    j++;
                }
                topology.HiddenLayers = layer;

                Console.WriteLine("Finished loading.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Topology could not be loaded");
                Console.WriteLine("There was an error with the file");
#if(DEBUG)
                Console.WriteLine("Message: {0}\nSource: {1}", ex.Message, ex.Source);
#endif

            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Topology could not be loaded");
                Console.WriteLine("There was an error parsing the file");
#if(DEBUG)
                Console.WriteLine("Message: {0}\nSource: {1}", ex.Message, ex.Source);
#endif
            }
        }

        void SettingsHandler(List<RawCommand> commands)
        {
            Console.WriteLine("Loading settings...");
            try
            {
                StreamReader fs = File.OpenText(commands[2].Value);

                string line;
                string[] terms;
                while (!fs.EndOfStream)
                {
                    line = fs.ReadLine();
                    line = line.Trim();
                    if (!line.StartsWith("#") || !line.StartsWith(""))
                    {
                        terms = line.Split(':');

                        switch (terms[0])
                        {
                            case "networkmode":
                                if (terms[1] == "training")
                                {
                                    settings.Mode = NetworkMode.Training;
                                }
                                else
                                {
                                    settings.Mode = NetworkMode.Computational;
                                }
                                break;
                            case "trainingstyle":
                                if (terms[1] == "traditional")
                                {
                                    settings.TrainingStyle = TrainingType.Traditional;
                                }
                                else
                                {
                                    settings.TrainingStyle = TrainingType.Evolving;
                                }
                                break;
                            case "userbinarylocation":
                                settings.UserBinaryLocation = terms[1];
                                break;
                            case "userbinaryclassname":
                                settings.UserBinaryClassName = terms[1];
                                break;
                            case "userbinaryname":
                                settings.UserBinaryName = terms[1];
                                break;
                            case "useusesbinary":
                                settings.UseUserBinaries = (terms[1].ToLower() == "true");
                                break;
                            case "inputlayer":
                                settings.DefaultInputLayer = terms[1];
                                break;
                            case "node":
                                settings.DefaultNode = terms[1];
                                break;
                            case "nodelayer":
                                settings.DefaultNodeLayer = terms[1];
                                break;
                            case "outputlayer":
                                settings.DefaultOutputLayer = terms[1];
                                break;
                            case "enabletiming":
                                settings.EnableTiming = (terms[1].ToLower() == "true");
                                break;
                            case "trainingmeasurement":
                                if (terms[1] == "interations")
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
                                int.TryParse(terms[1], out trainPoint);
                                settings.TrainingPoint = trainPoint;
                                break;
                        }
                    }
                }
                fs.Close();
                Console.WriteLine("Loading has finished");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Settings could not be loaded");
                Console.WriteLine("There was an error with the file");
#if(DEBUG)
                Console.WriteLine("Message: {0}\nSource: {1}", ex.Message, ex.Source);
#endif

            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Settings could not be loaded");
                Console.WriteLine("There was an error parsing the file");
#if(DEBUG)
                Console.WriteLine("Message: {0}\nSource: {1}", ex.Message, ex.Source);
#endif
            }
        }

        void BinaryHandler(List<RawCommand> commands)
        {
            Console.WriteLine("Loading binary...");
            Assembly assembly = Assembly.LoadFrom(settings.UserBinaryLocation);
            IUserObjectFactory factory = (IUserObjectFactory)assembly.CreateInstance(settings.UserBinaryClassName);
            if (objectFactory == null) Console.WriteLine("The binary was not loaded successfully");
            else
            {
                if (objectFactory.ContainsKey(settings.UserBinaryName))
                {
                    objectFactory[settings.UserBinaryName] = factory;
                }
                else
                {
                    objectFactory.Add(settings.UserBinaryName, factory);
                }
            }
            Console.WriteLine("Finished");
        }
    }
}