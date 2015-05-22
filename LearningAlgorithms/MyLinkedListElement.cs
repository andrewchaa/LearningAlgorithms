using System.Runtime.Remoting.Messaging;

namespace LearningAlgorithms
{
    public class MyLinkedListElement<T>
    {
        public MyLinkedListElement<T> Next { get; private set; }
        public T Value { get; private set; }

        public MyLinkedListElement(T value)
        {
            Value = value;
        }

        public void SetNext(MyLinkedListElement<T> element)
        {
            Next = element;
        }

    }
}