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
using System.IO;
using System.Reflection;
using ENN.Framework;
using ENN.TopologyBuilder.Models;

namespace ENN.TopologyBuilder
{
	public partial class LoadUserBinaries : Form
	{
		MetaDataPoolModel metaDataPool;
		IUserObjectFactory loadedFactory;

		public LoadUserBinaries()
		{
			InitializeComponent();
		}

		public void SetMetaDataPool(ref MetaDataPoolModel pool)
		{
			metaDataPool = pool;
		}

		/// <summary>
		/// Locates a file the contains user created library.
		/// </summary>
		private void findFile_Click(object sender, EventArgs e)
		{
			openBinary.ShowDialog();
			fileLocation.Text = openBinary.FileName;
		}

		/// <summary>
		/// Loads the selected file
		/// </summary>
		private void loadFile_Click(object sender, EventArgs e)
		{
			try
			{
				Assembly assembly = Assembly.LoadFrom(fileLocation.Text);
				Type[] types = assembly.GetTypes();
				string name;
				foreach (Type type in types)
				{
					name = type.Name;	
					if (type.GetInterface("IUserObjectFactory") != null)
					{
						loadedFactory = (IUserObjectFactory)Activator.CreateInstance(type);
						factoryName.Text = name;
					}
					else if (type.GetInterface("IInputLayer") != null)
					{
						input.Items.Add(name);
						input.Text = name;
					}
					else if (type.GetInterface("IHiddenLayer") != null)
					{
						hidden.Items.Add(name);
						hidden.Text = name;
					}
					else if(type.GetInterface("IOutputLayer") != null)
					{
						output.Items.Add(name);
						output.Text = name;
					}
					else if(type.GetInterface("INode") != null)
					{
						node.Items.Add(name);
						node.Text = name;
					}
					else if(type.GetInterface("IPreProcessor") != null)
					{
						preProcessor.Items.Add(name);
						preProcessor.Text = name;
					}
					else if(type.GetInterface("IPostProcessor") != null)
					{
						postProcessor.Items.Add(name);
						postProcessor.Text = name;
					}
				}
			}
			catch (IOException ex)
			{
				MessageBox.Show("The file could not be found and was not loaded");
			}
		}

		/// <summary>
		/// Clears the form of the loaded values
		/// </summary>
		private void clear_Click(object sender, EventArgs e)
		{
			factoryName.Text = "";

			input.Text = "";
			input.Items.Clear();

			hidden.Text = "";
			hidden.Items.Clear();

			output.Text = "";
			output.Items.Clear();

			node.Text = "";
			node.Items.Clear();

			preProcessor.Text = "";
			preProcessor.Items.Clear();

			postProcessor.Text = "";
			postProcessor.Items.Clear();
		}

		/// <summary>
		/// Adds the loaded information into its correct lists
		/// </summary>
		private void addButton_Click(object sender, EventArgs e)
		{
			metaDataPool.SetFactory(factoryName.Text, loadedFactory);

			foreach (string layer in input.Items.Cast<string>())
				metaDataPool.SetInputLayer(layer);
			
			foreach(string layer in hidden.Items.Cast<string>())
				metaDataPool.SetHiddenLayer(layer);

			foreach(string layer in output.Items.Cast<string>())
				metaDataPool.SetOutputLayer(layer);

			foreach(string n in node.Items.Cast<string>())
				metaDataPool.SetNode(n);

			foreach(string processor in preProcessor.Items.Cast<string>())
				metaDataPool.SetPreProcessor(processor);

			foreach(string processor in postProcessor.Items.Cast<string>())
				metaDataPool.SetPostProcessor(processor);

			MessageBox.Show("Information Added");
			clear_Click(null, null);
		}
	}
}
