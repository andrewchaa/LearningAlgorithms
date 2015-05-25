using System.Collections.Generic;

namespace LearningAlgorithms.Graph
{
    public class MyNode
    {
        public string Name { get; private set; }
        public IList<MyNode> Nodes { get; private set; }
        public IList<int> Weights { get; private set; }

        public MyNode(string name)
        {
            Name = name;
            Nodes = new List<MyNode>();
            Weights = new List<int>();
        }

        public void AddNode(MyNode node, int weight)
        {
            Nodes.Add(node);
            Weights.Add(weight);
        }

    }
}