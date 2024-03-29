﻿/*This file is part of ENN.
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

using System.Collections.Generic;

namespace ENN.Framework.Tools
{
	/// <summary>
	/// Represents a raw type in a topology file.
	/// </summary>
    class RawType
    {
		/// <summary>
		/// The type to create.
		/// </summary>
        public string Type;
		/// <summary>
		/// The fields used to build the type
		/// </summary>
        public Dictionary<string, string> Fields;

        public RawType()
        {
            Type = "";
            Fields = new Dictionary<string, string>();
        }
    }
}