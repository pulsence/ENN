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

namespace ENN.TopologyBuilder
{
	public delegate void FactoryChangedEventHandler();
	public delegate void ListChangedEventHandler();

	public class CustomEvents 
	{
		public event FactoryChangedEventHandler FactoryListChanged;
		public event ListChangedEventHandler InputListChanged;
		public event ListChangedEventHandler OutputListChanged;
		public event ListChangedEventHandler HiddenListChanged;
		public event ListChangedEventHandler NodeListChanged;
		public event ListChangedEventHandler PreProcessorListChanged;
		public event ListChangedEventHandler PostProcessorListChanged;

		public void InvokeAllEvents()
		{
			InvokeFactoryChanged();
			InvokeInputChanged();
			InvokeHiddenChanged();
			InvokeOutputChanged();
			InvokeNodeChanged();
			InvokePreProcessorChanged();
			InvokePostProcessorChanged();
		}

		public void InvokeFactoryChanged()
		{
			if (FactoryListChanged != null)
				FactoryListChanged();
		}

		public void InvokeInputChanged()
		{
			if (InputListChanged != null)
				InputListChanged();
		}

		public void InvokeHiddenChanged()
		{
			if (HiddenListChanged != null)
				HiddenListChanged();
		}

		public void InvokeOutputChanged()
		{
			if (OutputListChanged != null)
				OutputListChanged();
		}

		public void InvokeNodeChanged()
		{
			if (NodeListChanged != null)
				NodeListChanged();
		}

		public void InvokePreProcessorChanged()
		{
			if (PreProcessorListChanged != null)
				PreProcessorListChanged();
		}

		public void InvokePostProcessorChanged()
		{
			if (PostProcessorListChanged != null)
				PostProcessorListChanged();
		}
	}
}
