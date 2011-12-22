using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENN.Framework;

namespace TestUserBinary
{
    public class TestBinary : IUserObjectFactory
    {
        public TObject CreateUserObject<TObject>(string objectName, Dictionary<string, string> buildParam)
        {
            if (objectName == "BasicPreProcessor")
            {
                IPreProcessor temp = new BasicPreProcessor();
                return (TObject)temp;
            }
            else if (objectName == "BasicPostProcessor")
            {
                IPostProcessor temp = new BasicPostProcessor();
                return (TObject)temp;
            }
            return default(TObject);
        }
    }
}
