using System;
using System.Collections.Generic;

namespace LearningAlgorithms.Graph
{
    public class MyGraph
    {
        public IList<MyNode> Nodes { get; private set; }
        private MyNode _endNode;
        private int _maxStops;
        private int _exactStops;

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

        public List<List<MyNode>> FindRoutesExactStops(MyNode start, MyNode end, int exactStops)
        {
            var matchingNodes = new List<List<MyNode>>();
            _exactStops = exactStops;
            _endNode = end;

            var routes = new List<MyNode> {start};
            FindNodesByExactStops(matchingNodes, routes, start, 0);
            PrintNodes(matchingNodes);

            return matchingNodes;
        }

        private void FindNodesByExactStops(List<List<MyNode>> matchingNodes, List<MyNode> routes, MyNode node, int exactStops)
        {
            exactStops++;

            foreach (var nd in node.Nodes)
            {
                routes.Add(nd);

                if (nd.Nodes.Count == 0 || exactStops >= _exactStops)
                {
                    if (routes.Contains(_endNode))
                    {
                        matchingNodes.Add(routes);
                    }
                    continue;
                }
                    

                FindNodesByExactStops(matchingNodes, routes, nd, exactStops);
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