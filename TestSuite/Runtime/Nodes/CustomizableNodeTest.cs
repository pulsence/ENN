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
    ///This is a test class for CustomizableNodeTest and is intended
    ///to contain all CustomizableNodeTest Unit Tests
    ///</summary>
	[TestClass()]
	public class CustomizableNodeTest
	{
		/// <summary>
		///A test for Equals
		///</summary>
		[TestMethod()]
		public void EqualsTest()
		{
			CustomizableNode target = new CustomizableNode(); // TODO: Initialize to an appropriate value
			object obj = null; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.Equals(obj);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for GetValue
		///</summary>
		[TestMethod()]
		public void GetValueTest()
		{
			CustomizableNode target = new CustomizableNode(); // TODO: Initialize to an appropriate value
			float[] nodeValues = null; // TODO: Initialize to an appropriate value
			float expected = 0F; // TODO: Initialize to an appropriate value
			float actual;
			actual = target.GetValue(nodeValues);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}
	}
}
