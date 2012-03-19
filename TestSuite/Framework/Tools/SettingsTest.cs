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

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENN.Framework;
using ENN.Framework.Tools;
using TestUserBinary;

namespace TestSuite.Framework.Tools
{
	[TestClass]
	public class SettingsTest
	{
		string basePath;
		NetworkSettings testSetting, baseSetting;

		[TestInitialize]
		public void SetUp()
		{
			basePath = "C:\\Development Projects\\ENN\\TestSuite\\TestFiles\\";
			testSetting = new NetworkSettings();
			baseSetting = new NetworkSettings();
			SetBaseSetting();
		}

		[TestMethod]
		public void LoadText()
		{
			SetBaseSetting();
			testSetting = Settings.Load(basePath + "testSettings.nns");
			Assert.IsTrue(baseSetting.Equals(testSetting));
		}

		[TestMethod]
		public void SaveText()
		{
			SetBaseSetting();
			Settings.Save(baseSetting, basePath + "testSaveSettings.nns");

			testSetting = Settings.Load(basePath + "testSaveSettings.nns");
			Assert.IsTrue(baseSetting.Equals(testSetting));
			File.Delete(basePath + "testSaveSettings.nns");
		}

		[TestMethod]
		public void SaveLoadBinary()
		{
			SetBaseSetting();
			Settings.Save(baseSetting, basePath + "testSaveSettings.nnsc", true);

			testSetting = Settings.Load(basePath + "testSaveSettings.nnsc", true);
			Assert.IsTrue(baseSetting.Equals(testSetting));
			File.Delete(basePath + "testSaveSettings.nnsc");
		}

		private void SetBaseSetting()
		{
			baseSetting.Mode = NetworkMode.Computational;
			
			baseSetting.DefaultInputLayer = "BasicInputLayer";
			baseSetting.DefaultHiddenLayer = "BasicNodeLayer";
			baseSetting.DefaultOutputLayer = "BasicOutputLayer";
			baseSetting.DefaultNode = "BasicNode";
			baseSetting.DefaultFactory = "standard";

			baseSetting.EnableTiming = true;

			baseSetting.TrainingAccuracy = 0.9f;
			baseSetting.TrainingIterations = 10000;
			baseSetting.TraininPool = 25;
		}
	}
}
