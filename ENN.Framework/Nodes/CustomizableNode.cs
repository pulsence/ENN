using System;
using System.Collections.Generic;

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
