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
	/// Interface that all training algorithms need to impliment.
	/// </summary>
    public interface ITrainingAlgorithm
    {
		/// <summary>
		/// Sets the current settings for the network that is calling the training
		/// algorithm.
		/// </summary>
		/// <param name="settings">The NetworkSettings object to use.</param>
        void SetSettings(NetworkSettings settings);

		/// <summary>
		/// Modifies the given network in an attempt to make it more accurate.
		/// </summary>
		/// <param name="topology">The topology to train.</param>
		/// <param name="error">The error of the topology compared to the
		/// value that was expected. Lower numbers mean a more accurate
		/// topology.</param>
        void TrainNetwork(ref NetworkTopology topology,
                          float error);

		/// <summary>
		/// Resets any value that are used to track state so that there is
		/// no state confusion between training sessions.
		/// </summary>
		void Reset();
    }
}
