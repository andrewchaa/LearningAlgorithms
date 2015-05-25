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
        public void Graph_should_be_able_to_add_nodes()
        {
            // arragen
            var graph = new MyGraph();

            // act
            graph.AddNode(new MyNode("A"));

            // assert
        }
    }

    public class MyGraph
    {
        public void AddNode(MyNode node)
        {
            
        }
    }
}
