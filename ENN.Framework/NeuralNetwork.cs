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
using System.Diagnostics;

namespace ENN.Framework
{
    /// <summary>
    /// Class that represents a neural network. This class is used to actually run and train
    /// an neural network when provided with the completed NetworkTopology and NetworkSettings.
	/// This network is modeled after the traditional neural network designs.
    /// </summary>
    public class NeuralNetwork
    {
        protected NetworkTopology topology;
        protected NetworkSettings settings;

        public NeuralNetwork(NetworkTopology topology, NetworkSettings settings)
        {
            this.topology = topology;
            this.settings = settings;
        }

        /// <summary>
        /// Starts a network. Will either start training or computing a resualt based
        /// upon its settings.
        /// </summary>
        /// <param name="state">Information that can be passed to the network in a threaded
        /// environment.</param>
        public void StartNetwork(object state = null)
        {
            if (settings.Mode == NetworkMode.Computational)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                ComputeDecision();
                sw.Stop();
                if(settings.EnableTiming) Console.WriteLine("Time required: {0}", sw.Elapsed);
            }
            else
            {
                TrainNetwork();
            }
        }

        /// <summary>
        /// Calculates a final value for the network
        /// </summary>
        private float ComputeDecision()
        {
            float val;

			//Retrieves the input values
            float[] inputPool = topology.PreProcessor.GenerateValues();
            topology.InputLayer.SetInputPool(ref inputPool);

			//primes the first layer values
            float[] layerVals = topology.InputLayer.GetValues();

			//calculates the values for every layer
            for (int i = 0; i < topology.HiddenLayers.Length; i++)
            {
                layerVals = topology.HiddenLayers[i].GetValues(layerVals);
            }
			//calculates the final values
            val = topology.OutputLayer.GetValue(layerVals);
            topology.PostProcessor.FinalAction(val);
            return val;
        }

        /// <summary>
        /// Traines the given network with the set algorithm.
        /// </summary>
        private void TrainNetwork()
        {
            topology.TrainingAlgorithm.SetSettings(settings);

			//network desisions calculated since the last time the training
			//algorithm was passed over the network.
            int countSinceTrain = 0;

			//standard max value to go until passing the training algorithm
			//over the network.
            int maxCountSinceTrain = 40;
            if (settings.TraininPool != null
                && settings.TraininPool > 0)
                maxCountSinceTrain = settings.TraininPool;
			//time the training algo has been applied
            int trainingIterations = 0;
            if (settings.TrainingIterations == -1) trainingIterations = -2;

            float value;
            float expected;
            float error;
            float average = 0;//average error
            while ((1 - average) < settings.TrainingAccuracy &&
                   trainingIterations < settings.TrainingIterations)
            {
                average = 0;
                while (countSinceTrain < maxCountSinceTrain)
                {
                    value = ComputeDecision();
                    expected = topology.TrainingPreProcessor.ExpectedResult();
                    error = (expected - value) / expected;
                    error = Math.Abs(error);
                    average = average + ((error - average) / (countSinceTrain + 1));
                    countSinceTrain++;
                }
                topology.TrainingAlgorithm.TrainNetwork(ref topology, average);
                if (settings.TrainingIterations != -1) trainingIterations++;
            }

			topology.TrainingAlgorithm.Reset();
        }
    }
}
