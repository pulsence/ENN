using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    public class NetworkTopology
    {
        //fields
        protected IHiddenLayer[] hiddenLayers;
        protected IInputLayer inputLayer;
        protected IOutputLayer outputLayer;

        protected IPreProcessor preProcessor;
        protected IPostProcessor postProcessor;

        //properties
        public IHiddenLayer[] HiddenLayers { get { return hiddenLayers; } set { hiddenLayers = value; } }
        public IInputLayer InputLayer { get { return inputLayer; } set { inputLayer = value; } }
        public IOutputLayer OutputLayer { get { return outputLayer; } set { outputLayer = value; } }

        public IPreProcessor PreProcessor { get { return preProcessor; } set { preProcessor = value; } }
        public IPostProcessor PostProcessor { get { return postProcessor; } set { postProcessor = value; } }

        public NetworkTopology()
        {
            hiddenLayers = null;
            inputLayer = null;
            outputLayer = null;

            preProcessor = null;
            postProcessor = null;
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
    }
}
