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
using ENN.Framework;

namespace ENN.TopologyBuilder.Views
{
	public partial class HiddenLayerView :LayerView
	{
		public HiddenLayerView()
		{
			InitializeComponent();
			nodeLayout.Click += new EventHandler(ThrowClick);
		}

		public override UserControl GetInformation()
		{
			HiddenLayerMetaDataView info = new HiddenLayerMetaDataView(ref metaDataPool);
			info.InformationChanged += SetMetaData;
			info.InformationChanged += LayerNameChange;

			if (metaData.ContainsKey("factory"))
				info.SetFactory(metaData["factory"]);
			if (metaData.ContainsKey("dataType"))
				info.SetDataType(metaData["dataType"]);
			if (metaData.ContainsKey("nodeCount"))
				info.SetNodeCount(metaData["nodeCount"]);
			if (metaData.ContainsKey("layerName"))
				info.SetLayerName(metaData["layerName"]);
			info.SetExtraFields(metaData);

			return info;
		}

		public void AddNode(NodeView node)
		{
			node.Height = nodeLayout.Height - 6;
			nodeLayout.Controls.Add(node);
			AdjustNodes();

			if (metaData.ContainsKey("layerName"))
				node.LayerName = metaData["layerName"];

			if (metaData.ContainsKey("nodeCount"))
			{
				int count = int.Parse(metaData["nodeCount"]) + 1;
				metaData["nodeCount"] = count.ToString();
			}
			else
			{
				metaData.Add("nodeCount", "1");
			}
		}

		#region Events
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

		private void LayerNameChange(string key, string value)
		{
			if (key != "layerName") return;
			
			foreach (Control node in nodeLayout.Controls)
			{
				((NodeView)node).LayerName = value;
			}

		}
		#endregion
	}
}
