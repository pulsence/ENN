using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENN.Framework;

namespace TestUserBinary
{
    class BasicPreProcessor : IPreProcessor
    {
        public float[] GenerateValues()
        {
            return new float[] { 1, 1, 1, 1 };
        }
    }
}
