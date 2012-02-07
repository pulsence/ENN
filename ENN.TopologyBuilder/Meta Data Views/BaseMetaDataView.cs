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
	public delegate void InformationChangedHandler(string key, string value);

	public partial class BaseMetaDataView : UserControl
	{
		protected MetaDataPoolModel metaDataPool;
		
		public event InformationChangedHandler InformationChanged; 

		public BaseMetaDataView(ref MetaDataPoolModel pool)
		{
			InitializeComponent();
			metaDataPool = pool;
		}

		public void SetHeader(string header)
		{
			headerLabel.Text = header;
		}

		protected void InvokeInformationChanged(string key, string value)
		{
			if (InformationChanged != null)
				InformationChanged(key, value);
		}

		public virtual void FactoryChanged() { }

		public virtual void DataTypesChanged() { }
	}
}
