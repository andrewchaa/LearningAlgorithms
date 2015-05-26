using System;
using System.Collections.Generic;

namespace LearningAlgorithms.Graph
{
    public class MyGraph
    {
        public IList<MyNode> Nodes { get; private set; }
        private MyNode _endNode;
        private int _maxStops;

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

        public List<List<MyNode>> FindRoutes(MyNode start, MyNode end, int maxStops)
        {
            var matchingNodes = new List<List<MyNode>>();
            _endNode = end;
            _maxStops = maxStops;

            var routes = new List<MyNode> {start};
            FindNodes(matchingNodes, routes, start, 0);
            PrintNodes(matchingNodes);

            return matchingNodes;
        }

        private void FindNodes(List<List<MyNode>> matchingNodes, List<MyNode> existingRoutes, MyNode node, int stops)
        {
            stops++;

            foreach (var nd in node.Nodes)
            {
                var routes = new List<MyNode>();
                routes.AddRange(existingRoutes);
                routes.Add(nd);

                if (nd == _endNode)
                {
                    matchingNodes.Add(routes);
                    continue;
                }

                if (nd.Nodes.Count == 0 || stops >= _maxStops)
                    continue;

                FindNodes(matchingNodes, routes, nd, stops);
            }
        }

        private void PrintNodes(IEnumerable<List<MyNode>> list)
        {
            foreach (var lst in list)
            {
                foreach (var node in lst)
                {
                    Console.Write(node);
                }
                Console.Write("\n");
            }
        }
    }
}