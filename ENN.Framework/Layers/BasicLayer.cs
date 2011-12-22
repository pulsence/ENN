using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENN.Framework
{
    public class BasicLayer : IHiddenLayer
    {
        protected INode[] nodes;

        public BasicLayer(INode[] computationalNodes)
        {
            this.nodes = computationalNodes;
        }

        public virtual float[] GetValues(float[] values)
        {
            float[] cValues = new float[nodes.Length];
            for (int i = 0; i < nodes.Length; i++)
            {
                cValues[i] = nodes[i].GetValue(values);
            }
            return cValues;
        }

        public void SetNodes(INode[] nodes)
        {
            this.nodes = nodes;
        }

        public INode[] GetNodes()
        {
            return nodes;
        }

        /// <summary>
        /// Set a specific node as particular node at a specific index. Pass -1 as index to 
        /// set the first empty node as the passed node or the last if none are empty.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="index"></param>
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
    }
}
