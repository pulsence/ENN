using System;
using ENN.Framework;

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

namespace TestUserBinary
{
	[Serializable()]
    class BasicPostProcessor : IPostProcessor
    {
        public Dictionary<string, string> MetaData { get; set; }

        public void FinalAction(float finalValue)
        {
            Console.WriteLine("Final value is {0}", finalValue);
        }

		public override bool Equals(object obj)
		{
			BasicPostProcessor other = (BasicPostProcessor)obj;
			if (other == null) return false;

			return true;
		}
    }
}
