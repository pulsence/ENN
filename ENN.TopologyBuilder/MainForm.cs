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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ENN.Framework;
using ENN.TopologyBuilder.Views;
using ENN.TopologyBuilder.Models;

namespace ENN.TopologyBuilder
{	
	public partial class MainForm : Form
	{
		//State variables
		bool hasOutput;
		bool hasInput;
		bool hasPreProcessor;
		bool hasPostProcessor;

		LayerView currentSelectedLayer;
		LayerView copyLayer;

		//Models
		MetaDataPoolModel metaData;
		
		public MainForm()
		{
			InitializeComponent();

			hasOutput = false;
			hasInput = false;
			hasPostProcessor = false;
			hasPreProcessor = false;

			currentSelectedLayer = new LayerView();
			copyLayer = new LayerView();

			metaData = new MetaDataPoolModel();

			metaData.SetFactory("standard", new StandLibFactory());
			metaData.SetInputLayer("BasicInputLayer");
			metaData.SetHiddenLayer("BasicLayer");
			metaData.SetHiddenLayer("ThreadedHiddenLayer");
			metaData.SetOutputLayer("BasicOutputLayer");
			metaData.SetNode("BasicNode");
			metaData.SetNode("CustomizableNode");
		}

		#region Copy/Paste/Delete
		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			copyLayer = currentSelectedLayer;
		}

		/// <summary>
		/// Copies the copied layer to the current layer
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void selectedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			currentSelectedLayer = copyLayer;
		}

		/// <summary>
		/// Copies the copied layer as a new layer
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddTableItem(copyLayer);
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Type currentType = currentSelectedLayer.GetType();
			if (currentType == typeof(OutputLayerView))
				hasOutput = false;
			else if (currentType == typeof(InputLayerView))
				hasInput = false;

			topologyDisplay.Controls.Remove(currentSelectedLayer);
			topologyContainer.Panel2.Controls.RemoveAt(0);
		}
		#endregion

		#region Add Layers
		/// <summary>
		/// Adds Hidden Layer
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void hiddenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			HiddenLayerView layer = new HiddenLayerView();
			layer.SetMetaDataModel(ref metaData);
			int location = -1;
			if (hasOutput || hasPostProcessor)
			{
				location = topologyDisplay.Controls.Count;

				if (hasOutput) location--;
				if (hasPostProcessor) location--;
			}
			AddTableItem(layer, location);
		}

		/// <summary>
		/// Adds Output Layer
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void outputToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!hasOutput)
			{
				OutputLayerView layer = new OutputLayerView();
				layer.SetMetaDataModel(ref metaData);
				if (hasPostProcessor)
					AddTableItem(layer,
						topologyDisplay.Controls.Count - 1);
				else
					AddTableItem(layer);
				hasOutput = true;
			}
			else
				MessageBox.Show(
					"An output layer has already been added. Please removed it first");
		}

		/// <summary>
		/// Adds Input Layer
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void inputToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!hasInput)
			{
				hasInput = true;
				InputLayerView layer = new InputLayerView();
				layer.SetMetaDataModel(ref metaData);
				if(hasPreProcessor)
					AddTableItem(layer, 1);
				else
					AddTableItem(layer, 0);
			}
		}

		/// <summary>
		/// Adds a pre processor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void preProcessorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!hasPreProcessor)
			{
				hasPreProcessor = true;
				PreProcessorView layer = new PreProcessorView();
				layer.SetMetaDataModel(ref metaData);
				AddTableItem(layer, 0);
			}
		}

		/// <summary>
		/// Adds a post processor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void postProcessorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!hasPostProcessor)
			{
				hasPostProcessor = true;
				PostProcessorView layer = new PostProcessorView();
				layer.SetMetaDataModel(ref metaData);
				AddTableItem(layer);
			}
		}

		/// <summary>
		/// Adds a node to the current layer
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void nodeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (currentSelectedLayer.GetType() == typeof(HiddenLayerView))
			{
				HiddenLayerView layer = (HiddenLayerView)currentSelectedLayer;
				NodeView node = new NodeView();
				node.SetMetaDataModel(ref metaData);
				node.Click += new EventHandler(ChangeInformation);
				layer.AddNode(node);
			}
			else
				MessageBox.Show(
					"The current selected layer is not a hidden layer. " +
					"Please select a hidden layer and try again");
		}
		#endregion

		#region Helpers
		private void ChangeInformation(object obj, EventArgs args)
		{
			currentSelectedLayer.BorderStyle = BorderStyle.FixedSingle;
			currentSelectedLayer = (LayerView)obj;
			currentSelectedLayer.BorderStyle = BorderStyle.Fixed3D;
			Control info = currentSelectedLayer.GetInformation();
			info.Size = topologyContainer.Panel2.Size;
			if (topologyContainer.Panel2.Controls.Count > 0)
				topologyContainer.Panel2.Controls.RemoveAt(0);
			topologyContainer.Panel2.Controls.Add(info);
		}

		private void AddTableItem(LayerView layer, int row = -1)
		{
			layer.Width = topologyDisplay.Width - 25;
			layer.Click += new EventHandler(ChangeInformation);

			if (row == -1) row = topologyDisplay.Controls.Count;

			topologyDisplay.Controls.Add(layer);
			if (row < topologyDisplay.Controls.Count)
			{
				topologyDisplay.Controls.SetChildIndex(layer, row);
			}
		}
		#endregion

		/// <summary>
		/// Resizes the elements in the display
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void topologyDisplay_Resize(object sender, EventArgs e)
		{
			int width = topologyDisplay.Width - 25;
			foreach (Control control in topologyDisplay.Controls)
			{
				control.Width = width;
			}
		}

		/// <summary>
		/// Opens a form to load user defined binaries
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void userBinariesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoadUserBinaries form = new LoadUserBinaries();
			form.SetMetaDataPool(ref metaData);
			form.Show();
		}
	}
}