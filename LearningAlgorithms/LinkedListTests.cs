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
        private MyLinkedListElement<int> _element1;
        private MyLinkedListElement<int> _element2;
        private MyLinkedList<int> _linkedList;

        [SetUp]
        public void SetUp()
        {
            //arrange
            _element1 = new MyLinkedListElement<int>(1);
            _element2 = new MyLinkedListElement<int>(2);
            _linkedList = new MyLinkedList<int>();
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

        [Test]
        public void It_should_add_the_first_element_to_the_head()
        {
            //act
            _linkedList.Add(1);

            //assert
            Assert.That(_linkedList.Head.Value, Is.EqualTo(1));
        }

        [Test]
        public void It_should_add_the_element_as_the_last_one()
        {
            //arrange
            _linkedList.Add(1);
            _linkedList.Add(2);
            
            //act
            _linkedList.Add(3);

            Assert.That(_linkedList.Head.Next.Next.Value, Is.EqualTo(3));
        }

        [Test]
        public void It_should_traverse_the_list_and_find_an_element_by_value()
        {
            // arrange
            _linkedList.Add(1);
            _linkedList.Add(2);
            _linkedList.Add(3);
            _linkedList.Add(4);
            
            // act
            var element = _linkedList.Find(3);

            // assert 
            Assert.That(element.Value, Is.EqualTo(3));
        }
    }
}
