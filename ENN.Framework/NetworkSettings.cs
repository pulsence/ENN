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
using System.Text;
using System.Collections.Generic;

namespace ENN.Framework
{
    /// <summary>
    /// The mode that the network can be in.
    /// </summary>
    [Serializable()]
    public enum NetworkMode { Training, Computational }

    /// <summary>
    /// The training style of the network
    /// </summary>
    [Serializable()]
    public enum NetworkType { Traditional, Evolving }
        
    /// <summary>
    /// Class that encapsulats the network settings.
    /// </summary>
    [Serializable()]
    public class NetworkSettings
    {
        /// <summary>
        /// The network mode
        /// </summary>
        public NetworkMode Mode { get; set; }
        /// <summary>
        /// The style of training to be used if the network is in training mode.
        /// </summary>
        public NetworkType NetworkType { get; set; }


        //Execution information
        /// <summary>
        /// Location to the user binaries
        /// </summary>
        public string UserBinaryLocation { get; set; }

        /// <summary>
        /// Full name of the user object factory in the binaries.
        /// <example>Namespace.ClassName</example>
        /// <example>TestUserBinary.TestBinary</example>
        /// </summary>
        public string UserBinaryClassName { get; set; }

        /// <summary>
        /// Name that the binary will have in the runetime.
        /// </summary>
        public string UserBinaryName { get; set; }

        /// <summary>
        /// Determines if the binaries should be used or not.
        /// </summary>
        public bool UseUserBinaries { get; set; }

        
        /// <summary>
        /// Default data type for the input layer.
        /// </summary>
        public string DefaultInputLayer { get; set; }

        /// <summary>
        /// Default data type for the nodes.
        /// </summary>
        public string DefaultNode { get; set; }

        /// <summary>
        /// Default data type for the hidden layer.
        /// </summary>
        public string DefaultHiddenLayer { get; set; }

        /// <summary>
        /// Default data type for the output layer.
        /// </summary>
        public string DefaultOutputLayer { get; set; }

        /// <summary>
        /// Default factory to be used if none is specified.
        /// </summary>
        public string DefaultFactory { get; set; }

        /// <summary>
        /// Should the time for certain operations be outputed
        /// </summary>
        public bool EnableTiming { get; set; }

        //Training information
        /// <summary>
        /// The style to measure training progress
        /// </summary>
        public int TrainingIterations { get; set; }

        /// <summary>
        /// Point to train to. This value is depended upon the TrainingMeasure.
        /// </summary>
        public float TrainingAccuracy { get; set; }

        /// <summary>
        /// The number of times to execute an topology before running the
        /// training algorithm.
        /// </summary>
        public int TraininPool { get; set; }

        /// <summary>
        /// If other settings fields were included then they can be found here.
        /// </summary>
        public Dictionary<string, string> Other { get; set; }


        public NetworkSettings()
        {
            Mode = NetworkMode.Computational;
            NetworkType = NetworkType.Evolving;

            UserBinaryLocation = "UserBin\\";
            UserBinaryClassName = "N\\A";
            UserBinaryName = "N\\A";
            UseUserBinaries = false;

            DefaultInputLayer = "BasicInputLayer";
            DefaultNode = "BasicNode";
            DefaultHiddenLayer = "BasicNodeLayer";
            DefaultOutputLayer = "BasicOutputLayer";
            DefaultFactory = "standard";

            EnableTiming = false;

            TrainingIterations = 10000;
            TrainingAccuracy = 0.9f;

            Other = new Dictionary<string, string>();
        }

        public override string ToString()
        {
            StringBuilder outVal =new StringBuilder();
            outVal.AppendLine("Mode: " + Mode);
            outVal.AppendLine("Network Type: " + NetworkType);
            outVal.AppendLine("User Binary Location: " + UserBinaryLocation);
            outVal.AppendLine("User Binary Name: " + UserBinaryName);
            outVal.AppendLine("Use User Binary: " + UseUserBinaries);
            outVal.AppendLine("Default Input Layer: " + DefaultInputLayer);
            outVal.AppendLine("Default Node: " + DefaultNode);
            outVal.AppendLine("Default Node Layer: " + DefaultHiddenLayer);
            outVal.AppendLine("Default OutputLayer: " + DefaultOutputLayer);
            outVal.AppendLine("Timing Enabled: " + EnableTiming);
            outVal.AppendLine("Training Iterations: " + TrainingIterations);
            outVal.AppendLine("Training Accuracy: " + TrainingAccuracy);
			outVal.AppendLine("Training Point: " + TraininPool);
            foreach (KeyValuePair<string,string> key in Other)
            {
                outVal.AppendFormat("{0}: {1}\n", key.Key, key.Value);
            }
            return outVal.ToString();
        }

		public override bool Equals(object obj)
		{
			NetworkSettings other = (NetworkSettings)obj;
			if (other == null) return true;

			if (this.Mode != other.Mode ||
				this.NetworkType != other.NetworkType) return true;

			if (this.UserBinaryClassName != other.UserBinaryClassName ||
				this.UserBinaryLocation != other.UserBinaryLocation ||
				this.UserBinaryName != other.UserBinaryName ||
				this.UseUserBinaries != other.UseUserBinaries) return false;

			if (this.DefaultFactory != other.DefaultFactory ||
				this.DefaultHiddenLayer != other.DefaultHiddenLayer ||
				this.DefaultInputLayer != other.DefaultInputLayer ||
				this.DefaultNode != other.DefaultNode ||
				this.DefaultOutputLayer != other.DefaultOutputLayer) return false;

			if (this.EnableTiming != other.EnableTiming) return false;

			if (this.TrainingAccuracy != other.TrainingAccuracy ||
				this.TrainingIterations != other.TrainingIterations ||
				this.TraininPool != other.TraininPool) return false;

			if (this.Other.Count != other.Other.Count) return false;

			foreach (KeyValuePair<string, string> key in this.Other)
			{
				if(!other.Other.ContainsKey(key.Key)) return false;
				if (key.Value != other.Other[key.Key]) return false;
			}

			return true;
		}
    }
}