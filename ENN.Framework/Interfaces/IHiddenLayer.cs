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
    /// Specifies the hidden layer
    /// </summary>
    public interface IHiddenLayer : IMetaData
    {
        /// <summary>
        /// Generates the values of the nodes in the layer.
        /// </summary>
        /// <param name="values">Values from the layer below the current layer.</param>
        /// <returns>Returns an array of node value from the layer.</returns>
        float[] GetValues(float[] values);

        /// <summary>
        /// Property to get or set the nodes in the layer.
        /// </summary>
        INode[] Nodes { get; set; }

        /// <summary>
        /// Sets the node at the specified index.
        /// </summary>
        /// <param name="node">Node to be added to the layer.</param>
        /// <param name="index">Location to add the node.</param>
        void SetNode(INode node, int index);
    }
}