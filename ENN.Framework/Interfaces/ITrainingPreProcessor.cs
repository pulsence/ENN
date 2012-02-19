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
    /// Specification for a preprocessor to be used during training. Extendes IPreProcessor.
    /// </summary>
    public interface ITrainingPreProcessor : IPreProcessor
    {
        /// <summary>
        /// Returns the value that the network should produce. This method is called after
		/// the input values are retrieved.
        /// </summary>
        /// <returns>Returns the value that the neural network should produce
		/// from the given inputs.</returns>
        float ExpectedResult();
    }
}
