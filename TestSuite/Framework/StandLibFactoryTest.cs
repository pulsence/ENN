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
    ///This is a test class for StandLibFactoryTest and is intended
    ///to contain all StandLibFactoryTest Unit Tests
    ///</summary>
	[TestClass()]
	public class StandLibFactoryTest
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
		///A test for StandLibFactory Constructor
		///</summary>
		[TestMethod()]
		public void StandLibFactoryConstructorTest()
		{
			StandLibFactory target = new StandLibFactory();
			Assert.Inconclusive("TODO: Implement code to verify target");
		}

		/// <summary>
		///A test for ENN.Framework.IUserObjectFactory.CreateUserObject
		///</summary>
		public void CreateUserObjectTestHelper<TObject>()
		{
			IUserObjectFactory target = new StandLibFactory(); // TODO: Initialize to an appropriate value
			string objectName = string.Empty; // TODO: Initialize to an appropriate value
			Dictionary<string, string> buildParam = null; // TODO: Initialize to an appropriate value
			TObject expected = default(TObject); // TODO: Initialize to an appropriate value
			TObject actual;
			actual = target.CreateUserObject<TObject>(objectName, buildParam);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		[TestMethod()]
		[DeploymentItem("ENN.Framework.dll")]
		public void CreateUserObjectTest()
		{
			CreateUserObjectTestHelper<GenericParameterHelper>();
		}

		/// <summary>
		///A test for ParseList
		///</summary>
		[TestMethod()]
		public void ParseListTest()
		{
			string raw = string.Empty; // TODO: Initialize to an appropriate value
			string[] expected = null; // TODO: Initialize to an appropriate value
			string[] actual;
			actual = StandLibFactory.ParseList(raw);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for getActivationFunction
		///</summary>
		[TestMethod()]
		public void getActivationFunctionTest()
		{
			string func = string.Empty; // TODO: Initialize to an appropriate value
			ActivationFunction expected = null; // TODO: Initialize to an appropriate value
			ActivationFunction actual;
			actual = StandLibFactory.getActivationFunction(func);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for getCombinationFunction
		///</summary>
		[TestMethod()]
		public void getCombinationFunctionTest()
		{
			string func = string.Empty; // TODO: Initialize to an appropriate value
			CombinationFunction expected = null; // TODO: Initialize to an appropriate value
			CombinationFunction actual;
			actual = StandLibFactory.getCombinationFunction(func);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}
	}
}
