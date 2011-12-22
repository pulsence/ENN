using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENN.Framework
{
    public class BasicInputLayer : IInputLayer
    {
        protected float[] inputPool;
        protected int[] valueIndexes;

        public int[] ValueIndexes { set { valueIndexes = value; } }

        public void SetInputPool(ref float[] pool)
        {
            inputPool = pool;
        }

        public float[] GetValues()
        {
            float[] value = new float[valueIndexes.Length];
            int j;
            for(int i=0; i<valueIndexes.Length;i++)
            {
                j = valueIndexes[i];
                if (j >= inputPool.Length) j = inputPool.Length - 1;
                value[i] = inputPool[j];
            }
            return value;
        }
    }
}
