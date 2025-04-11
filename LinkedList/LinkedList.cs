namespace LinkedListNamespace
{
    public class LinkedList<T>
    {
        private Node<T>? _head;

        public void Insert(T data)
        {
            var newNode = new Node<T>(data);
            if (_head == null)
            {
                _head = newNode;
                return;
            }

            var current = _head;
            while (current?.Next != null)
            {
                current = current.Next;
            }
            current!.Next = newNode;  // Use non-nullable current
        }

        public void InsertAtIndex(int index, T data)
        {
            var newNode = new Node<T>(data);
            if (index == 0)
            {
                newNode.Next = _head;
                _head = newNode;
                return;
            }

            var current = _head;
            int currentIndex = 0;
            while (current != null && currentIndex < index - 1)
            {
                current = current.Next;
                currentIndex++;
            }

            if (current == null)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index out of range");
            }

            newNode.Next = current.Next;
            current.Next = newNode;
        }

        public bool DeleteElement(T data)
        {
            if (_head == null) return false;

            if (_head.Data!.Equals(data))
            {
                _head = _head.Next;
                return true;
            }

            var current = _head;
            while (current?.Next != null)
            {
                if (current.Next.Data!.Equals(data))
                {
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public bool DeleteAtIndex(int index)
        {
            if (index < 0 || _head == null) return false;

            if (index == 0)
            {
                _head = _head.Next;
                return true;
            }

            var current = _head;
            int count = 0;

            while (current?.Next != null)
            {
                if (count == index - 1)
                {
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
                count++;
            }

            return false;
        }

        public bool UpdateElement(T oldData, T newData)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Data!.Equals(oldData))
                {
                    current.Data = newData;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public bool UpdateElementAtIndex(int index, T data)
        {
            if (index < 0) return false;

            var current = _head;
            int currentIndex = 0;

            while (current != null)
            {
                if (currentIndex == index)
                {
                    current.Data = data;
                    return true;
                }

                current = current.Next;
                currentIndex++;
            }

            return false;
        }

        public bool Find(T data)
        {
            var current = _head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, data))
                    return true;

                current = current.Next;
            }

            return false;
        }

        public T Get(int index)
        {
            var current = _head;
            int currentIndex = 0;

            while (current != null)
            {
                if (currentIndex == index)
                    return current.Data!;  // Add non-nullable check here

                current = current.Next;
                currentIndex++;
            }

            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
        }
    }

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T>? Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
}
