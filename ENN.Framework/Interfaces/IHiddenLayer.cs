using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENN.Framework
{
    public interface IHiddenLayer
    {
        float[] GetValues(float[] values);
        void SetNodes(INode[] nodes);
        INode[] GetNodes();
        void SetNode(INode node, int index);
    }
}
