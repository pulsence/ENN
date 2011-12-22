using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

/*This file is part of ENN.
* Copyright (C) 2011  Tim Eck II
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
