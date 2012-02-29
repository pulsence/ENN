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
using ENN.Framework;

namespace ENN.TopologyBuilder.Models
{
	/// <summary>
	/// Shell the be used to output postprocessors to file.
	/// </summary>
	class PostProcessorShell : IPostProcessor
	{
		Dictionary<string, string> meta;

		/// <summary>
		/// Stores the meta data for this particular topology component.
		/// </summary>
		public Dictionary<string, string> MetaData
		{
			get { return meta; }
			set { meta = value; }
		}

		public PostProcessorShell()
		{
			meta = new Dictionary<string, string>();
		}

		/// <summary>
		/// Method stub, do not use.
		/// </summary>
		public void FinalAction(float finalValue) { }
	}
}
