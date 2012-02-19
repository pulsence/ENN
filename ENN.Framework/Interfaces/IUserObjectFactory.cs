using System.Collections.Generic;

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
    /// Interface that defines ObjectFactories
    /// </summary>
    public interface IUserObjectFactory
    {
        /// <summary>
        /// This method is used to create instances of interfaces for the runtime.
        /// </summary>
        /// <typeparam name="TObject">Type of interface to create.</typeparam>
        /// <param name="objectName">The name of the object to create.</param>
        /// <param name="buildParam">Parameters to create the object with.</param>
        /// <returns>Returns the data type that was created.</returns>
        TObject CreateUserObject<TObject>(string objectName, Dictionary<string, string> buildParam);
    }
}
