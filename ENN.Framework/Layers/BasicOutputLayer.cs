using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENN.Framework
{
    public class BasicOutputLayer : IOutputLayer
    {
        public virtual float GetValue(float[] nodeValues)
        {
            return nodeValues.Sum();
        }
    }
}
