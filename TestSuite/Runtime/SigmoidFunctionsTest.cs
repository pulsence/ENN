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
    ///This is a test class for SigmoidFunctionsTest and is intended
    ///to contain all SigmoidFunctionsTest Unit Tests
    ///</summary>
	[TestClass()]
	public class SigmoidFunctionsTest
	{
		/// <summary>
		///A test for GeneralizedLogistic
		///</summary>
		[TestMethod()]
		public void GeneralizedLogisticTest()
		{
			float upperAsymptote = 1F;
			float lowerAsymptote = -1F;
			float growthRate = 1F;
			float v = 0.5F;
			float M = 0.5F;
			float value = 0F;
			float expected = 0.3991F;
			float actual;
			actual = SigmoidFunctions.GeneralizedLogistic(upperAsymptote, lowerAsymptote, growthRate, v, M, value);
			Assert.AreEqual(expected, actual, 0.01f);
		}

		/// <summary>
		///A test for GeneralizedLogistic
		///</summary>
		[TestMethod()]
		public void GeneralizedLogisticTest1()
		{
			float value = 0F;
			float expected = 0.3991F;
			float actual;
			actual = SigmoidFunctions.GeneralizedLogistic(value);
			Assert.AreEqual(expected, actual, 0.01f);
		}

		/// <summary>
		///A test for HyperbolicTangent
		///</summary>
		[TestMethod()]
		public void HyperbolicTangentTest()
		{
			float value = 0F;
			float expected = 0F;
			float actual;
			actual = SigmoidFunctions.HyperbolicTangent(value);
			Assert.AreEqual(expected, actual, 0.01f);
		}

		/// <summary>
		///A test for Logistic
		///</summary>
		[TestMethod()]
		public void LogisticTest()
		{
			float value = 0F;
			float expected = 0.5F;
			float actual;
			actual = SigmoidFunctions.Logistic(value);
			Assert.AreEqual(expected, actual, 0.01f);
		}

		/// <summary>
		///A test for ModifiedLogistic
		///</summary>
		[TestMethod()]
		public void ModifiedLogisticTest()
		{
			float value = 0F;
			float expected = 0F;
			float actual;
			actual = SigmoidFunctions.ModifiedLogistic(value);
			Assert.AreEqual(expected, actual, 0.01f);
		}

		/// <summary>
		///A test for SimpleAlgebra
		///</summary>
		[TestMethod()]
		public void SimpleAlgebraTest()
		{
			float value = 0F;
			float expected = 0F;
			float actual;
			actual = SigmoidFunctions.SimpleAlgebra(value);
			Assert.AreEqual(expected, actual, 0.01f);
		}
	}
}
