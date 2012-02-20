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


		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		/// <summary>
		///A test for HillClimbAlgo Constructor
		///</summary>
		[TestMethod()]
		public void HillClimbAlgoConstructorTest()
		{
			HillClimbAlgo target = new HillClimbAlgo();
			Assert.Inconclusive("TODO: Implement code to verify target");
		}

		/// <summary>
		///A test for Equals
		///</summary>
		[TestMethod()]
		public void EqualsTest()
		{
			HillClimbAlgo target = new HillClimbAlgo(); // TODO: Initialize to an appropriate value
			object obj = null; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.Equals(obj);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for SetSettings
		///</summary>
		[TestMethod()]
		public void SetSettingsTest()
		{
			HillClimbAlgo target = new HillClimbAlgo(); // TODO: Initialize to an appropriate value
			NetworkSettings settings = null; // TODO: Initialize to an appropriate value
			target.SetSettings(settings);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for TrainNetwork
		///</summary>
		[TestMethod()]
		public void TrainNetworkTest()
		{
			HillClimbAlgo target = new HillClimbAlgo(); // TODO: Initialize to an appropriate value
			NetworkTopology topology = null; // TODO: Initialize to an appropriate value
			NetworkTopology topologyExpected = null; // TODO: Initialize to an appropriate value
			float error = 0F; // TODO: Initialize to an appropriate value
			target.TrainNetwork(ref topology, error);
			Assert.AreEqual(topologyExpected, topology);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}
	}
}
