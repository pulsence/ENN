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
using System.Diagnostics;
using System.Threading.Tasks;

namespace ENN.Framework
{
	/// <summary>
	/// Implimentation of an evolving neural network. This network type creates
	/// topologies by using a genetic algorithm to create topologies the
	/// better suite a specific problem domain.
	/// </summary>
	public class EvolvingNeuralNetwork
	{
		NetworkTopology[] topologies;
		NetworkSettings settings;
		Random random;

		public EvolvingNeuralNetwork(NetworkTopology[] topologies, NetworkSettings settings)
		{
			this.topologies = topologies;
			this.settings = settings;
		}

		/// <summary>
		/// Starts the network. Note that this network can not run in computational mode.
		/// In order to use this network its mode needs to be in training.
		/// </summary>
		/// <param name="state">State variable used with threading.</param>
		public void StartNetwork(object state = null)
		{
			if (settings.Mode == NetworkMode.Computational) return;

			//the number of generations.
			int iterations = 0;

			int maxGeneration = 10000;
			if (settings.Other.ContainsKey("enn_generations"))
			{
				int.TryParse(settings.Other["enn_generations"],
							 out maxGeneration);
			}

			//stores the accuracy for each topology
			float[] accuracies = new float[topologies.Length];

			//the numer of indivuduals that should be considered the most
			//fit and would live on to the next generation.
			int mostFitCount;
			if (topologies.Length > 4)
				mostFitCount = topologies.Length / 4;
			else
				mostFitCount = 1;
			random = new Random();

			//indexs of parents to be used to create a child
			int p1, p2;

			float mutationRate = 1;
			if (settings.Other.ContainsKey("enn_mutationrate"))
			{
				float.TryParse( settings.Other["enn_mutationrate"],
								out mutationRate);
			}

			float mostFitAvr = 0;

			Stopwatch sw = new Stopwatch();
			sw.Start();
			while (iterations < maxGeneration)
			{
				Parallel.For(0, topologies.Length, i =>
				{
					accuracies[i] = TrainNetwork(ref topologies[i]);
				});
				Array.Sort(accuracies, topologies);
				
				for (int i = mostFitCount; i < topologies.Length; i++)
				{
					if ((i - mostFitCount) < mostFitCount)
					{
						p1 = i - mostFitCount;
						p2 = i - mostFitCount + 1;
					}
					else
					{
						p1 = random.Next() % mostFitCount;
						p2 = random.Next() % mostFitCount;
					}

					CombineParents(p1, p2, i);

					for (int j = 0; j < mostFitCount; j++)
					{
						mostFitAvr += accuracies[j];
					}
					mostFitAvr /= mostFitCount;

					mutationRate = 1 - mostFitAvr; 

					MutateTopology(i, mutationRate);
				}

				iterations++;
			}
			sw.Stop();
			if (settings.EnableTiming) Console.WriteLine("Time required: {0}", sw.Elapsed);
		}
		
        /// <summary>
        /// Traines the given network. Same algorithm as in the neural network class.
        /// </summary>
        private float TrainNetwork(ref NetworkTopology topology)
        {
            topology.TrainingAlgorithm.SetSettings(settings);
            int countSinceTrain = 0;
            int maxCountSinceTrain = 40;
            if (settings.TraininPool != null
                && settings.TraininPool > 0)
                maxCountSinceTrain = settings.TraininPool;
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
                    value = ComputeDecision(ref topology);
                    expected = topology.TrainingPreProcessor.ExpectedResult();
                    error = (expected - value) / expected;
                    error = Math.Abs(error);
                    average = average + ((error - average) / (countSinceTrain + 1));
                    countSinceTrain++;
                }
                topology.TrainingAlgorithm.TrainNetwork(ref topology, average);
                if (settings.TrainingIterations != -1) trainingIterations++;
            }
			return 1 - average;
        }

		/// <summary>
		/// Calculates a value. Same algorithm as in the neural network clas.
		/// </summary>
		private float ComputeDecision(ref NetworkTopology topology)
		{
			float val;
			float[] inputPool = topology.PreProcessor.GenerateValues();
			topology.InputLayer.SetInputPool(ref inputPool);
			float[] layerVals = topology.InputLayer.GetValues();
			for (int i = 0; i < topology.HiddenLayers.Length; i++)
			{
				layerVals = topology.HiddenLayers[i].GetValues(layerVals);
			}
			val = topology.OutputLayer.GetValue(layerVals);
			topology.PostProcessor.FinalAction(val);
			return val;
		}

		/// <summary>
		/// Combines two parent topologies into a single child topology
		/// </summary>
		/// <param name="p1">Index of the first parent</param>
		/// <param name="p2">Index of the second parent</param>
		/// <param name="child">The index to place the child topology</param>
		void CombineParents(int p1, int p2, int child)
		{
			List<IHiddenLayer> layers = new List<IHiddenLayer>();

			int length = topologies[p1].HiddenLayers.Length;
			//This makes sure that every single hidden layer has a chance and being added
			if (topologies[p1].HiddenLayers.Length < topologies[p2].HiddenLayers.Length)
				length = topologies[p2].HiddenLayers.Length;

			if (random.NextDouble() < 0.5)
				topologies[child].InputLayer = topologies[p1].InputLayer;
			else
				topologies[child].InputLayer = topologies[p2].InputLayer;

			int parentIndex;
			for (int i = 0; i < length; i++)
			{
				//Determines which parent to take the hidden layer from
				if (random.NextDouble() < 0.5) parentIndex = p1;
				else parentIndex = p2;

				if (topologies[parentIndex].HiddenLayers.Length <= i) continue;
				layers.Add(topologies[parentIndex].HiddenLayers[i]);
			}
			topologies[child].HiddenLayers = layers.ToArray();
		}

		/// <summary>
		/// Mutates a topology
		/// </summary>
		/// <param name="index">The location of the topology</param>
		/// <param name="mutationRate">The rate at which to mutate the topology. This should be
		/// between 0 and 1 inclusively</param>
		void MutateTopology(int index, float mutationRate)
		{
			IHiddenLayer[] layers = topologies[index].HiddenLayers;
			float[] weights;
			for (int i = 0; i < layers.Length; i++)
			{
				for (int j = 0; j < layers[i].Nodes.Length; j++)
				{
					weights = layers[i].Nodes[j].Weights;
					for (int k = 0; k < weights.Length; k++)
					{
						if ((mutationRate - random.NextDouble()) < 0) continue;
						weights[k] += (float)(random.NextDouble() - 0.5);
						if (weights[k] < -1.0f) weights[k] = -1.0f;
						else if (weights[k] > 1.0f) weights[k] = 1.0f;
					}
					layers[i].Nodes[j].Weights = weights;
				}
			}
			topologies[index].HiddenLayers = layers;
		}
	}
}
