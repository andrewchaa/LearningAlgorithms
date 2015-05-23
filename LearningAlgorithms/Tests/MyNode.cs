using System.Collections.Generic;

namespace LearningAlgorithms.Tests
{
    public class MyNode
    {
        public int Value { get; private set; }
        public IList<MyNode> Nodes { get; private set; }

        public MyNode(int value)
        {
            Value = value;
            Nodes = new List<MyNode>();
        }

        public void Add(MyNode node)
        {
            Nodes.Add(node);
        }
    }
}