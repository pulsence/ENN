using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
