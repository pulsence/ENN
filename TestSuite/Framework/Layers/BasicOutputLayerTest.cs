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
    ///This is a test class for BasicOutputLayerTest and is intended
    ///to contain all BasicOutputLayerTest Unit Tests
    ///</summary>
	[TestClass()]
	public class BasicOutputLayerTest
	{
		/// <summary>
		///A test for Equals
		///</summary>
		[TestMethod()]
		public void EqualsTest()
		{
			BasicOutputLayer target = new BasicOutputLayer();
			BasicOutputLayer obj = new BasicOutputLayer();
			bool expected = true;
			bool actual;
			actual = target.Equals(obj);
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///A test for GetValue
		///</summary>
		[TestMethod()]
		public void GetValueTest()
		{
			BasicOutputLayer target = new BasicOutputLayer();
			float[] nodeValues = new float[] { 1.0f, 1.0f, 1.0f };
			float expected = 3.0f;
			float actual;
			actual = target.GetValue(nodeValues);
			Assert.AreEqual(expected, actual, 0.001f);
		}
	}
}
