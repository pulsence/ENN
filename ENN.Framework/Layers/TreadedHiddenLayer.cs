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
using System.Threading.Tasks;

namespace ENN.Framework
{
    /// <summary>
    /// Inherents from BasicLayer. The largest difference is that the calculation of node values are
    /// done in a threaded loop using the Task Parrel Library in .Net. Depending upon the topology and
    /// system this can decrease execution time greatly.
    /// </summary>
    [Serializable()]
    public class ThreadedHiddenLayer : BasicLayer
    {
        public ThreadedHiddenLayer(INode[] nodes)
            : base(nodes) { }

        /// <summary>
        /// Calculates each node value using a parralel for loop.
        /// </summary>
        /// <param name="values">Values from the hidden layer below.</param>
        /// <returns>Returns an array of float values which represent the node values</returns>
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