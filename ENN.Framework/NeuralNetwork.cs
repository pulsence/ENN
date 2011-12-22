using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ENN.Framework
{
    public class NeuralNetwork
    {
        protected NetworkTopology topology;
        protected NetworkSettings settings;

        public NeuralNetwork(NetworkTopology topology, NetworkSettings settings)
        {
            this.topology = topology;
            this.settings = settings;
        }

        public void StartNetwork()
        {
            ComputeDecision();
        }

        public void StartNetwork(Object state)
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

        void ComputeDecision()
        {
            float[] inputPool = topology.PreProcessor.GenerateValues();
            topology.InputLayer.SetInputPool(ref inputPool);
            float[] layerVals = topology.InputLayer.GetValues();
            for (int i = 0; i < topology.HiddenLayers.Length; i++)
            {
                layerVals = topology.HiddenLayers[i].GetValues(layerVals);
            }
            topology.PostProcessor.FinalAction(topology.OutputLayer.GetValue(layerVals));
        }

        void TrainNetwork()
        {
            return;
        }
    }
}
