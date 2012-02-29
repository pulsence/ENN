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
using ENN.TopologyBuilder.Models;

namespace ENN.TopologyBuilder.Views
{
	public partial class TopologyMetaDataView : BaseMetaDataView
	{
		public TopologyMetaDataView(ref MetaDataPoolModel pool)
			: base(ref pool)
		{
			InitializeComponent();

			excludedKeys.AddRange(
				new string[] { "name", "algorithmFactory", "trainingAlgorithm" });

			base.headerLabel.Text = "Topology Information";
			metaDataPool.TrainingAlgorithmsListChanged += DataTypesChanged;

			DataTypesChanged();
		}

		protected override void DataTypesChanged()
		{
			foreach (string type in metaDataPool.GetTrainingAlgorithms())
			{
				if (!dataType.Items.Contains(type))
					dataType.Items.Add(type);
			}
		}

		/// <summary>
		/// Updates the factory to be used to load the training algorithm.
		/// </summary>
		protected override void  factory_SelectedIndexChanged(object sender, EventArgs e)
		{
			InvokeInformationChanged("algorithmFactory", (string)factory.SelectedItem);
		}

		/// <summary>
		/// Updates the trainingAlgorithm meta data when ever a new algorithm is selected.
		/// </summary>
		protected override void dataType_SelectedIndexChanged(object sender, EventArgs e)
		{
			InvokeInformationChanged("trainingAlgorithm", (string)dataType.SelectedItem);
		}
	}
}
