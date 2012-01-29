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
using System.Linq;
using System.Collections.Generic;

namespace ENN.Framework
{
    /// <summary>
    /// Basic output layer. Simple returns the sum of node values.
    /// </summary>
    [Serializable()]
    public class BasicOutputLayer : IOutputLayer
    {
        /// <summary>
        /// Property to set this objects meta data
        /// </summary>
        public Dictionary<string, string> MetaData { get; set; }

        /// <summary>
        /// Sums the node values.
        /// </summary>
        /// <param name="nodeValues">Last hidden layers node values.</param>
        /// <returns>Returns the sumations of the passed values.</returns>
        public virtual float GetValue(float[] nodeValues)
        {
            return nodeValues.Sum();
        }

		public override bool Equals(object obj)
		{
			BasicOutputLayer other = (BasicOutputLayer)obj;

			if (other == null) return false;
			return true;
		}
    }
}
