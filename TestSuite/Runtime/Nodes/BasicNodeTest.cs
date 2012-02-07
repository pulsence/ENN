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
    ///This is a test class for BasicNodeTest and is intended
    ///to contain all BasicNodeTest Unit Tests
    ///</summary>
	[TestClass()]
	public class BasicNodeTest
	{
		/// <summary>
		///A test for Equals
		///</summary>
		[TestMethod()]
		public void EqualsTest()
		{
			BasicNode target = new BasicNode();
			target.Weights = new float[] { 0.1f, 0.2f, 0.0f };
			target.ActivationFunc = SigmoidFunctions.ModifiedLogistic;

			BasicNode obj = new BasicNode(
				new float[] { 0.1f, 0.2f, 0.0f },
				SigmoidFunctions.ModifiedLogistic);

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
			float[] constants = new float[] { 0.1f, 0.1f, 1.1f };
			ActivationFunction activationFunction = SigmoidFunctions.Logistic;
			BasicNode target = new BasicNode(constants, activationFunction);

			float[] nodeValues = new float[] { 1.0f, 1.0f, 1.0f };
			float expected = 0.78583F;
			float actual;
			actual = target.GetValue(nodeValues);
			Assert.AreEqual(expected, actual, 0.001f);
		}

		/// <summary>
		///A test for MetaData
		///</summary>
		[TestMethod()]
		public void MetaDataTest()
		{
			BasicNode target = new BasicNode();
			Dictionary<string, string> expected = new Dictionary<string, string>();
			expected.Add("key1", "value1");
			expected.Add("key2", "value2");

			Dictionary<string, string> actual;
			target.MetaData = expected;
			target.Weights = new float[] { 1.0f, 1.0f, 1.0f };
			expected.Add("weights", "{1.0, 1.0, 1.0}");
			actual = target.MetaData;
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///A test for Weights
		///</summary>
		[TestMethod()]
		public void WeightsTest()
		{
			BasicNode target = new BasicNode();
			float[] expected = new float[] { 1.0f, 1.0f, 1.0f };
			float[] actual;
			target.Weights = expected;
			actual = target.Weights;
			Assert.AreEqual(expected, actual);
		}
	}
}
