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
	public partial class HiddenLayer :Layer
	{
		public HiddenLayer()
		{
			InitializeComponent();
			nodeLayout.Click += new EventHandler(ThrowClick);
		}

		public override UserControl GetInformation()
		{
			return new HiddenLayerInformation();
		}

		public void AddNode(Node node)
		{
			node.Height = nodeLayout.Height - 6;
			nodeLayout.Controls.Add(node);
			AdjustNodes();
		}

		private void ThrowClick(object sender, EventArgs args)
		{
			InvokeOnClick(this, new EventArgs());
		}

		private void AdjustNodes()
		{
			if (nodeLayout.Controls.Count == 0) return;

			int width = (nodeLayout.Width - 6 * nodeLayout.Controls.Count) /
				nodeLayout.Controls.Count;
			foreach (Control node in nodeLayout.Controls)
			{
				node.Width = width;
			}
		}

		private void nodeLayout_Resize(object sender, EventArgs e)
		{
			AdjustNodes();
		}
	}
}
