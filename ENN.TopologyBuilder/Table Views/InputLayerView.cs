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
	/// The input layer view.
	/// </summary>
	public partial class InputLayerView : LayerView
	{
		public InputLayerView()
		{
			InitializeComponent();
		}

		public override BaseMetaDataView GetInformation()
		{
			InputLayerMetaDataView info = new InputLayerMetaDataView(ref metaDataPool);
			info.InformationChanged += SetMetaData;

			if (metaData.ContainsKey("factory"))
				info.SetFactory(metaData["factory"]);
			if (metaData.ContainsKey("dataType"))
				info.SetDataType(metaData["dataType"]);
			if(metaData.ContainsKey("inputCount"))
				info.SetInputCount(metaData["inputCount"]);
			info.SetExtraFields(metaData);

			return info;
		}

		public int GetInputCount()
		{
			int count = 0;
			if (metaData.ContainsKey("inputCount"))
			{
				int.TryParse(metaData["inputCount"], out count);
			}
			return count;
		}
	}
}
