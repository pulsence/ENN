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

using ENN.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestSuite.Framework
{
    /// <summary>
    ///This is a test class for HillClimbAlgoTest and is intended
    ///to contain all HillClimbAlgoTest Unit Tests
    ///</summary>
	[TestClass()]
	public class HillClimbAlgoTest
	{
		/// <summary>
		///A test for TrainNetwork
		///</summary>
		[TestMethod()]
		public void TrainNetworkTest()
		{
			HillClimbAlgo target = new HillClimbAlgo();
			NetworkTopology topology = null; // TODO: Initialize to an appropriate value
			NetworkTopology topologyExpected = null; // TODO: Initialize to an appropriate value
			float error = 0F; // TODO: Initialize to an appropriate value
			target.TrainNetwork(ref topology, error);
			Assert.AreEqual(topologyExpected, topology);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}
	}
}
