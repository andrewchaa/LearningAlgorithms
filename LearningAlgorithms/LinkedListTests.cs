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

        [SetUp]
        public void SetUp()
        {
            //arrange
            _element1 = new ListElement<int>(1);
            _element2 = new ListElement<int>(2);
        }

        [Test]
        public void an_element_should_contain_a_value()
        {
            //assert
            Assert.That(_element1.Value, Is.EqualTo(1));
            Assert.That(_element2.Value, Is.EqualTo(2));
        }

        [Test]
        public void An_element_points_to_the_next_element()
        {
            //act
            _element1.SetNext(_element2);

            //assert
            Assert.That(_element1.Next, Is.EqualTo(_element2));
        }

        [Test]
        public void A_list_insert_in_front_an_element()
        {
            //arrange
            var linkedList = new MyLinkedList<int>();

            //act
            var newElement = linkedList.InsertInFront(_element1, 3);

            Assert.That(newElement.Next, Is.EqualTo(_element1));
        }
    }

    public class MyLinkedList<T>
    {
        public ListElement<T> InsertInFront(ListElement<T> element, T value)
        {
            var newElement = new ListElement<T>(value);
            newElement.SetNext(element);

            return newElement;
        }
    }
}
