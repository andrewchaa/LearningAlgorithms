namespace LearningAlgorithms.LinkedList
{
    public class MyStack<T>
    {
        private MyLinkedList<T> _linkedList;

        public MyStack()
        {
            _linkedList = new MyLinkedList<T>();    
        }

        public void Push(T value)
        {
            if (_linkedList.Head == null)
            {
                _linkedList.Add(value);
                return;
            }

            _linkedList.InsertInFront(_linkedList.Head, value);
        }

        public T Pop()
        {
            var value = _linkedList.Head.Value;
            _linkedList.Delete(_linkedList.Head);

            return value;
        }
    }
}