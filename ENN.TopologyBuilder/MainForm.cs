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
using ENN.Framework.Tools;
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
		bool canSave;

		LayerView currentSelectedLayer;
		LayerView copyLayer;

		//Models
		MetaDataPoolModel metaData;
		
		//Meta Data for the topology
		Dictionary<string, string> topologyMetaData;
		TopologyMetaDataView topologyMetaDataView;

		public MainForm()
		{
			InitializeComponent();

			hasOutput = false;
			hasInput = false;
			hasPostProcessor = false;
			hasPreProcessor = false;
			canSave = false;

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
			metaData.SetTrainingAlgorithm("HillClimbAlgo");

			topologyMetaData = new Dictionary<string, string>();
			topologyMetaDataView = new TopologyMetaDataView(ref metaData);
			topologyMetaDataView.InformationChanged += TopologyMetaDataUpdate;
		}


		#region Copy/Paste/Delete

		/// <summary>
		/// Creates a copy of the currently selected layer.
		/// </summary>
		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(currentSelectedLayer.GetType() != typeof(HiddenLayerView))
			{
				MessageBox.Show("You can only copy and paste hidden layers.");
				return;
			}

			copyLayer = (LayerView)((HiddenLayerView)currentSelectedLayer).Clone();
		}

		/// <summary>
		/// Copies the copied layer to the current layer
		/// </summary>
		private void selectedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddTableItem(copyLayer, GetLayerRow(currentSelectedLayer));
			deleteToolStripMenuItem_Click(null, null);
		}

		/// <summary>
		/// Copies the copied layer as a new layer
		/// </summary>
		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int row = -1;

			if (hasOutput || hasPostProcessor)
			{
				row = topologyDisplay.Controls.Count;
				if (hasOutput) row--;
				if (hasPostProcessor) row--;
			}

			AddTableItem(copyLayer, row);
		}

		/// <summary>
		/// Deletes the currently selected layer,
		/// </summary>
		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Type currentType = currentSelectedLayer.GetType();
			if (currentType == typeof(OutputLayerView))
			{
				hasOutput = false;
				topologyStatus.Items["outputLayerStatus"].Text = "Has Output Layer: False";
			}
			else if (currentType == typeof(InputLayerView))
			{
				hasInput = false;
				topologyStatus.Items["inputLayerStatus"].Text = "Has Input Layer: False";
			}
			else if (currentType == typeof(PreProcessorView))
			{
				hasPreProcessor = false;
				topologyStatus.Items["preProcessorStatus"].Text = "Has Pre Processor: False";
			}
			else if (currentType == typeof(PostProcessorView))
			{
				hasPostProcessor = false;
				topologyStatus.Items["postProcessorStatus"].Text = "Has Post Processor: False";
			}

			topologyDisplay.Controls.Remove(currentSelectedLayer);
			topologyContainer.Panel2.Controls.RemoveAt(0);

			UpdateSaveStatus();
		}
		#endregion

		#region Add Layers
		/// <summary>
		/// Adds a Hidden Layer
		/// </summary>
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
		/// Adds an Output Layer
		/// </summary>
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
				topologyStatus.Items["outputLayerStatus"].Text = "Has Output Layer: True";
			}
			else
				MessageBox.Show(
					"An output layer has already been added. Please removed it first");
		}

		/// <summary>
		/// Adds Input Layer
		/// </summary>
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
				topologyStatus.Items["inputLayerStatus"].Text = "Has Input Layer: True";
			}
		}

		/// <summary>
		/// Adds a pre processor
		/// </summary>
		private void preProcessorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!hasPreProcessor)
			{
				hasPreProcessor = true;
				PreProcessorView layer = new PreProcessorView();
				layer.SetMetaDataModel(ref metaData);
				AddTableItem(layer, 0);
				topologyStatus.Items["preProcessorStatus"].Text = "Has Pre Processor: True";
			}
		}

		/// <summary>
		/// Adds a post processor
		/// </summary>
		private void postProcessorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!hasPostProcessor)
			{
				hasPostProcessor = true;
				PostProcessorView layer = new PostProcessorView();
				layer.SetMetaDataModel(ref metaData);
				AddTableItem(layer);
				topologyStatus.Items["postProcessorStatus"].Text = "Has Post Processor: True";
			}
		}

		/// <summary>
		/// Adds a node to the current layer
		/// </summary>
		private void nodeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (currentSelectedLayer.GetType() == typeof(HiddenLayerView))
			{
				HiddenLayerView layer = (HiddenLayerView)currentSelectedLayer;
				NodeView node = new NodeView();
				node.SetMetaDataModel(ref metaData);
				node.Click += new EventHandler(ChangeInformation);
				layer.AddNode(node);
				UpdateSaveStatus();
			}
			else
				MessageBox.Show(
					"The current selected layer is not a hidden layer. " +
					"Please select a hidden layer and try again");
		}
		#endregion

		#region Helpers
		/// <summary>
		/// Changes the currently selected object and changes the meta data view
		/// that is loaded.
		/// </summary>
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

		/// <summary>
		/// Adds a new item to the topology display.
		/// </summary>
		/// <param name="layer">The layer to add to the display.</param>
		/// <param name="row">The location in the display to add it. If
		/// the value is -1 then the layer is added to the end.</param>
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

			UpdateSaveStatus();
		}

		/// <summary>
		/// Gets the row of the layer in the topologyDisplay.
		/// </summary>
		/// <param name="layer">The layer to find.</param>
		/// <returns>Returns the row that the layer is at. If the layer could not be
		/// found then -1 is returned.</returns>
		private int GetLayerRow(LayerView layer)
		{
			int row = -1;

			if (topologyDisplay.Controls.Contains(layer))
			{
				row = topologyDisplay.Controls.GetChildIndex(layer, false);
			}

			return row;
		}

		/// <summary>
		/// Checks the current topology to see if it can be saved.
		/// </summary>
		private void UpdateSaveStatus()
		{
			if (!hasInput || !hasOutput ||
				!hasPreProcessor || !hasPostProcessor)
			{
				canSave = false;
				topologyStatus.Items["canSaveStatus"].Text = "Can Save: False";
				return;
			}

			if (topologyDisplay.Controls.Count < 5)
			{
				canSave = false;
				topologyStatus.Items["canSaveStatus"].Text = "Can Save: False";
				return;
			}

			HiddenLayerView current;
			HiddenLayerView prior = null;
			List<string> layerNames = new List<string>();
			for (int i = 2; i < topologyDisplay.Controls.Count - 2; i++)
			{
				current = (HiddenLayerView)topologyDisplay.Controls[i];

				//Check to make sure the layer has a name
				if (!current.GetMetaData().ContainsKey("layerName"))
				{
					canSave = false;
					topologyStatus.Items["canSaveStatus"].Text = "Can Save: False";
					return;
				}

				//Check to make sure that the name is unique
				if (layerNames.Contains(current.GetMetaData()["layerName"]))
				{
					canSave = false;
					topologyStatus.Items["canSaveStatus"].Text = "Can Save: False";
					return;
				}
				layerNames.Add(current.GetMetaData()["layerName"]);

				//Check that the layer has nodes added to it.
				if (current.GetNodes().Length == 0)
				{
					canSave = false;
					topologyStatus.Items["canSaveStatus"].Text = "Can Save: False";
					return;
				}

				int weightCount = 0;
				if (prior == null)
				{
					weightCount =
						((InputLayerView)topologyDisplay.Controls[1]).GetInputCount();
				}
				else
				{
					weightCount = prior.GetNodes().Length;
				}

				foreach (LayerView node in current.GetNodes())
				{
					//Check to make sure that the combination weights are set
					if (!node.GetMetaData().ContainsKey("combinationWeights"))
					{
						canSave = false;
						topologyStatus.Items["canSaveStatus"].Text = "Can Save: False";
						return;
					}

					//Check to make sure that there are enough weights specified
					if (weightCount > 
						node.GetMetaData()["combinationWeights"].Split(',').Length)
					{
						canSave = false;
						topologyStatus.Items["canSaveStatus"].Text = "Can Save: False";
						return;
					}
				}

				prior = current;
			}


			canSave = true;
			topologyStatus.Items["canSaveStatus"].Text = "Can Save: True";
		}
		#endregion

		#region Events
		/// <summary>
		/// Resizes the elements in the display
		/// </summary>
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
		private void userBinariesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoadUserBinaries form = new LoadUserBinaries();
			form.SetMetaDataPool(ref metaData);
			form.Show();
		}

		/// <summary>
		/// Saves the current topology in the GUI.
		/// </summary>
		private void saveFileMenuItem_Click(object sender, EventArgs e)
		{
			NetworkTopology topology = new NetworkTopology();
			topology.MetaData = topologyMetaData;
			List<IHiddenLayer> hiddenLayers = new List<IHiddenLayer>();
			foreach (UserControl layer in topologyDisplay.Controls)
			{
				Type layerType = layer.GetType();
				Dictionary<string, string> metaData = ((LayerView)layer).GetMetaData();
				if (layerType == typeof(InputLayerView))
				{
					InputLayerShell inputLayer = new InputLayerShell();
					inputLayer.MetaData = metaData;
					topology.InputLayer = inputLayer;
				}
				else if (layerType == typeof(HiddenLayerView))
				{
					HiddenLayerView view = (HiddenLayerView)layer;
					LayerView[] rawNodes = view.GetNodes();
					INode[] nodes = new INode[rawNodes.Length];
					for (int i = 0; i < rawNodes.Length; i++)
					{
						NodeShell node = new NodeShell();
						node.MetaData = rawNodes[i].GetMetaData();
						nodes[i] = node;
					}
					HiddenLayerShell hiddenLayer = new HiddenLayerShell();
					hiddenLayer.MetaData = metaData;
					hiddenLayer.Nodes = nodes;
					hiddenLayers.Add(hiddenLayer);
				}
				else if (layerType == typeof(OutputLayerView))
				{
					OutputLayerShell outputLayer = new OutputLayerShell();
					outputLayer.MetaData = metaData;
					topology.OutputLayer = outputLayer;
				}
				else if (layerType == typeof(PreProcessorView))
				{
					PreProcessorShell preProcessor = new PreProcessorShell();
					preProcessor.MetaData = metaData;
					topology.PreProcessor = preProcessor;
				}
				else if (layerType == typeof(PostProcessorView))
				{
					PostProcessorShell postProcessor = new PostProcessorShell();
					postProcessor.MetaData = metaData;
					topology.PostProcessor = postProcessor;
				}
				topology.HiddenLayers = hiddenLayers.ToArray();
				saveTopology.ShowDialog();

				if (saveTopology.FileName.EndsWith(".nntc"))
				{
					saveTopology.FileName.Remove(saveTopology.FileName.Length - 1);
				}
				Topology.Save(saveTopology.FileName, topology);
			}

		}

		/// <summary>
		/// Loads a topology from a file into the gui.
		/// </summary>
		private void topologyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openTopology.ShowDialog();
			Dictionary<string, IUserObjectFactory> factories = metaData.GetFactories();
			NetworkSettings settings = new NetworkSettings();
			NetworkTopology topology =
				Topology.Load(openTopology.FileName, ref factories, ref settings,
							openTopology.FileName.EndsWith(".nntc", true, null));

		}
		
		/// <summary>
		/// Starts the timer.
		/// </summary>
		private void MainForm_Load(object sender, EventArgs e)
		{
			saveStatusTimer.Start();
		}

		/// <summary>
		/// Every time 1000ms the topology is checked to see if it is ready to save.
		/// </summary>
		private void saveStatusTimer_Tick(object sender, EventArgs e)
		{
			UpdateSaveStatus();
		}

		/// <summary>
		/// Displays the topology meta data view when clicked.
		/// </summary>
		private void topologyDisplay_Click(object sender, EventArgs e)
		{
			topologyMetaDataView.Size = topologyContainer.Panel2.Size;
			if (topologyContainer.Panel2.Controls.Count > 0)
				topologyContainer.Panel2.Controls.RemoveAt(0);
			topologyContainer.Panel2.Controls.Add(topologyMetaDataView);
		}

		/// <summary>
		/// Updates the topologyMetaData.
		/// </summary>
		private void TopologyMetaDataUpdate(string key, string value)
		{
			if (topologyMetaData.ContainsKey(key))
				topologyMetaData[key] = value;
			else
				topologyMetaData.Add(key, value);
		}
		#endregion
	}
}