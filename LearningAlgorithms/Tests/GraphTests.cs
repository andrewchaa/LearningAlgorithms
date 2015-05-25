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
            // arragen
            var graph = BuildGraph();

            MyNode nodeA = graph.Nodes.First(n => n.Name == "A");
            MyNode nodeB = graph.Nodes.First(n => n.Name == "B");
            MyNode nodeC = graph.Nodes.First(n => n.Name == "C");

            // act
            var weight = graph.FindWeight(new List<MyNode> {nodeA, nodeB, nodeC});

            // assert
            Assert.That(weight, Is.EqualTo(9));
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
