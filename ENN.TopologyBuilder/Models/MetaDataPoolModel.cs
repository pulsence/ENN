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
using System.Linq;
using System.Text;
using ENN.Framework;

namespace ENN.TopologyBuilder.Models
{
	/// <summary>
	/// Delegate used when ever a pool of meta data is modified.
	/// </summary>
	public delegate void MetaDataPoolChangedEventHandler();


	/// <summary>
	/// This class is to be used to story the base information which can be used to
	/// build the meta data information for the topology. In addition it contains
	/// events to notify when the pool has been modified.
	/// </summary>
	public class MetaDataPoolModel
	{
		//Pools
		Dictionary<string, IUserObjectFactory> objectFactory;
		List<string> inputLayers;
		List<string> hiddenLayers;
		List<string> outputLayers;
		List<string> preProcessors;
		List<string> postProcessors;
		List<string> nodes;

		//Events
		public event MetaDataPoolChangedEventHandler FactoryListChanged;
		public event MetaDataPoolChangedEventHandler InputListChanged;
		public event MetaDataPoolChangedEventHandler OutputListChanged;
		public event MetaDataPoolChangedEventHandler HiddenListChanged;
		public event MetaDataPoolChangedEventHandler NodeListChanged;
		public event MetaDataPoolChangedEventHandler PreProcessorListChanged;
		public event MetaDataPoolChangedEventHandler PostProcessorListChanged;

		public MetaDataPoolModel()
		{
			objectFactory = new Dictionary<string, IUserObjectFactory>();
			inputLayers = new List<string>();
			hiddenLayers = new List<string>();
			outputLayers = new List<string>();
			preProcessors = new List<string>();
			postProcessors = new List<string>();
			nodes = new List<string>();
			
		}

		public void SetFactory(string name, IUserObjectFactory factory)
		{
			if (objectFactory.ContainsKey(name))
				objectFactory[name] = factory;
			else
				objectFactory.Add(name, factory);

			if (FactoryListChanged != null)
				FactoryListChanged();
		}

		/// <summary>
		/// Retrieves the IUserObjectFactory with the corrisponding name
		/// </summary>
		/// <param name="name">Name of the factory to get</param>
		/// <returns>Returns the factory. If the factory is not found null is returned.</returns>
		public IUserObjectFactory GetFactory(string name)
		{
			if (objectFactory.ContainsKey(name))
				return objectFactory[name];
			return null;
		}

		public Dictionary<string, IUserObjectFactory> GetFactories()
		{
			return objectFactory;
		}

		public void SetInputLayer(string name)
		{
			if (inputLayers.Contains(name)) return;

			inputLayers.Add(name);
			if (InputListChanged != null)
				InputListChanged();
		}

		public List<string> GetInputLayers()
		{
			return inputLayers;
		}

		public void SetHiddenLayer(string name)
		{
			if (hiddenLayers.Contains(name)) return;

			hiddenLayers.Add(name);
			if (HiddenListChanged != null)
				HiddenListChanged();
		}

		public List<string> GetHiddenLayers()
		{
			return hiddenLayers;
		}

		public void SetOutputLayer(string name)
		{
			if (outputLayers.Contains(name)) return;

			outputLayers.Add(name);
			if (OutputListChanged != null)
				OutputListChanged();
		}

		public List<string> GetOutputLayers()
		{
			return outputLayers;
		}

		public void SetNode(string name)
		{
			if (nodes.Contains(name)) return;

			nodes.Add(name);
			if (NodeListChanged != null)
				NodeListChanged();
		}

		public List<string> GetNodes()
		{
			return nodes;
		}

		public void SetPreProcessor(string name)
		{
			if (preProcessors.Contains(name)) return;

			preProcessors.Add(name);
			if (PreProcessorListChanged != null)
				PreProcessorListChanged();
		}

		public List<string> GetPreProcessors()
		{
			return preProcessors;
		}

		public void SetPostProcessor(string name)
		{
			if (postProcessors.Contains(name)) return;

			postProcessors.Add(name);
			if (PostProcessorListChanged != null)
				PostProcessorListChanged();
		}

		public List<string> GetPostProcessors()
		{
			return postProcessors;
		}
	}
}
