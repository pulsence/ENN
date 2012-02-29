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
    ///This is a test class for NetworkSettingsTest and is intended
    ///to contain all NetworkSettingsTest Unit Tests
    ///</summary>
	[TestClass()]
	public class NetworkSettingsTest
	{
		string basePath;
		NetworkSettings testSetting, target;

		[TestInitialize]
		public void SetUp()
		{
			basePath = "C:\\Development Projects\\ENN\\TestSuite\\TestFiles\\";
			testSetting = new NetworkSettings();
			target = new NetworkSettings();
			SetBaseSetting();
		}

		/// <summary>
		///A test for Equals
		///</summary>
		[TestMethod()]
		public void EqualsTest()
		{
			bool expected = true;
			bool actual;
			actual = target.Equals(target);
			Assert.AreEqual(expected, actual);
		}

		private void SetBaseSetting()
		{
			target.Mode = NetworkMode.Computational;

			target.DefaultInputLayer = "BasicInputLayer";
			target.DefaultHiddenLayer = "BasicNodeLayer";
			target.DefaultOutputLayer = "BasicOutputLayer";
			target.DefaultNode = "BasicNode";
			target.DefaultFactory = "standard";

			target.EnableTiming = true;

			target.TrainingAccuracy = 0.9f;
			target.TrainingIterations = 10000;
			target.TraininPool = 25;

			target.Other.Add("version", "1.0");
		}
	}
}
