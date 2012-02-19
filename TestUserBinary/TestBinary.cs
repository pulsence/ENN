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
using ENN.Framework;

namespace TestUserBinary
{
	/// <summary>
	/// Example of a basic IUserObjectFactory implimentation.
	/// </summary>
    public class TestBinary : IUserObjectFactory
    {
		/// <summary>
		/// Produces an object from the passed parameters. This can only make
		/// BasicPreprocessors and BasicPostProcessors.
		/// </summary>
		/// <typeparam name="TObject">The type of object to produce.</typeparam>
		/// <param name="objectName">The name of the object to create.</param>
		/// <param name="buildParam">The parameters to use to create the object.</param>
		/// <returns>Returns the created object.</returns>
        public TObject CreateUserObject<TObject>(string objectName, Dictionary<string, string> buildParam)
        {
            if (objectName == "BasicPreProcessor")
            {
                ITrainingPreProcessor temp = new BasicPreProcessor();
                temp.MetaData = buildParam;
                return (TObject)temp;
            }
            else if (objectName == "BasicPostProcessor")
            {
                IPostProcessor temp = new BasicPostProcessor();
                temp.MetaData = buildParam;
                return (TObject)temp;
            }
            return default(TObject);
        }
    }
}
