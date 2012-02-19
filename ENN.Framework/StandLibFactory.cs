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

using System.Collections.Generic;

namespace ENN.Framework
{
    /// <summary>
    /// Object factory for all the data types that come packaged in the framework.
    /// Impliments IUserObjectFactory.
    /// </summary>
    public class StandLibFactory : IUserObjectFactory
    {
        /// <summary>
        /// Creates an object for a specified datatype
        /// </summary>
        /// <typeparam name="TObject">Interface that will be implimented and returned</typeparam>
        /// <param name="objectName">The name of the data type that will be instantiated
        /// and returned.</param>
        /// <param name="buildParam">The paramater that will be used to create the object</param>
        /// <returns>Returns a finished object instance</returns>
        public TObject CreateUserObject<TObject>(
            string objectName, Dictionary<string, string> buildParam)
        {
            switch (objectName)
            {
                case "BasicNode":
                    string[] rawModifiers = ParseList(buildParam["combinationWeights"]);
                    float[] modifiers = new float[rawModifiers.Length];

                    for (int i = 0; i < rawModifiers.Length; i++)
                    {
                        float.TryParse(rawModifiers[i], out modifiers[i]);
                    }
                    BasicNode node = new BasicNode();
                    node.MetaData = buildParam;
                    node.Weights = modifiers;
                    if(buildParam.ContainsKey("activationFunction"))
                    {
                        node.ActivationFunc = getActivationFunction(buildParam["activationFunction"]);
                    }
                    INode tempNode = node;
                    return (TObject)tempNode;
                case "CustomizableNode":
                    rawModifiers = ParseList(buildParam["combinationWeights"]);
                    modifiers = new float[rawModifiers.Length];

                    for (int i = 0; i < rawModifiers.Length; i++)
                    {
                        float.TryParse(rawModifiers[i], out modifiers[i]);
                    }
                    CustomizableNode custNode = new CustomizableNode();
                    custNode.MetaData = buildParam;
                    custNode.Weights = modifiers;
                    if(buildParam.ContainsKey("activationFunction"))
                    {
                        custNode.ActivationFunc =
                            getActivationFunction(buildParam["activationFunction"]);
                    }
                    if (buildParam.ContainsKey("combinationFunction"))
                    {
                        custNode.ComboFunction =
                            getCombinationFunction(buildParam["combinationFunction"]);
                    }
                    tempNode = custNode;
                    return (TObject)tempNode;
                case "BasicInputLayer":
                    BasicInputLayer input = new BasicInputLayer();
                    input.MetaData = buildParam;
                    string[] rawValues = ParseList(buildParam["inputIndexes"]);
                    int[] values = new int[rawValues.Length];
                    for (int i = 0; i < rawValues.Length; i++)
                    {
                        int.TryParse(rawValues[i], out values[i]);
                    }
                    input.ValueIndexes = values;
                    IInputLayer tempIn = input;
                    return (TObject)tempIn;
                case "BasicOutputLayer":
                    IOutputLayer tempOut = new BasicOutputLayer();
                    tempOut.MetaData = buildParam;
                    return (TObject)tempOut;
                case "BasicLayer":
                    int count;
                    int.TryParse(buildParam["nodeCount"], out count);
                    IHiddenLayer tempHidden = new BasicLayer(new INode[count]);
                    tempHidden.MetaData = buildParam;
                    return (TObject)tempHidden;
                case "ThreadedHiddenLayer":
                    int.TryParse(buildParam["nodeCount"], out count);
                    tempHidden = new ThreadedHiddenLayer(new INode[count]);
                    tempHidden.MetaData = buildParam;
                    return (TObject)tempHidden;
				case "HillClimbAlgo":
					ITrainingAlgorithm algo = new HillClimbAlgo();
					return (TObject)algo;
                default:
                    return default(TObject);
            }
        }

        /// <summary>
        /// Given the function name, the delage for the packaged sigmoid functions are returned.
        /// Sigmoid functions are frequently used to as activation functions. Expected func values
        /// are modifiedLogistic, generalizedLogistic, simpleAlgebra, hyperbolicTangent. Default
        /// return is the logistic delegate.
        /// </summary>
        /// <param name="func">Name of the function to return</param>
        /// <returns>Returns the specified ActivationFunction. Logistic is return by default.</returns>
        static public ActivationFunction getActivationFunction(string func)
        {
            switch (func)
            {
                case "modifiedLogistic":
                    return SigmoidFunctions.ModifiedLogistic;
                case "generalizedLogistic":
                    return SigmoidFunctions.GeneralizedLogistic;
                case "simpleAlgebra":
                    return SigmoidFunctions.SimpleAlgebra;
                case "hyperbolicTangent":
                    return SigmoidFunctions.HyperbolicTangent;
                default:
                    return SigmoidFunctions.Logistic;
            }
        }

        /// <summary>
        /// Returns one the two built in combination functions. Expects productions or
        /// sumation. Sumation is returned by default.
        /// </summary>
        /// <param name="func">Name of the combination function to retrieve.</param>
        /// <returns>Returns the CombinationFunction.</returns>
        static public CombinationFunction getCombinationFunction(string func)
        {
            switch (func)
            {
                case "production":
                    return CombinationFunctions.production;
                default:
                    return CombinationFunctions.sumation;
            }
        }

        /// <summary>
        /// Given a list from the topology file, the list is broken down into an
        /// array of strings. Each value is trimmed on the ends.
        /// </summary>
        /// <param name="raw">Unmodified value from the topology file</param>
        /// <returns>Returns an array of strings that contain the seperated values.</returns>
        static public string[] ParseList(string raw)
        {
            raw = raw.Trim("{}".ToCharArray());
            string[] split =  raw.Split(',');
            for (int i = 0; i < split.Length; i++)
            {
                split[i] = split[i].Trim();
            }
            return split;
        }
    }
}
