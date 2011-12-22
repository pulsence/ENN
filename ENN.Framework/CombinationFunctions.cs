using System;
using System.Collections;

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
    public delegate float CombinationFunction (float[] nodeValues, float[] constants);

    public class CombinationFunctions
    {
        public static float sumation(float[] nodeValues, float[] constants) 
        {
            float value = 0;
            for (int i = 0; i < nodeValues.Length; i++)
            {
                value += nodeValues[i] * constants[i];
            }
            return value;
        }

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
