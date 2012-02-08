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
		//keys that should not be added to extraFields
		protected List<string> excludedKeys;

		public event InformationChangedHandler InformationChanged;

		public BaseMetaDataView()
		{
			InitializeComponent();

			excludedKeys = new List<string>();
			excludedKeys.AddRange(new string[] { "dataType", "factory" });
		}

		public BaseMetaDataView(ref MetaDataPoolModel pool)
			: this()
		{
			metaDataPool = pool;
			metaDataPool.FactoryListChanged += FactoryChanged;
			FactoryChanged();
		}

		protected void InvokeInformationChanged(string key, string value)
		{
			if (InformationChanged != null)
				InformationChanged(key, value);
		}

		#region View Value Setters
		public void SetHeader(string header)
		{
			headerLabel.Text = header;
		}

		public void SetFactory(string factoryName)
		{
			foreach (string item in factory.Items)
			{
				if (item == factoryName)
				{
					factory.SelectedItem = item;
					break;
				}
			}
		}

		public void SetDataType(string dataTypeName)
		{
			foreach (string item in dataType.Items)
			{
				if (item == dataTypeName)
				{
					dataType.SelectedItem = item;
					break;
				}
			}
		}

		public void SetExtraFields(Dictionary<string, string> fields)
		{
			List<string> lines = new List<string>();
			foreach (KeyValuePair<string, string> value in fields)
			{
				if (!isExcludedKey(value.Key))
					lines.Add(value.Key + ":" + value.Value);
			}
			extraFields.Lines = lines.ToArray();
		}

		private bool isExcludedKey(string key)
		{
			foreach (string badKey in excludedKeys)
			{
				if (key == badKey) return true;
			}
			return false;
		}
		#endregion

		#region Events
		protected void FactoryChanged()
		{
			foreach (KeyValuePair<string, IUserObjectFactory> key in metaDataPool.GetFactories())
			{
				if (!factory.Items.Contains(key.Key))
					factory.Items.Add(key.Key);
			}
		}

		protected virtual void DataTypesChanged() { }

		private void factory_SelectedIndexChanged(object sender, EventArgs e)
		{
			InvokeInformationChanged("factory", (string)factory.SelectedItem);
		}

		private void dataType_SelectedIndexChanged(object sender, EventArgs e)
		{
			InvokeInformationChanged("dataType", (string)dataType.SelectedItem);
		}
		#endregion
	}
}
