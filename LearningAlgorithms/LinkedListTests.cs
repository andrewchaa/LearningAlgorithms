using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LearningAlgorithms
{
    [TestFixture]
    public class LinkedListTests
    {
        private ListElement<int> _element1;
        private ListElement<int> _element2;


        [Test]
        public void It_should_point_to_the_next_element()
        {
            //arrange
            _element1 = new ListElement<int>(1);
            _element2 = new ListElement<int>(2);

            //act
            _element1.SetNext(_element2);

            //assert
            Assert.That(_element1.Next, Is.EqualTo(_element2));
        }

        [Test]
        public void It_should_contain_a_value()
        {
            //act
            _element1 = new ListElement<int>(1);
            _element2 = new ListElement<int>(2);

            //assert
            Assert.That(_element1.Value, Is.EqualTo(1));
            Assert.That(_element2.Value, Is.EqualTo(2));
        }
    }
}
