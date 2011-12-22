using System;
using System.Collections;

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
