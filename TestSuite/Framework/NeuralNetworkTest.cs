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
    ///This is a test class for NeuralNetworkTest and is intended
    ///to contain all NeuralNetworkTest Unit Tests
    ///</summary>
	[TestClass()]
	public class NeuralNetworkTest
	{
		/// <summary>
		///A test for NeuralNetwork Constructor
		///</summary>
		[TestMethod()]
		public void NeuralNetworkConstructorTest()
		{
			NetworkTopology topology = null; // TODO: Initialize to an appropriate value
			NetworkSettings settings = null; // TODO: Initialize to an appropriate value
			NeuralNetwork target = new NeuralNetwork(topology, settings);
			Assert.Inconclusive("TODO: Implement code to verify target");
		}

		/// <summary>
		///A test for ComputeDecision
		///</summary>
		[TestMethod()]
		public void ComputeDecisionTest()
		{
			float expected = 0F; // TODO: Initialize to an appropriate value
			float actual = 0f;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for StartNetwork
		///</summary>
		[TestMethod()]
		public void StartNetworkTest()
		{
			NetworkTopology topology = null; // TODO: Initialize to an appropriate value
			NetworkSettings settings = null; // TODO: Initialize to an appropriate value
			NeuralNetwork target = new NeuralNetwork(topology, settings); // TODO: Initialize to an appropriate value
			object state = null; // TODO: Initialize to an appropriate value
			target.StartNetwork(state);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for TrainNetwork
		///</summary>
		[TestMethod()]
		public void TrainNetworkTest()
		{
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}
	}
}
