using System;

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
    /// Specifies the type of function that can be used as an activation function.
    /// </summary>
    /// <param name="value">Combined value</param>
    /// <returns>Returns a value that is usually bounded by upper and lower limits.</returns>
    public delegate float ActivationFunction(float value);

    /// <summary>
    /// Helpful class that containts a variety of sigmoid functions that can be used as
    /// activation functions.
    /// </summary>
    public class SigmoidFunctions
    {
        /// <summary>
        /// Calculates the logistic function of the value. The logistic function is
        /// 1/(1+e^-value).
        /// </summary>
        /// <param name="value">The value to be used in the function.</param>
        /// <returns>Returns the functions output. Values will be in the range(0,1).</returns>
        public static float Logistic(float value)
        {
            return (float) (1 / (1 + Math.Pow(Math.E, -value)));
        }

        /// <summary>
        /// Same basic function as logistic except it has been stretch on both the x
        /// and y axis. The function is 2/(1+e^-.5value)-1.
        /// </summary>
        /// <param name="value">The value to be used in the function.</param>
        /// <returns>Returns the functions output. The values will be in the range (-1,1).</returns>
        public static float ModifiedLogistic(float value)
        {
            return (float) (2 / (1 + Math.Pow(Math.E, -value * .5)) + 1);
        }

        ///<summary>
        /// Easy to use function that uses preset values. The preset values are as
        /// follows: upperAsymptote=1, lowerAsymptote=-1, growthRate=1, v=., M=.5.
        /// The value passed is then passed with the preset values and the result
        /// is returned.
        /// </summary>
        /// <param name="value">The value to be used in the function.</param>
        /// <returns>Returns the functions output. The values will be in the range (-1,1).</returns>
        public static float GeneralizedLogistic(float value)
        {
            return SigmoidFunctions.GeneralizedLogistic(1, -1, 1, .5f, .5f, value);
        }

        /// <summary>
        /// Calculates the generalized logistic function from the given values.
        /// The generalized logistic function is 
        /// upperAsymptote + (lowerAsymptote - upperAsymptote)/(1+Qe^-growthRate(value-M))^1/v
        /// where Q = v
        /// </summary>
        /// <param name="upperAsymptote">The upper asymptote of the function</param>
        /// <param name="lowerAsymptote">The lower asymptote of the function</param>
        /// <param name="growthRate">The rate of growth for the function</param>
        /// <param name="v">Has to be greater than 0, affects near which asymptote maximum
        /// growth occurs. Is also equal to Q which depends on the value of the
        /// function at 0. If v is less than or equal to 0 the function returns 0.</param>
        /// <param name="M">The value at which the function experiences maximum growth.</param>
        /// <param name="value">The value to be used for the function calculation.</param>
        /// <returns>Returns the output of the function. The value will be in the range
        /// (lowerAsymptote, upperAsymptote).</returns>
        public static float GeneralizedLogistic(float upperAsymptote,
                                                 float lowerAsymptote,
                                                 float growthRate,
                                                 float v,
                                                 float M,
                                                 float value)
        {
            if (v <= 0) return 0;
            float numerator = lowerAsymptote - upperAsymptote;
            float denominator = (float) Math.Pow(1 + v *
                    Math.Pow(Math.E, -growthRate * (value - M)), 1 / v);
            return upperAsymptote + numerator / denominator;
        }

        ///<summary>
        /// Calculates a value using a simple algebra function. The function is
        /// x/(1+x^2)^.5.
        /// </summary>
        /// <param name="value">Value to be used in the function.</param>
        /// <returns>Returns the calculated value. The value will be in the range (-1,1).</returns>
        public static float SimpleAlgebra(float value)
        {
            return (float) (value / Math.Sqrt(1 + Math.Pow(value, 2)));
        }

        ///<summary>
        /// Calculates a value using the hyperbolic tangent function. The function used
        /// is tanh(x/2).
        /// </summary>
        /// <param name="value">The value to be used in the function.</param>
        /// <returns>Returns the functions output. The outputs range is (-1, 1)</returns>
        public static float HyperbolicTangent(float value)
        {
            return (float) Math.Tanh(value / 2);
        }
    }
}
