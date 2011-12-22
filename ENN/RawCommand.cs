using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENN.Runtime
{
    class RawCommand
    {
        public char CommandChar { get; set; }
        public string Value { get; set; }

        public RawCommand()
        {
            CommandChar = '\0';
            Value = "";
        }
    }
}
