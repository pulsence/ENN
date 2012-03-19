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
		/// <summary>
		///A test for ParseList
		///</summary>
		[TestMethod()]
		public void ParseListTest()
		{
			string raw = "{ 0.4,  0.4  ,\t 0.4 \t,0.4 \t }";
			string[] expected = new string[] { "0.4", "0.4", "0.4", "0.4" };
			string[] actual;
			actual = StandLibFactory.ParseList(raw);
			CollectionAssert.AreEqual(expected, actual);
		}

		/// <summary>
		///A test for getActivationFunction
		///</summary>
		[TestMethod()]
		public void getActivationFunctionTest()
		{
			string func = "logistic";
			ActivationFunction expected = SigmoidFunctions.Logistic;
			ActivationFunction actual;
			actual = StandLibFactory.getActivationFunction(func);
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///A test for getCombinationFunction
		///</summary>
		[TestMethod()]
		public void getCombinationFunctionTest()
		{
			string func = "sumation";
			CombinationFunction expected = CombinationFunctions.sumation;
			CombinationFunction actual;
			actual = StandLibFactory.getCombinationFunction(func);
			Assert.AreEqual(expected, actual);
		}
	}
}
