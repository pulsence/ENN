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
	/// <summary>
	/// The node layer view. This layer is added to hidden layer views.
	/// </summary>
	public partial class NodeView : LayerView
	{
		protected string layerName;

		/// <summary>
		/// Sets the name of the layer that this node belongs to.
		/// </summary>
		public string LayerName
		{
			set
			{
				layerName = value;
				SetMetaData("layer", layerName);
			}
		}

		public NodeView()
		{
			InitializeComponent();
		}

		public override BaseMetaDataView GetInformation()
		{
			NodeMetaDataView info = new NodeMetaDataView(ref metaDataPool);
			info.InformationChanged += SetMetaData;

			if (metaData.ContainsKey("factory"))
				info.SetFactory(metaData["factory"]);
			if (metaData.ContainsKey("dataType"))
				info.SetDataType(metaData["dataType"]);
			if (metaData.ContainsKey("layer"))
				info.SetLayerName(metaData["layer"]);
			if (metaData.ContainsKey("combinationWeights"))
				info.SetCombinationWeights(metaData["combinationWeights"]);
			info.SetExtraFields(metaData);

			return info;
		}
	}
}
