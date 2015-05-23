using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LearningAlgorithms.Tests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void It_should_push_and_pop_an_element()
        {
            // arrange
            var stack = new MyStack<int>();

            // act
            stack.Push(10);

            // assert
            Assert.That(stack.Pop(), Is.EqualTo(10));
        }

        [Test]
        public void Last_input_should_be_first_output()
        {
            // arrange
            var stack = new MyStack<int>();

            // act
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            // assert
            Assert.That(stack.Pop(), Is.EqualTo(30));
        }
    }
}
