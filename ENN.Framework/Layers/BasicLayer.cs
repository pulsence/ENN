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
    /// Basic hidden layer. Decent for networks with smaller node and hidden layer counts.
    /// </summary>
    [Serializable()]
    public class BasicLayer : IHiddenLayer
    {
        protected INode[] nodes;

        /// <summary>
        /// Property for this object's meta data
        /// </summary>
        public Dictionary<string, string> MetaData { get; set; }

        public BasicLayer(INode[] computationalNodes)
        {
            this.nodes = computationalNodes;
        }

        /// <summary>
        /// Calculates the values of the nodes in the current layer.
        /// </summary>
        /// <param name="values">Values from the layer right before the current layer.</param>
        /// <returns>Returns a float array containing the value produced by the nodes.</returns>
        public virtual float[] GetValues(float[] values)
        {
            float[] cValues = new float[nodes.Length];
            for (int i = 0; i < nodes.Length; i++)
            {
                cValues[i] = nodes[i].GetValue(values);
            }
            return cValues;
        }

        /// <summary>
        /// Gets or Sets the nodes in the layer.
        /// </summary>
        public INode[] Nodes
        {
            get { return nodes; }
            set { this.nodes = value; }
        }

        /// <summary>
        /// Set a specific node as particular node at a specific index. Pass -1 as index to 
        /// set the first empty node as the passed node or the last if none are empty.
        /// </summary>
        /// <param name="node">Node the set</param>
        /// <param name="index">Location to place the node</param>
        public void SetNode(INode node, int index = -1)
        {
            if (nodes == null) return;
            if (index >= nodes.Length) return;
            if (index == -1)
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    if (nodes[i] == null)
                    {
                        nodes[i] = node;
                        i = nodes.Length;
                    }
                }
            }
            else
            {
                nodes[index] = node;
            }
        }

		public override bool Equals(object obj)
		{
			BasicLayer other = (BasicLayer)obj;

			if (other == null) return false;

			if (nodes.Length != other.nodes.Length) return false;
			for (int i = 0; i < nodes.Length; i++)
			{
				if (!nodes[i].Equals(other.nodes[i])) return false;
			}

			return true;
		}
    }
}
