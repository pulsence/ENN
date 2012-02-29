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
	/// Based class used to define layer views that can be added to the gui.
	/// </summary>
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

		/// <summary>
		/// Sets the MetaDataPoolModel that should be used.
		/// </summary>
		/// <param name="metaDataModel">Reference to the pool to draw information from.</param>
		public void SetMetaDataModel(ref MetaDataPoolModel metaDataModel)
		{
			metaDataPool = metaDataModel;
		}

		/// <summary>
		/// Returns a view that is loaded in the left side bar to customize the meta
		/// data for the current layer.
		/// </summary>
		/// <returns>The view to load in the side bar.</returns>
		public virtual BaseMetaDataView GetInformation()
		{
			return new BaseMetaDataView(ref metaDataPool);
		}

		/// <summary>
		/// Gets the meta data that was set for this layer.
		/// </summary>
		/// <returns>The current meta data.</returns>
		public Dictionary<string, string> GetMetaData()
		{
			return metaData;
		}

		/// <summary>
		/// Used to handle information changed events.
		/// </summary>
		/// <param name="key">Meta dat key to modify.</param>
		/// <param name="value">Value for the key.</param>
		protected void SetMetaData(string key, string value)
		{
			if (metaData.ContainsKey(key))
				metaData[key] = value;
			else
				metaData.Add(key, value);
		}
	}
}
