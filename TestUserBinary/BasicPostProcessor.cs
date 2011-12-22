using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENN.Framework;

namespace TestUserBinary
{
    class BasicPostProcessor : IPostProcessor
    {
        public void FinalAction(float finalValue)
        {
            Console.WriteLine("Final value is {0}", finalValue);
        }
    }
}
