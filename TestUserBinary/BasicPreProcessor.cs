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

using ENN.Framework;
using System;
using System.Collections.Generic;

namespace TestUserBinary
{
	/// <summary>
	/// Basic example of a preprocessor.
	/// </summary>
	[Serializable()]
    class BasicPreProcessor : ITrainingPreProcessor
    {
        public Dictionary<string, string> MetaData { get; set; }

		/// <summary>
		/// Values that will be passed to the input layer.
		/// </summary>
		/// <returns>Returns an array of one.</returns>
        public float[] GenerateValues()
        {
            return new float[] { 1, 1, 1, 1 };
        }

		/// <summary>
		/// The value that the network should produce from the Generated values.
		/// </summary>
		/// <returns>Returns 0.6</returns>
        public float ExpectedResult()
        {
            return 0.6f;
        }

		public override bool Equals(object obj)
		{
			BasicPreProcessor other = (BasicPreProcessor)obj;
			if (other == null) return false;

			return true;
		}
    }
}
