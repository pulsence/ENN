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

	/// <summary>
	/// Base class used to define meta data views
	/// </summary>
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

		/// <summary>
		/// Raises the information changed event.
		/// </summary>
		/// <param name="key">The meta data key</param>
		/// <param name="value">The value for the key</param>
		protected void InvokeInformationChanged(string key, string value)
		{
			if (InformationChanged != null)
				InformationChanged(key, value);
		}

		#region View Value Setters

		/// <summary>
		/// Sets the header label.
		/// </summary>
		/// <param name="header">Text for the header.</param>
		public void SetHeader(string header)
		{
			headerLabel.Text = header;
		}

		/// <summary>
		/// Sets the selected factory.
		/// </summary>
		/// <param name="factoryName">The value to set the factory.</param>
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

		/// <summary>
		/// Sets the selected data type
		/// </summary>
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

		/// <summary>
		/// Adds key-value pairs to the extra field text box
		/// </summary>
		/// <param name="fields">Key value pairs to add</param>
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

		/// <summary>
		/// Detirmines is the key is an exluded key.
		/// </summary>
		/// <param name="key">Key to check.</param>
		/// <returns>Returns true if the key is in the exluded list and
		/// false if it is not.</returns>
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

		/// <summary>
		/// Updates the factory list when the event is raised.
		/// </summary>
		protected void FactoryChanged()
		{
			foreach (KeyValuePair<string, IUserObjectFactory> key in metaDataPool.GetFactories())
			{
				if (!factory.Items.Contains(key.Key))
					factory.Items.Add(key.Key);
			}
		}

		/// <summary>
		/// Needs to be overriden to update the list of data types based upon the data type
		/// the view represents.
		/// </summary>
		protected virtual void DataTypesChanged() { }

		/// <summary>
		/// Updates the factory meta data when ever the factory selection changes.
		/// </summary>
		private void factory_SelectedIndexChanged(object sender, EventArgs e)
		{
			InvokeInformationChanged("factory", (string)factory.SelectedItem);
		}

		/// <summary>
		/// Updates the data type meta data when ever the dataType selection is changed.
		/// </summary>
		private void dataType_SelectedIndexChanged(object sender, EventArgs e)
		{
			InvokeInformationChanged("dataType", (string)dataType.SelectedItem);
		}
		#endregion
	}
}