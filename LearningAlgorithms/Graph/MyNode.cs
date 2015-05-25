using System.Collections.Generic;

namespace LearningAlgorithms.Graph
{
    public class MyNode
    {
        public string Name { get; private set; }
        public IList<MyNode> Nodes { get; private set; }

        public MyNode(string name)
        {
            Name = name;
            Nodes = new List<MyNode>();
        }

        public void Add(MyNode node)
        {
            Nodes.Add(node);
        }
    }
}