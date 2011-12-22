using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENN.Framework
{
    public enum NetworkMode { Training, Computational }
    public enum TrainingType { Traditional, Evolving }
    public enum TrainingMeasurement { Iterations, Accuracy }
 
    public class NetworkSettings
    {
        public NetworkMode Mode { get; set; }
        public TrainingType TrainingStyle { get; set; }

        //Execution information
        public string UserBinaryLocation { get; set; }
        public string UserBinaryClassName { get; set; }
        public string UserBinaryName { get; set; }
        public bool UseUserBinaries { get; set; }

        public string DefaultInputLayer { get; set; }
        public string DefaultNode { get; set; }
        public string DefaultNodeLayer { get; set; }
        public string DefaultOutputLayer { get; set; }

        public bool EnableTiming { get; set; }
        //Training information
        public TrainingMeasurement TrainingMeasure { get; set; }
        public int TrainingPoint { get; set; }

        public NetworkSettings()
        {
            Mode = NetworkMode.Computational;
            TrainingStyle = TrainingType.Evolving;

            UserBinaryLocation = "UserBin\\";
            UserBinaryClassName = "N\\A";
            UserBinaryName = "N\\A";
            UseUserBinaries = false;

            DefaultInputLayer = "BasicInputLayer";
            DefaultNode = "BasicNode";
            DefaultNodeLayer = "BasicNodeLayer";
            DefaultOutputLayer = "BasicOutputLayer";

            EnableTiming = false;

            TrainingMeasure = TrainingMeasurement.Accuracy;
            TrainingPoint = 90;
        }

        public override string ToString()
        {
            return "Mode: " + Mode + "\n" +
                   "Training Style: " + TrainingStyle + "\n" +
                   "User Binary Location: " + UserBinaryLocation + "\n" +
                   "User Binary Name: " + UserBinaryName + "\n" +
                   "Use User Binary: " + UseUserBinaries + "\n" +
                   "Default Input Layer: " + DefaultInputLayer + "\n" +
                   "Default Node: " + DefaultNode + "\n" +
                   "Default Node Layer: " + DefaultNodeLayer + "\n" +
                   "Default OutputLayer: " + DefaultOutputLayer + "\n" +
                   "Timing Enabled: " + EnableTiming + "\n" +
                   "Training Measurement: " + TrainingMeasure + "\n" +
                   "Training Level: " + TrainingPoint;
        }
    }
}
