using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LearningAlgorithms.Graph
{
    public class MyGraph
    {
        public IList<MyNode> Nodes { get; private set; }
        private int _stops = 0;
        private List<List<MyNode>> _routesList;
        private MyNode _endNode;

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
            _routesList = new List<List<MyNode>>();
            _endNode = end;

            var routes = new List<MyNode>();
            routes.Add(start);
            var stops = 0;

            FindNodes(routes, start, stops, maxStops);

            PrintNodes(_routesList);

            return _routesList;
        }

        private void FindNodes(List<MyNode> existingRoutes, MyNode node, int stops, int maxStops)
        {
            stops++;

            foreach (var nd in node.Nodes)
            {
                var routes = new List<MyNode>();
                routes.AddRange(existingRoutes);
                routes.Add(nd);

                if (nd == _endNode)
                {
                    _routesList.Add(routes);
                    continue;
                }

                if (nd.Nodes.Count == 0 || stops >= maxStops)
                    continue;

                FindNodes(routes, nd, stops, maxStops);
            }
        }

        private void PrintNodes(List<List<MyNode>> list)
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