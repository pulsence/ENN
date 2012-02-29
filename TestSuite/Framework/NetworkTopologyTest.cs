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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ENN.Framework;
using ENN.Framework.Tools;

namespace TestSuite.Framework
{
    /// <summary>
    ///This is a test class for NetworkTopologyTest and is intended
    ///to contain all NetworkTopologyTest Unit Tests
    ///</summary>
	[TestClass()]
	public class NetworkTopologyTest
	{
		/// <summary>
		///A test for Equals
		///</summary>
		[TestMethod()]
		public void EqualsTest()
		{
			string basePath = "C:\\Development Projects\\ENN\\TestSuite\\TestFiles\\";

			Dictionary<string, IUserObjectFactory> factory = new Dictionary<string,IUserObjectFactory>();
			factory.Add("standard", new StandLibFactory());
			factory.Add("TestBinary", new TestUserBinary.TestBinary());

			NetworkSettings settings = Settings.Load(basePath + "testSettings.nns");

			NetworkTopology target = Topology.Load(
				basePath + "testTopology.nnt", ref factory, ref settings);
			bool expected = true;
			bool actual;
			actual = target.Equals(target);
			Assert.AreEqual(expected, actual);
		}
	}
}
