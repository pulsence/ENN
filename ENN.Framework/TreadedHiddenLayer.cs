using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENN.Framework
{
    public class ThreadedHiddenLayer : BasicLayer
    {
        public ThreadedHiddenLayer(INode[] nodes)
            : base(nodes) { }

        public override float[] GetValues(float[] values)
        {
            float[] cValues = new float[nodes.Length];
            Parallel.For(0, nodes.Length, i =>
            {
                cValues[i] = nodes[i].GetValue(values);
            });
            return cValues;
        }
    }
}
