using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*This file is part of ENN.
* Copyright (C) 2011  Tim Eck II
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

namespace ENN.Framework
{
    public class StandLibFactory : IUserObjectFactory
    {
        TObject IUserObjectFactory.CreateUserObject<TObject>(
            string objectName, Dictionary<string, string> buildParam)
        {
            switch (objectName)
            {
                case "BasicNode":
                    string[] rawModifiers = ParseList(buildParam["combinationWieghts"]);
                    float[] modifiers = new float[rawModifiers.Length];

                    for (int i = 0; i < rawModifiers.Length; i++)
                    {
                        float.TryParse(rawModifiers[i], out modifiers[i]);
                    }
                    BasicNode node = new BasicNode();
                    node.Constants = modifiers;
                    if(buildParam.ContainsKey("activationFunction"))
                    {
                        node.ActivationFunc = getActivationFunction(buildParam["activationFunction"]);
                    }
                    INode tempNode = node;
                    return (TObject)tempNode;
                case "CustomizableNode":
                    rawModifiers = ParseList(buildParam["combinationWieghts"]);
                    modifiers = new float[rawModifiers.Length];

                    for (int i = 0; i < rawModifiers.Length; i++)
                    {
                        float.TryParse(rawModifiers[i], out modifiers[i]);
                    }
                    CustomizableNode custNode = new CustomizableNode();
                    custNode.Constants = modifiers;
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
                    return (TObject)tempOut;
                case "BasicLayer":
                    int count;
                    int.TryParse(buildParam["nodeCount"], out count);
                    IHiddenLayer tempHidden = new BasicLayer(new INode[count]);
                    return (TObject)tempHidden;
                case "ThreadedHiddenLayer":
                    int.TryParse(buildParam["nodeCount"], out count);
                    tempHidden = new ThreadedHiddenLayer(new INode[count]);
                    return (TObject)tempHidden;
                default:
                    return default(TObject);
            }
        }

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
