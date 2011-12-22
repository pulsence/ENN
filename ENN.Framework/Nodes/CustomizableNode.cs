using System;
using System.Collections.Generic;

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
    }
}
