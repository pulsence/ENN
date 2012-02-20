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
    ///This is a test class for ThreadedHiddenLayerTest and is intended
    ///to contain all ThreadedHiddenLayerTest Unit Tests
    ///</summary>
	[TestClass()]
	public class ThreadedHiddenLayerTest
	{
		/// <summary>
		///A test for ThreadedHiddenLayer Constructor
		///</summary>
		[TestMethod()]
		public void ThreadedHiddenLayerConstructorTest()
		{
			INode[] nodes = null; // TODO: Initialize to an appropriate value
			ThreadedHiddenLayer target = new ThreadedHiddenLayer(nodes);
			Assert.Inconclusive("TODO: Implement code to verify target");
		}

		/// <summary>
		///A test for GetValues
		///</summary>
		[TestMethod()]
		public void GetValuesTest()
		{
			INode[] nodes = null; // TODO: Initialize to an appropriate value
			ThreadedHiddenLayer target = new ThreadedHiddenLayer(nodes); // TODO: Initialize to an appropriate value
			float[] values = null; // TODO: Initialize to an appropriate value
			float[] expected = null; // TODO: Initialize to an appropriate value
			float[] actual;
			actual = target.GetValues(values);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}
	}
}
