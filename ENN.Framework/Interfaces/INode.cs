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

namespace ENN.Framework
{
    /// <summary>
    /// Specifies the node which will be used in the hidden layers.
    /// </summary>
    public interface INode : IMetaData
    {
        /// <summary>
        /// Generates an array of floats from the values of the nodes in the
        /// layer below the current layer.
        /// </summary>
        /// <param name="nodeValues">Values from the layer below the current layer.</param>
        /// <returns>Returns the value of the node.</returns>
        float GetValue(float[] nodeValues);

        /// <summary>
        /// Gets and sets the weights for the node
        /// </summary>
        float[] Weights { get; set; }
    }
}
