using System;

namespace LearningAlgorithms
{
    public class MyLinkedList<T>
    {
        public MyLinkedListElement<T> Head { private set; get; }

        public MyLinkedListElement<T> InsertInFront(MyLinkedListElement<T> element, T value)
        {
            var newElement = new MyLinkedListElement<T>(value);
            newElement.SetNext(element);

            return newElement;
        }

        public void Add(T value)
        {
            var element = new MyLinkedListElement<T>(value);

            if (Head == null)
            {
                Head = element;
            }
            else
            {
                var lastElement = GetLastElement(Head);
                lastElement.SetNext(element);
            }
        }

        private MyLinkedListElement<T> GetLastElement(MyLinkedListElement<T> head)
        {
            var element = head;
            while (element.Next != null)
            {
                element = element.Next;
            }

            return element;
        }

        public MyLinkedListElement<T> Find(T value)
        {

            var element = Head;
            while (!element.Value.Equals(value))
            {
                element = element.Next;
            }

            if (!element.Value.Equals(value))
                return null;

            return element;
        }
    }
}