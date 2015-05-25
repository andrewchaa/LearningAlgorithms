using System.Collections.Generic;

namespace LearningAlgorithms.Graph
{
    public class MyGraph
    {
        public IList<MyNode> Nodes { get; private set; }

        public MyGraph()
        {
            Nodes = new List<MyNode>();
        }

        public void AddNode(MyNode node)
        {
            if (Nodes.Contains(node))
                throw new NodeAlreadyExistExceptioin();

            Nodes.Add(node);
        }

        public int FindWeight(List<MyNode> nodes)
        {
            int weight = 0;
            for (int i = 0; i < nodes.Count - 1; i++)
            {
                if (nodes[i].Nodes.Contains(nodes[i + 1]))
                {
                    var index = nodes[i].Nodes.IndexOf(nodes[i + 1]);
                    weight += nodes[i].Weights[index];
                }
            }

            return weight;
        }
    }
}