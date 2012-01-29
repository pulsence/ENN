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
    /// Simple input layer. Fits most needs.
    /// </summary>
    [Serializable()]
    public class BasicInputLayer : IInputLayer
    {
        protected float[] inputPool;
        protected int[] valueIndexes;

        /// <summary>
        /// Property for this object's meta data
        /// </summary>
        public Dictionary<string, string> MetaData { get; set; }

        /// <summary>
        /// Indexes in the input pool the retrieve input values from.
        /// </summary>
        public int[] ValueIndexes { set { valueIndexes = value; } }

        /// <summary>
        /// Sets the input pool that the input layer will draw from.
        /// </summary>
        /// <param name="pool">Reference to the pool.</param>
        public void SetInputPool(ref float[] pool)
        {
            inputPool = pool;
        }

        /// <summary>
        /// Retrieves the values out of the input pool. If a value in the ValueIndexes are larger
        /// than the size of the input put the last index in the pool is automaticaly choosen.
        /// </summary>
        /// <returns>Returns the values from the input pool.</returns>
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

		public override bool Equals(object obj)
		{
			BasicInputLayer other = (BasicInputLayer)obj;
			if (other == null) return false;

			if (valueIndexes.Length != other.valueIndexes.Length) return false;
			
			for (int i = 0; i < valueIndexes.Length; i++)
			{
				if (valueIndexes[i] != other.valueIndexes[i]) return false;
			}

			return true;
		}
    }
}
