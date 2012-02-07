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

namespace TestSuite.Runtime
{
    
    
    /// <summary>
    ///This is a test class for NetworkTopologyTest and is intended
    ///to contain all NetworkTopologyTest Unit Tests
    ///</summary>
	[TestClass()]
	public class NetworkTopologyTest
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
		///A test for NetworkTopology Constructor
		///</summary>
		[TestMethod()]
		public void NetworkTopologyConstructorTest()
		{
			NetworkTopology target = new NetworkTopology();
			Assert.Inconclusive("TODO: Implement code to verify target");
		}

		/// <summary>
		///A test for Equals
		///</summary>
		[TestMethod()]
		public void EqualsTest()
		{
			NetworkTopology target = new NetworkTopology(); // TODO: Initialize to an appropriate value
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
			NetworkTopology target = new NetworkTopology(); // TODO: Initialize to an appropriate value
			string expected = string.Empty; // TODO: Initialize to an appropriate value
			string actual;
			actual = target.ToString();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for HiddenLayers
		///</summary>
		[TestMethod()]
		public void HiddenLayersTest()
		{
			NetworkTopology target = new NetworkTopology(); // TODO: Initialize to an appropriate value
			IHiddenLayer[] expected = null; // TODO: Initialize to an appropriate value
			IHiddenLayer[] actual;
			target.HiddenLayers = expected;
			actual = target.HiddenLayers;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for InputLayer
		///</summary>
		[TestMethod()]
		public void InputLayerTest()
		{
			NetworkTopology target = new NetworkTopology(); // TODO: Initialize to an appropriate value
			IInputLayer expected = null; // TODO: Initialize to an appropriate value
			IInputLayer actual;
			target.InputLayer = expected;
			actual = target.InputLayer;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for MetaData
		///</summary>
		[TestMethod()]
		public void MetaDataTest()
		{
			NetworkTopology target = new NetworkTopology(); // TODO: Initialize to an appropriate value
			Dictionary<string, string> expected = null; // TODO: Initialize to an appropriate value
			Dictionary<string, string> actual;
			target.MetaData = expected;
			actual = target.MetaData;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for OutputLayer
		///</summary>
		[TestMethod()]
		public void OutputLayerTest()
		{
			NetworkTopology target = new NetworkTopology(); // TODO: Initialize to an appropriate value
			IOutputLayer expected = null; // TODO: Initialize to an appropriate value
			IOutputLayer actual;
			target.OutputLayer = expected;
			actual = target.OutputLayer;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for PostProcessor
		///</summary>
		[TestMethod()]
		public void PostProcessorTest()
		{
			NetworkTopology target = new NetworkTopology(); // TODO: Initialize to an appropriate value
			IPostProcessor expected = null; // TODO: Initialize to an appropriate value
			IPostProcessor actual;
			target.PostProcessor = expected;
			actual = target.PostProcessor;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for PreProcessor
		///</summary>
		[TestMethod()]
		public void PreProcessorTest()
		{
			NetworkTopology target = new NetworkTopology(); // TODO: Initialize to an appropriate value
			IPreProcessor expected = null; // TODO: Initialize to an appropriate value
			IPreProcessor actual;
			target.PreProcessor = expected;
			actual = target.PreProcessor;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for TrainingAlgorithm
		///</summary>
		[TestMethod()]
		public void TrainingAlgorithmTest()
		{
			NetworkTopology target = new NetworkTopology(); // TODO: Initialize to an appropriate value
			ITrainingAlgorithm expected = null; // TODO: Initialize to an appropriate value
			ITrainingAlgorithm actual;
			target.TrainingAlgorithm = expected;
			actual = target.TrainingAlgorithm;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for TrainingPreProcessor
		///</summary>
		[TestMethod()]
		public void TrainingPreProcessorTest()
		{
			NetworkTopology target = new NetworkTopology(); // TODO: Initialize to an appropriate value
			ITrainingPreProcessor expected = null; // TODO: Initialize to an appropriate value
			ITrainingPreProcessor actual;
			target.TrainingPreProcessor = expected;
			actual = target.TrainingPreProcessor;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}
	}
}
