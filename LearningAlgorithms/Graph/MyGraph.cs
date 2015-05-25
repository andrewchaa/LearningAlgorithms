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

            AddRouteList(start, maxStops);


            foreach (var list in _routesList)
            {
                foreach (var node in list)
                {
                    Console.Write(node);
                }
                Console.Write("\n");
            }

            return _routesList;
        }

        private List<List<MyNode>> AddRouteList(MyNode start, int maxStops)
        {
            _stops++;

            foreach (var node in start.Nodes)
            {
                var routes = new List<MyNode>();
                routes.Add(start);
                routes.Add(node);

                foreach (var myNode in node.Nodes)
                {
                    routes.Add(myNode);

                    foreach (var myNode1 in myNode.Nodes)
                    {
                        routes.Add(myNode1);
                    }
                }

                _routesList.Add(routes);
            }

            return _routesList;
        }
    }
}