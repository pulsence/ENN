﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENN.Framework
{
    public interface IPreProcessor
    {
        float[] GenerateValues();
    }
}