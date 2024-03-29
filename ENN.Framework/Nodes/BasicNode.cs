﻿/*This file is part of ENN.
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
    /// Basic implimentation of a node. Note very customizable.
    /// </summary>
    [Serializable()]
    public class BasicNode : INode
    {

        //fields
        protected float[] constants;
	    protected ActivationFunction activationFunction;
        protected Dictionary<string, string> meta;
	    
        //properties

        /// <summary>
        /// Property for this object's meta data
        /// </summary>
        public Dictionary<string, string> MetaData { get { return meta; } set { meta = value; } }

        /// <summary>
        /// Sets the constants array.
        /// </summary>
        public float[] Weights
        {
            get { return constants; }
            set
            {
                constants = value;
                
                string temp = "";
                for (int i = 0; i < constants.Length; i++)
                {
                    temp += constants[i];
                    if (i < constants.Length - 1)
                        temp += ", ";
                }
				meta["combinationWeights"] = temp;
            }
        }

        /// <summary>
        /// Sets the activation function to use.
        /// </summary>
        public ActivationFunction ActivationFunc { set { activationFunction = value; } }

	    public BasicNode() : this(null, null){}
	
	    public BasicNode(float[] constants, ActivationFunction activationFunction){
		    if(constants != null) this.constants = constants;
		
		    if(activationFunction != null){
			    this.activationFunction = activationFunction;
		    }
		    else{
			    activationFunction = delegate(float value)
                {
					if(value <= 0) return 0;
					return 1;
			    };
		    }

			meta = new Dictionary<string, string>();
	    }

	    /// <summary>
	    /// Calculates the value for the node. The value is found by summing the value
        /// of each nodeValue multiplied by its corresponding constant. This value is
        /// then passed to the activation function. The value generated by the
        /// activation function is then returned.
	    /// </summary>
        /// <param name="nodeValues">An array of values from the nodes in the layer below
        /// the layer that this node resides in.</param>
        /// <returns>the value calculated.</returns>
		public virtual float GetValue(float[] nodeValues)
		{
			float value = 0;
			float weight;
			for (int i = 0; i < nodeValues.Length; i++)
			{
				if (i < constants.Length) weight = constants[i];
				else weight = 1.0f;
				value += nodeValues[i] * weight;
			}

			return activationFunction(value);
		}

		public override bool Equals(object obj)
		{
			BasicNode other = (BasicNode)obj;

			if (other == null) return false;
			if (activationFunction != other.activationFunction) return false;

			if (Weights.Length != other.Weights.Length) return false;
			for (int i = 0; i < Weights.Length; i++)
			{
				if (Weights[i] != other.Weights[i]) return false;
			}

			return true;
		}
    }
}
