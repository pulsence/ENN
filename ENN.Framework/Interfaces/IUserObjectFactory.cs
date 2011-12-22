using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENN.Framework
{
    public interface IUserObjectFactory
    {
        TObject CreateUserObject<TObject>(string objectName, Dictionary<string, string> buildParam);
    }
}
