using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningAlgorithms.Graph;
using NUnit.Framework;

namespace LearningAlgorithms.Tests
{
    [TestFixture]
    public class GraphTests
    {
        [Test]
        public void It_should_be_able_to_add_nodes()
        {
            // arragen
            var graph = new MyGraph();
            var node = new MyNode("A");

            // act
            graph.AddNode(node);

            // assert
            Assert.That(graph.Nodes.Contains(node), Is.True);
        }

        [Test]
        public void It_cannot_add_the_same_node_twice()
        {
            // arragen
            var graph = new MyGraph();
            var node = new MyNode("A");
            graph.AddNode(node);

            // act
            // assert
            Assert.Throws<NodeAlreadyExistExceptioin>(() => graph.AddNode(node));
        }

        [Test]
        public void It_should_calculate_the_weight_among_nodes()
        {
            // arrange
            var graph = BuildGraph();

            var nodeA = graph.Nodes.First(n => n.Name == "A");
            var nodeB = graph.Nodes.First(n => n.Name == "B");
            var nodeC = graph.Nodes.First(n => n.Name == "C");
            var nodeD = graph.Nodes.First(n => n.Name == "D");
            var nodeE = graph.Nodes.First(n => n.Name == "E");

            // act
            var weightAd = graph.FindWeight(new List<MyNode> {nodeA, nodeD});

            // assert
            Assert.That(graph.FindWeight(new List<MyNode> {nodeA, nodeB, nodeC}), Is.EqualTo(9));
            Assert.That(graph.FindWeight(new List<MyNode> {nodeA, nodeD }), Is.EqualTo(5));
            Assert.That(graph.FindWeight(new List<MyNode> {nodeA, nodeD, nodeC }), Is.EqualTo(13));
            Assert.That(graph.FindWeight(new List<MyNode> {nodeA, nodeE, nodeB, nodeC, nodeD }), Is.EqualTo(22));
        }

        [Test]
        public void It_should_find_routes_through_nodes()
        {
            // arrange
            var graph = BuildGraph();
            var nodeC = graph.Nodes.First(n => n.Name == "C");

            // act
            var list = graph.FindRoutes(nodeC, nodeC, 3);

            // assert
            Assert.That(list.Count, Is.EqualTo(2));
        }

        [Test]
        public void It_should_find_routes_with_the_exact_number_of_stops()
        {
            // arrange
            var graph = BuildGraph();
            var nodeA = graph.Nodes.First(n => n.Name == "A");
            var nodeC = graph.Nodes.First(n => n.Name == "C");

            // act
            var list = graph.FindRoutesExactStops(nodeA, nodeC, 4);

            // assert
            Assert.That(list.Count, Is.EqualTo(3));
            
        }

        [Test]
        public void It_should_find_the_shortest_routes_from_A_to_C()
        {
            // arrange
            var graph = BuildGraph();
            var nodeA = graph.Nodes.First(n => n.Name == "A");
            var nodeC = graph.Nodes.First(n => n.Name == "C");

            // act
            var distance = graph.FindShortestDistance(nodeA, nodeC);

            // assert
            Assert.That(distance, Is.EqualTo(9));
            
        }

        private MyGraph BuildGraph()
        {
            var graph = new MyGraph();
            var nodeA = new MyNode("A");
            var nodeB = new MyNode("B");
            var nodeC = new MyNode("C");
            var nodeD = new MyNode("D");
            var nodeE = new MyNode("E");

            graph.AddNode(nodeA);
            graph.AddNode(nodeB);
            graph.AddNode(nodeC);
            graph.AddNode(nodeD);
            graph.AddNode(nodeE);

            nodeA.AddNode(nodeB, 5);
            nodeB.AddNode(nodeC, 4);
            nodeC.AddNode(nodeD, 8);
            nodeD.AddNode(nodeC, 8);
            nodeD.AddNode(nodeE, 6);
            nodeA.AddNode(nodeD, 5);
            nodeC.AddNode(nodeE, 2);
            nodeE.AddNode(nodeB, 3);
            nodeA.AddNode(nodeE, 7);

            return graph;
        }
    }
}
