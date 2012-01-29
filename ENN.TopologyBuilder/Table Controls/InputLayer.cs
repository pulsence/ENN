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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ENN.TopologyBuilder
{
	public partial class InputLayer : Layer
	{
		List<int> inputIndexes;

		public InputLayer()
		{
			InitializeComponent();

			inputIndexes = new List<int>();
		}

		public void AddInputIndex(int i)
		{
			if (!inputIndexes.Contains(i)) inputIndexes.Add(i);
		}

		public void RemoveInputIndex(int i)
		{
			if (!inputIndexes.Contains(i)) inputIndexes.Remove(i);
		}

		public override UserControl GetInformation()
		{
			return new InputLayerInformation();
		}
	}
}
