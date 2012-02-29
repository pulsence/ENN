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
using ENN.TopologyBuilder.Models;

namespace ENN.TopologyBuilder.Views
{
	/// <summary>
	/// Meta data control panel for a hidden layer.
	/// </summary>
	public partial class HiddenLayerMetaDataView : BaseMetaDataView
	{
		public HiddenLayerMetaDataView(ref MetaDataPoolModel pool)
			: base(ref pool)
		{
			InitializeComponent();

			excludedKeys.AddRange(new string[] { "nodeCount", "layerName" });

			base.headerLabel.Text = "Hidden Layer Information";
			metaDataPool.HiddenListChanged += DataTypesChanged;

			DataTypesChanged();
		}

		#region View value setters
		public void SetNodeCount(string count)
		{
			nodeCount.Text = "Nodes: " + count;
		}

		public void SetLayerName(string name)
		{
			layerName.Text = name;
		}
		#endregion

		#region Events
		protected override void DataTypesChanged()
		{
			foreach (string type in metaDataPool.GetHiddenLayers())
			{
				if (!dataType.Items.Contains(type))
					dataType.Items.Add(type);
			}
		}
		
		private void layerName_TextChanged(object sender, EventArgs e)
		{
				InvokeInformationChanged("layerName", layerName.Text);
		}
		#endregion
	}
}
