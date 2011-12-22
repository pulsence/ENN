using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENN.Runtime
{
    class RawType
    {
        public string Type;
        public Dictionary<string, string> Fields;

        public RawType()
        {
            Type = "";
            Fields = new Dictionary<string, string>();
        }
    }
}
