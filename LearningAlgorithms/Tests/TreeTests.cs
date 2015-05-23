using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var node = new MyNode(1);

            // assert
            Assert.That(node.Value, Is.EqualTo(1));
        }

        [Test]
        public void Node_has_children()
        {
            // arrange
            var node = new MyNode(1);
            var childNode = new MyNode(2);

            // act
            node.Add(childNode);

            // assert
            Assert.That(node.Nodes.Contains(childNode), Is.True);
        }
    }
}
