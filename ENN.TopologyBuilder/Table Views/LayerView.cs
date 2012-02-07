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
	public partial class LayerView : UserControl
	{
		protected MetaDataPoolModel metaDataPool;
		protected Dictionary<string, string> metaData;
		
		public LayerView()
		{
			InitializeComponent();
			metaDataPool = new MetaDataPoolModel();
			metaData = new Dictionary<string, string>();
		}

		public void SetMetaDataModel(ref MetaDataPoolModel metaDataModel)
		{
			metaDataPool = metaDataModel;
		}

		public virtual UserControl GetInformation()
		{
			return new BaseMetaDataView(ref metaDataPool);
		}

		protected void SetMetaData(string key, string value)
		{
			if (metaData.ContainsKey(key))
				metaData[key] = value;
			else
				metaData.Add(key, value);
		}
	}
}
