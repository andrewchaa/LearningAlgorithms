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
    public class NodeTests
    {
        [Test]
        public void Node_can_have_neighbouring_nodes()
        {
            // arrange
            var nodeA = new MyNode("A");
            var nodeB = new MyNode("B");

            // act
            nodeA.AddNode(nodeB, 3);

            // arrange
            Assert.That(nodeA.Nodes.First(), Is.EqualTo(nodeB));
            Assert.That(nodeA.Weights.First(), Is.EqualTo(3));
        }
    }
}
