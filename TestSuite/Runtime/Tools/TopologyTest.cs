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

namespace TestSuite.Runtime.Tools
{
	[TestClass]
	public class TopologyTest
	{
		string basePath;

		Dictionary<string, IUserObjectFactory> objectFactory;

		NetworkTopology testTopology, baseTopology;
		NetworkSettings settings;

		[TestInitialize]
		public void SetUp()
		{
			basePath = "C:\\Development Projects\\ENN\\TestSuite\\TestFiles\\";

			objectFactory = new Dictionary<string, IUserObjectFactory>()
			{
				{"standard", new StandLibFactory()},
				{"TestBinary", new TestBinary()}
			};

			settings = new NetworkSettings();
			settings.Mode = NetworkMode.Training;

			baseTopology = new NetworkTopology();			
		}

		[TestMethod]
		public void LoadTextTest()
		{
			SetUpBaseTopology();
			testTopology = Topology.Load(
				basePath + "testTopology.nnt",
				ref objectFactory,
				ref settings);
			Assert.IsTrue(baseTopology.Equals(testTopology), "Test for logical equality");
			Assert.IsNotNull(testTopology.MetaData, "Test for meta data");
		}

		[TestMethod]
		public void SaveTextTest()
		{
			baseTopology = Topology.Load(
				basePath + "testTopology.nnt",
				ref objectFactory,
				ref settings);

			Topology.Save(
				basePath + "testSaveTopology.nnt",
				baseTopology);

			testTopology = Topology.Load(
				basePath + "testSaveTopology.nnt",
				ref objectFactory,
				ref settings);

			Assert.IsTrue(baseTopology.Equals(testTopology));

			File.Delete(basePath + "testSaveTopology.nnt");
		}

		[TestMethod]
		public void SaveLoadBinaryTest()
		{
			SetUpBaseTopology();

			Topology.Save(
				basePath + "testBinaryTopologySave.nntb",
				baseTopology,
				true);

			testTopology = Topology.Load(
				basePath + "testBinaryTopologySave.nntb",
				ref objectFactory,
				ref settings,
				true);

			Assert.IsTrue(baseTopology.Equals(testTopology));

			File.Delete(basePath + "testBinaryTopologySave.nntb");
		}

		private void SetUpBaseTopology()
		{
			BasicInputLayer input = new BasicInputLayer();
			input.ValueIndexes = new int[] { 0, 1, 2, 3 };
			baseTopology.InputLayer = input;

			baseTopology.OutputLayer = new BasicOutputLayer();

			baseTopology.PreProcessor = objectFactory["TestBinary"].
				CreateUserObject<IPreProcessor>(
					"BasicPreProcessor", new Dictionary<string, string>());

			baseTopology.PostProcessor = objectFactory["TestBinary"].
				CreateUserObject<IPostProcessor>(
					"BasicPostProcessor", new Dictionary<string, string>());

			BasicNode[][] nodes = new BasicNode[2][];
			nodes[0] = new BasicNode[3];
			nodes[1] = new BasicNode[3];
			for (int i = 0; i < 3; i++)
			{
				nodes[0][i] = new BasicNode(
					new float[] { 0.4f, 0.3f, 0.2f, 0.6f },
					SigmoidFunctions.Logistic);

				nodes[1][i] = new BasicNode(
					new float[] { 0.4f, 0.3f, 0.2f },
					SigmoidFunctions.Logistic);
			}

			baseTopology.HiddenLayers = new BasicLayer[]
			{
				new BasicLayer(nodes[0]),
				new BasicLayer(nodes[1])
			};

			baseTopology.TrainingAlgorithm = new HillClimbAlgo();
			baseTopology.TrainingPreProcessor = objectFactory["TestBinary"].
				CreateUserObject<ITrainingPreProcessor>(
					"BasicPreProcessor", new Dictionary<string, string>());
		}
	}
}
