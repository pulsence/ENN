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

namespace ENN.Framework
{
    /// <summary>
    /// Data class that encapsulates the objects which define the topology of the network.
    /// </summary>
    [Serializable()]
    public class NetworkTopology : IMetaData
    {
        //fields
        protected Dictionary<string, string> metaData;

        protected IHiddenLayer[] hiddenLayers;
        protected IInputLayer inputLayer;
        protected IOutputLayer outputLayer;

        protected IPreProcessor preProcessor;
        protected IPostProcessor postProcessor;

        //properties

        /// <summary>
        /// Property to access the meta data for this object. This is used to save to file.
        /// </summary>
        public Dictionary<string, string> MetaData { get { return metaData; }
                                                     set { metaData = value; } }

        /// <summary>
        /// Array of IHiddenLayer. This represents the hidden layer objects.
        /// </summary>
        public IHiddenLayer[] HiddenLayers { get { return hiddenLayers; }
                                             set { hiddenLayers = value; } }
        
        /// <summary>
        /// This represents the input layer which retrieves data points from the preprocessor.
        /// </summary>
        public IInputLayer InputLayer { get { return inputLayer; }
                                        set { inputLayer = value; } }
        
        /// <summary>
        /// This represents the output layer which recieves the final values from the last hidden
        /// layer and combines them. The value is then passed to the postprocessor.
        /// </summary>
        public IOutputLayer OutputLayer { get { return outputLayer; }
                                          set { outputLayer = value; } }

        /// <summary>
        /// User defined preprocessor. Generates input values.
        /// </summary>
        public IPreProcessor PreProcessor { get { return preProcessor; }
                                            set { preProcessor = value; } }

        /// <summary>
        /// User defined preprocessor to be used during training.
        /// </summary>
        public ITrainingPreProcessor TrainingPreProcessor { get; set; }

        /// <summary>
        /// User defined postprocessor. Recieves the final value from the output layer and then takes
        /// some action.
        /// </summary>
        public IPostProcessor PostProcessor { get { return postProcessor; }
                                              set { postProcessor = value; } }

        /// <summary>
        /// The training algorithm that will be used when the network in being trained.
        /// </summary>
        public ITrainingAlgorithm TrainingAlgorithm { get; set; }

        public NetworkTopology()
        {
            hiddenLayers = null;
            inputLayer = null;
            outputLayer = null;

            preProcessor = null;
            postProcessor = null;

            TrainingPreProcessor = null;
            TrainingAlgorithm = null;
        }

        public override string ToString()
        {
            string value = "";

            if (inputLayer != null)
            {
                value += "Input Layer:\n" + inputLayer.ToString();
            }
            if (hiddenLayers != null)
            {
                value += "\nHidden Layers:\n" + hiddenLayers.ToString();
            }
            if (outputLayer != null)
            {
                value += "\nOutput Layer:\n" + outputLayer.ToString();
            }
            if(preProcessor != null)
            {
                value += "\nPre-Processor:\n"+preProcessor.ToString();
            }
            if(postProcessor != null)
            {
                value += "\nPost-Processor:\n"+postProcessor.ToString();
            }
            return value;
        }

		public override bool Equals(object obj)
		{
			NetworkTopology other = (NetworkTopology)obj;

			if (other == null) return false;

			if (!preProcessor.Equals( other.PreProcessor)) return false;
			if (!postProcessor .Equals(other.postProcessor)) return false;
			if (!TrainingAlgorithm.Equals(other.TrainingAlgorithm)) return false;
			if (!TrainingPreProcessor.Equals(other.TrainingPreProcessor)) return false;
			if (!inputLayer.Equals(other.InputLayer)) return false;
			if (!outputLayer.Equals(other.OutputLayer)) return false;

			if (!hiddenLayers.Length.Equals(other.HiddenLayers.Length)) return false;
			for (int i = 0; i < hiddenLayers.Length; i++)
			{
				if (!hiddenLayers[i].Equals(other.HiddenLayers[i])) return false;
			}

			return true;
		}
    }
}
