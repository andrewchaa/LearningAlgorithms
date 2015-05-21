using System.Runtime.Remoting.Messaging;

namespace LearningAlgorithms
{
    public class ListElement<T>
    {
        public ListElement<T> Next { get; private set; }
        public T Value { get; private set; }

        public ListElement(T value)
        {
            Value = value;
        }

        public void SetNext(ListElement<T> element)
        {
            Next = element;
        }

    }
}