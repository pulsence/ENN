using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
