using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningAlgorithms.Graph;
using NUnit.Framework;

namespace LearningAlgorithms.Tests
{
    [TestFixture]
    public class TreeTests
    {
        [Test]
        public void Node_should_have_a_value()
        {
            // arrange
            // act
            var node = new MyNode("A");

            // assert
            Assert.That(node.Name, Is.EqualTo("A"));
        }

        [Test]
        public void Node_has_children()
        {
            // arrange
            var node = new MyNode("A");
            var childNode = new MyNode("B");

            // act
            node.Add(childNode);

            // assert
            Assert.That(node.Nodes.Contains(childNode), Is.True);
        }
    }
}
