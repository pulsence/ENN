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
	/// Implimentation of the ITraingingAlgorithm interface. Basic implimentation of
	/// the hill climbing algorithm.
	/// </summary>
    [Serializable()]
    public class HillClimbAlgo : ITrainingAlgorithm
    {
        private NetworkSettings settings;
        private int layerIndex;
        private int nodeIndex;
        private int weightIndex;
        private int flips;
        private int maxFlips;

        private float baseStepValue;
        private float stepValue;
        private float priorWeightValue;
        private float priorError;

        public HillClimbAlgo()
        {
            layerIndex = 0;
            nodeIndex = 0;
            weightIndex = 0;
            flips = 0;
            maxFlips = 20;

            baseStepValue = 1;
            stepValue = baseStepValue;
            priorError = float.MinValue;
            priorWeightValue = -2.0f;

			settings = null;
        }

		/// <summary>
		/// Sets the base settings values for the training algorithm
		/// </summary>
		/// <param name="settings">The network settings of the network that is
		/// calling the class.</param>
        public void SetSettings(NetworkSettings settings)
        {
            this.settings = settings;
            if (settings.Other.ContainsKey("startlayerindex"))
                int.TryParse(settings.Other["startlayerindex"], out layerIndex);
            if (settings.Other.ContainsKey("startnodeindex"))
                int.TryParse(settings.Other["startnodeindex"], out nodeIndex);
            if (settings.Other.ContainsKey("basestepvalue"))
                float.TryParse(settings.Other["basestepvalue"], out stepValue);
            if (stepValue == 0) stepValue = 1;
            if (settings.Other.ContainsKey("maxflips"))
                int.TryParse(settings.Other["maxflips"], out maxFlips);
            if (maxFlips == 0) maxFlips = 20;
        }

		/// <summary>
		/// Trains the network.
		/// </summary>
		/// <param name="topology">Reference to the topology object to train.</param>
		/// <param name="error">The current error in decimal format of the topology.
		/// Example of expected: 0.6</param>
        public void TrainNetwork(ref NetworkTopology topology, float error)
        {
            if (error > priorError)
            {
                stepValue *= -0.5f;
                flips++;
            }
            if (flips == maxFlips)
            {
                nodeIndex++;
                weightIndex = 0;
                stepValue = baseStepValue;
            }
            if (weightIndex > topology.HiddenLayers[layerIndex].Nodes[nodeIndex].Weights.Length)
            {
                nodeIndex++;
                weightIndex = 0;
                stepValue = baseStepValue;
            }
            if (nodeIndex > topology.HiddenLayers[layerIndex].Nodes.Length)
            {
                nodeIndex = 0;
                weightIndex = 0;
                layerIndex++;
                stepValue = baseStepValue;
            }
            if (layerIndex > topology.HiddenLayers.Length)
            {
                nodeIndex = 0;
                layerIndex = 0;
                weightIndex = 0;
                stepValue = baseStepValue;
            }
            priorError = error;
            topology.HiddenLayers[layerIndex].Nodes[nodeIndex].Weights[weightIndex] += stepValue;
        }

		/// <summary>
		/// Resets the fields of the object.
		/// </summary>
		public void Reset()
		{
			layerIndex = 0;
			nodeIndex = 0;
			weightIndex = 0;
			flips = 0;
			maxFlips = 20;

			baseStepValue = 1;
			stepValue = baseStepValue;
			priorError = float.MinValue;
			priorWeightValue = -2.0f;

			if (settings == null) return;
			if (settings.Other.ContainsKey("startlayerindex"))
				int.TryParse(settings.Other["startlayerindex"], out layerIndex);
			if (settings.Other.ContainsKey("startnodeindex"))
				int.TryParse(settings.Other["startnodeindex"], out nodeIndex);
			if (settings.Other.ContainsKey("basestepvalue"))
				float.TryParse(settings.Other["basestepvalue"], out stepValue);
			if (stepValue == 0) stepValue = 1;
			if (settings.Other.ContainsKey("maxflips"))
				int.TryParse(settings.Other["maxflips"], out maxFlips);
			if (maxFlips == 0) maxFlips = 20;

		}

		public override bool Equals(object obj)
		{
			HillClimbAlgo other = (HillClimbAlgo)obj;
			if (other == null) return false;

			return true;
		}
    }
}
