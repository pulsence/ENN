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
		
		/// <summary>
		/// Raised when every the list of factories is changed.
		/// </summary>
		public event MetaDataPoolChangedEventHandler FactoryListChanged;

		/// <summary>
		/// Raised when ever the list of input layer data types is changed.
		/// </summary>
		public event MetaDataPoolChangedEventHandler InputListChanged;

		/// <summary>
		/// Raised when ever the list of ouput layer data types is changed. 
		/// </summary>
		public event MetaDataPoolChangedEventHandler OutputListChanged;

		/// <summary>
		/// Raised when ever the list of hidden layer data types is changed.
		/// </summary>
		public event MetaDataPoolChangedEventHandler HiddenListChanged;

		/// <summary>
		/// Raised when ever the list of node data types is changed.
		/// </summary>
		public event MetaDataPoolChangedEventHandler NodeListChanged;

		/// <summary>
		/// Raised when ever the list of preprocessor data types is changed.
		/// </summary>
		public event MetaDataPoolChangedEventHandler PreProcessorListChanged;

		/// <summary>
		/// Raised when ever the list of postprocessor data types is changed.
		/// </summary>
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

		/// <summary>
		/// Addes an object factory to the list.
		/// </summary>
		/// <param name="name">The name that the factory should be added under.</param>
		/// <param name="factory">The object to store.</param>
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

		/// <summary>
		/// Returns all of the factories currently loaded.
		/// </summary>
		/// <returns>Returns the currently loaded object factories.</returns>
		public Dictionary<string, IUserObjectFactory> GetFactories()
		{
			return objectFactory;
		}

		/// <summary>
		/// Adds an input layer data type.
		/// </summary>
		/// <param name="name">Input layer data type.</param>
		public void SetInputLayer(string name)
		{
			if (inputLayers.Contains(name)) return;

			inputLayers.Add(name);
			if (InputListChanged != null)
				InputListChanged();
		}

		/// <summary>
		/// Retrieves the list of input layer data types.
		/// </summary>
		/// <returns>The list of input layer data types.</returns>
		public List<string> GetInputLayers()
		{
			return inputLayers;
		}

		/// <summary>
		/// Adds a hidden layer data type.
		/// </summary>
		/// <param name="name">Hidden layer data type.</param>
		public void SetHiddenLayer(string name)
		{
			if (hiddenLayers.Contains(name)) return;

			hiddenLayers.Add(name);
			if (HiddenListChanged != null)
				HiddenListChanged();
		}

		/// <summary>
		/// Retrieves the list of hidden layer data types.
		/// </summary>
		/// <returns>The list of hidden layer data types.</returns>
		public List<string> GetHiddenLayers()
		{
			return hiddenLayers;
		}

		/// <summary>
		/// Adds an output layer data type.
		/// </summary>
		/// <param name="name">Output layer data type.</param>
		public void SetOutputLayer(string name)
		{
			if (outputLayers.Contains(name)) return;

			outputLayers.Add(name);
			if (OutputListChanged != null)
				OutputListChanged();
		}

		/// <summary>
		/// Retrieves the list of output layer data types.
		/// </summary>
		/// <returns>The list of input output data types.</returns>
		public List<string> GetOutputLayers()
		{
			return outputLayers;
		}

		/// <summary>
		/// Adds a node data type.
		/// </summary>
		/// <param name="name">Node data type.</param>
		public void SetNode(string name)
		{
			if (nodes.Contains(name)) return;

			nodes.Add(name);
			if (NodeListChanged != null)
				NodeListChanged();
		}

		/// <summary>
		/// Retrieves the list of node data types.
		/// </summary>
		/// <returns>The list of node data types.</returns>
		public List<string> GetNodes()
		{
			return nodes;
		}

		/// <summary>
		/// Adds a preprocessor data type.
		/// </summary>
		/// <param name="name">Preprocessor data type.</param>
		public void SetPreProcessor(string name)
		{
			if (preProcessors.Contains(name)) return;

			preProcessors.Add(name);
			if (PreProcessorListChanged != null)
				PreProcessorListChanged();
		}

		/// <summary>
		/// Retrieves the list of preprocessor data types.
		/// </summary>
		/// <returns>The list of preprocessor data types.</returns>
		public List<string> GetPreProcessors()
		{
			return preProcessors;
		}

		/// <summary>
		/// Adds a postprocessor data type.
		/// </summary>
		/// <param name="name">Postprocessor data type.</param>
		public void SetPostProcessor(string name)
		{
			if (postProcessors.Contains(name)) return;

			postProcessors.Add(name);
			if (PostProcessorListChanged != null)
				PostProcessorListChanged();
		}

		/// <summary>
		/// Retrieves the list of postprocessor data types.
		/// </summary>
		/// <returns>The list of postprocessor data types.</returns>
		public List<string> GetPostProcessors()
		{
			return postProcessors;
		}
	}
}