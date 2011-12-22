using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENN.Framework
{
    public interface IInputLayer
    {
        void SetInputPool(ref float[] pool);
        float[] GetValues();
    }
}
