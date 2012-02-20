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
using System.Collections.Generic;

namespace TestSuite.Framework
{
    
    
    /// <summary>
    ///This is a test class for NetworkSettingsTest and is intended
    ///to contain all NetworkSettingsTest Unit Tests
    ///</summary>
	[TestClass()]
	public class NetworkSettingsTest
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
		///A test for NetworkSettings Constructor
		///</summary>
		[TestMethod()]
		public void NetworkSettingsConstructorTest()
		{
			NetworkSettings target = new NetworkSettings();
			Assert.Inconclusive("TODO: Implement code to verify target");
		}

		/// <summary>
		///A test for Equals
		///</summary>
		[TestMethod()]
		public void EqualsTest()
		{
			NetworkSettings target = new NetworkSettings(); // TODO: Initialize to an appropriate value
			object obj = null; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.Equals(obj);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for ToString
		///</summary>
		[TestMethod()]
		public void ToStringTest()
		{
			NetworkSettings target = new NetworkSettings(); // TODO: Initialize to an appropriate value
			string expected = string.Empty; // TODO: Initialize to an appropriate value
			string actual;
			actual = target.ToString();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for DefaultFactory
		///</summary>
		[TestMethod()]
		public void DefaultFactoryTest()
		{
			NetworkSettings target = new NetworkSettings(); // TODO: Initialize to an appropriate value
			string expected = string.Empty; // TODO: Initialize to an appropriate value
			string actual;
			target.DefaultFactory = expected;
			actual = target.DefaultFactory;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for DefaultHiddenLayer
		///</summary>
		[TestMethod()]
		public void DefaultHiddenLayerTest()
		{
			NetworkSettings target = new NetworkSettings(); // TODO: Initialize to an appropriate value
			string expected = string.Empty; // TODO: Initialize to an appropriate value
			string actual;
			target.DefaultHiddenLayer = expected;
			actual = target.DefaultHiddenLayer;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for DefaultInputLayer
		///</summary>
		[TestMethod()]
		public void DefaultInputLayerTest()
		{
			NetworkSettings target = new NetworkSettings(); // TODO: Initialize to an appropriate value
			string expected = string.Empty; // TODO: Initialize to an appropriate value
			string actual;
			target.DefaultInputLayer = expected;
			actual = target.DefaultInputLayer;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for DefaultNode
		///</summary>
		[TestMethod()]
		public void DefaultNodeTest()
		{
			NetworkSettings target = new NetworkSettings(); // TODO: Initialize to an appropriate value
			string expected = string.Empty; // TODO: Initialize to an appropriate value
			string actual;
			target.DefaultNode = expected;
			actual = target.DefaultNode;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for DefaultOutputLayer
		///</summary>
		[TestMethod()]
		public void DefaultOutputLayerTest()
		{
			NetworkSettings target = new NetworkSettings(); // TODO: Initialize to an appropriate value
			string expected = string.Empty; // TODO: Initialize to an appropriate value
			string actual;
			target.DefaultOutputLayer = expected;
			actual = target.DefaultOutputLayer;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for EnableTiming
		///</summary>
		[TestMethod()]
		public void EnableTimingTest()
		{
			NetworkSettings target = new NetworkSettings(); // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			target.EnableTiming = expected;
			actual = target.EnableTiming;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Mode
		///</summary>
		[TestMethod()]
		public void ModeTest()
		{
			NetworkSettings target = new NetworkSettings(); // TODO: Initialize to an appropriate value
			NetworkMode expected = new NetworkMode(); // TODO: Initialize to an appropriate value
			NetworkMode actual;
			target.Mode = expected;
			actual = target.Mode;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for NetworkType
		///</summary>
		[TestMethod()]
		public void NetworkTypeTest()
		{
			NetworkSettings target = new NetworkSettings(); // TODO: Initialize to an appropriate value
			NetworkType expected = new NetworkType(); // TODO: Initialize to an appropriate value
			NetworkType actual;
			target.NetworkType = expected;
			actual = target.NetworkType;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Other
		///</summary>
		[TestMethod()]
		public void OtherTest()
		{
			NetworkSettings target = new NetworkSettings(); // TODO: Initialize to an appropriate value
			Dictionary<string, string> expected = null; // TODO: Initialize to an appropriate value
			Dictionary<string, string> actual;
			target.Other = expected;
			actual = target.Other;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for TraininPool
		///</summary>
		[TestMethod()]
		public void TraininPoolTest()
		{
			NetworkSettings target = new NetworkSettings(); // TODO: Initialize to an appropriate value
			int expected = 0; // TODO: Initialize to an appropriate value
			int actual;
			target.TraininPool = expected;
			actual = target.TraininPool;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for TrainingAccuracy
		///</summary>
		[TestMethod()]
		public void TrainingAccuracyTest()
		{
			NetworkSettings target = new NetworkSettings(); // TODO: Initialize to an appropriate value
			float expected = 0F; // TODO: Initialize to an appropriate value
			float actual;
			target.TrainingAccuracy = expected;
			actual = target.TrainingAccuracy;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for TrainingIterations
		///</summary>
		[TestMethod()]
		public void TrainingIterationsTest()
		{
			NetworkSettings target = new NetworkSettings(); // TODO: Initialize to an appropriate value
			int expected = 0; // TODO: Initialize to an appropriate value
			int actual;
			target.TrainingIterations = expected;
			actual = target.TrainingIterations;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}
	}
}
