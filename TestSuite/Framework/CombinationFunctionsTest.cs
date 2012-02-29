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
    ///This is a test class for CombinationFunctionsTest and is intended
    ///to contain all CombinationFunctionsTest Unit Tests
    ///</summary>
	[TestClass()]
	public class CombinationFunctionsTest
	{
		/// <summary>
		///A test for production
		///</summary>
		[TestMethod()]
		public void productionTest()
		{
			float[] nodeValues = new float[] { 1, 1, 1, 1 };
			float[] constants = new float[] { 1, 2, 0, 1 };
			float expected = 0F;
			float actual;
			actual = CombinationFunctions.production(nodeValues, constants);
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///A test for sumation
		///</summary>
		[TestMethod()]
		public void sumationTest()
		{
			float[] nodeValues = new float[] { 1, 1, 1, 1 };
			float[] constants = new float[] { 1, 2, 0, 1 };
			float expected = 4;
			float actual;
			actual = CombinationFunctions.sumation(nodeValues, constants);
			Assert.AreEqual(expected, actual);
		}
	}
}
