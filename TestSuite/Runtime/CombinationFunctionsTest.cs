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

namespace TestSuite.Runtime
{
    
    
    /// <summary>
    ///This is a test class for CombinationFunctionsTest and is intended
    ///to contain all CombinationFunctionsTest Unit Tests
    ///</summary>
	[TestClass()]
	public class CombinationFunctionsTest
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
		///A test for CombinationFunctions Constructor
		///</summary>
		[TestMethod()]
		public void CombinationFunctionsConstructorTest()
		{
			CombinationFunctions target = new CombinationFunctions();
			Assert.Inconclusive("TODO: Implement code to verify target");
		}

		/// <summary>
		///A test for production
		///</summary>
		[TestMethod()]
		public void productionTest()
		{
			float[] nodeValues = null; // TODO: Initialize to an appropriate value
			float[] constants = null; // TODO: Initialize to an appropriate value
			float expected = 0F; // TODO: Initialize to an appropriate value
			float actual;
			actual = CombinationFunctions.production(nodeValues, constants);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for sumation
		///</summary>
		[TestMethod()]
		public void sumationTest()
		{
			float[] nodeValues = null; // TODO: Initialize to an appropriate value
			float[] constants = null; // TODO: Initialize to an appropriate value
			float expected = 0F; // TODO: Initialize to an appropriate value
			float actual;
			actual = CombinationFunctions.sumation(nodeValues, constants);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}
	}
}
