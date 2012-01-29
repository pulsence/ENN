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

namespace ENN.Framework
{
    /// <summary>
    /// Function used to combine node values and weights.
    /// </summary>
    /// <param name="nodeValues">Array of node values</param>
    /// <param name="constants">Array of constants values</param>
    /// <returns>Returns the combined values.</returns>
    public delegate float CombinationFunction (float[] nodeValues, float[] constants);

    /// <summary>
    /// Class containing two common combination methods that can be used.
    /// </summary>
    public class CombinationFunctions
    {
        /// <summary>
        /// Standard sumation operation. Corrisponding nodeValues and constants are
        /// multipled then added. Note that no error checking happens so if the nodeValues
        /// array is larger than constants then an error will be thrown.
        /// </summary>
        /// <param name="nodeValues">Array of values for the node in the hidden layer
        /// immidiatly below the current layer.</param>
        /// <param name="constants">Weights that line up with a specific nodeValue.</param>
        /// <returns>Returns a single float value.</returns>
        public static float sumation(float[] nodeValues, float[] constants) 
        {
            float value = 0;
            for (int i = 0; i < nodeValues.Length; i++)
            {
                value += nodeValues[i] * constants[i];
            }
            return value;
        }

        /// <summary>
        /// Standard production operation. Corrisponding nodeValues and constants are
        /// multipled then mulitpled. Note that no error checking happens so if the nodeValues
        /// array is larger than constants then an error will be thrown.
        /// </summary>
        /// <param name="nodeValues">Array of values for the node in the hidden layer
        /// immidiatly below the current layer.</param>
        /// <param name="constants">Weights that line up with a specific nodeValue.</param>
        /// <returns>Returns a single float value.</returns>
        public static float production(float[] nodeValues, float[] constants)
        {
            float value = 0;
            for (int i = 0; i < nodeValues.Length; i++)
            {
                value *= nodeValues[i] * constants[i];
            }
            return value;
        }
    }
}
