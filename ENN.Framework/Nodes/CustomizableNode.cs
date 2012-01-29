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

namespace ENN.Framework
{
    /// <summary>
    /// A more customizable version of BasicNode. Allows the specification of both the
    /// activation function and combination function.
    /// </summary>
    [Serializable()]
    public class CustomizableNode : BasicNode
    {
        protected CombinationFunction combinationFunction;

        /// <summary>
        /// Sets up the combination function for the GetValue function
        /// </summary>
        public CombinationFunction ComboFunction { set { combinationFunction = value; } }

        public CustomizableNode() : this(CombinationFunctions.sumation, null, null)
        { }

        public CustomizableNode(CombinationFunction combinationFunction,
                                ActivationFunction activationFunction,
                                float[] constants)
            : base (constants, activationFunction)
        {
            this.combinationFunction = combinationFunction;
        }

        /// <summary>
        /// Generates the value for this specific nodes
        /// </summary>
        /// <param name="nodeValues">Values of the nodes in the layer immediatly bellow</param>
        /// <returns>Returns the value calculated</returns>
        public override float GetValue(float[] nodeValues)
        {
            float value = combinationFunction(nodeValues, constants);
            return activationFunction(value);
        }

		public override bool Equals(object obj)
		{
			CustomizableNode other = (CustomizableNode)obj;

			if (other == null) return false;
			if (combinationFunction != other.combinationFunction) return false;
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
