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
    ///This is a test class for BasicInputLayerTest and is intended
    ///to contain all BasicInputLayerTest Unit Tests
    ///</summary>
	[TestClass()]
	public class BasicInputLayerTest
	{
		/// <summary>
		///A test for Equals
		///</summary>
		[TestMethod()]
		public void EqualsTest()
		{
			BasicInputLayer target = new BasicInputLayer();

			target.ValueIndexes = new int[] { 0, 1, 2 };
			BasicInputLayer obj = new BasicInputLayer();
			obj.ValueIndexes = new int[] { 0, 1, 2 };

			bool expected = true;
			bool actual;
			actual = target.Equals(obj);
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///A test for GetValues
		///</summary>
		[TestMethod()]
		public void GetValuesTest()
		{
			BasicInputLayer target = new BasicInputLayer();
			target.ValueIndexes = new int[] { 0, 1, 2 };
			float[] expected = new float[] { 1.0f, 1.0f, 1.0f };
			target.SetInputPool(ref expected);
			float[] actual;
			actual = target.GetValues();
			Assert.AreEqual(expected[0], actual[0]);
			Assert.AreEqual(expected[1], actual[1]);
			Assert.AreEqual(expected[2], actual[2]);
		}
	}
}
