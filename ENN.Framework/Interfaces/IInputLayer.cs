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
    /// Outlines the input layer.
    /// </summary>
    public interface IInputLayer : IMetaData
    {
        /// <summary>
        /// Sets the pool of values to draw from
        /// </summary>
        /// <param name="pool">Reference to the input pool.</param>
        void SetInputPool(ref float[] pool);

        /// <summary>
        /// Gets the values from the input pool.
        /// </summary>
        /// <returns>Returns an array of float values from the input pool.</returns>
        float[] GetValues();
    }
}