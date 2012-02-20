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
    ///This is a test class for BasicLayerTest and is intended
    ///to contain all BasicLayerTest Unit Tests
    ///</summary>
	[TestClass()]
	public class BasicLayerTest
	{
		/// <summary>
		///A test for BasicLayer Constructor
		///</summary>
		[TestMethod()]
		public void BasicLayerConstructorTest()
		{
			INode[] computationalNodes = null;
			BasicLayer target = new BasicLayer(computationalNodes);
			Assert.Inconclusive("TODO: Implement code to verify target");
		}

		/// <summary>
		///A test for Equals
		///</summary>
		[TestMethod()]
		public void EqualsTest()
		{
			INode[] computationalNodes = null;
			BasicLayer target = new BasicLayer(computationalNodes);
			object obj = null;
			bool expected = false;
			bool actual;
			actual = target.Equals(obj);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for GetValues
		///</summary>
		[TestMethod()]
		public void GetValuesTest()
		{
			INode[] computationalNodes = null;
			BasicLayer target = new BasicLayer(computationalNodes);
			float[] values = null;
			float[] expected = null;
			float[] actual;
			actual = target.GetValues(values);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for MetaData
		///</summary>
		[TestMethod()]
		public void MetaDataTest()
		{
			INode[] computationalNodes = null;
			BasicLayer target = new BasicLayer(computationalNodes);
			Dictionary<string, string> expected = null;
			Dictionary<string, string> actual;
			target.MetaData = expected;
			actual = target.MetaData;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}
	}
}
