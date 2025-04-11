namespace StaticLinkedListNamespace
{
    /// <summary>
    /// A statically allocated linked list using a fixed-size array of 100 nodes.
    /// </summary>
    public class StaticLinkedList<T>
    {
        private const int MaxSize = 100;

        private struct Node
        {
            public T Data;
            public int Next;
            public bool IsUsed;
        }

        private Node[] _nodes = new Node[MaxSize];
        private int _head = -1;
        private int _free = 0;
        private int _size = 0;

        /// <summary>
        /// Initializes the free list.
        /// </summary>
        public StaticLinkedList()
        {
            for (int i = 0; i < MaxSize - 1; i++)
            {
                _nodes[i].Next = i + 1;
            }
            _nodes[MaxSize - 1].Next = -1;
        }

        /// <summary>
        /// Inserts data at the tail of the list.
        /// </summary>
        public void Insert(T data)
        {
            if (_free == -1) return;

            int newIndex = _free;
            _free = _nodes[newIndex].Next;

            _nodes[newIndex].Data = data;
            _nodes[newIndex].IsUsed = true;
            _nodes[newIndex].Next = -1;

            if (_head == -1)
            {
                _head = newIndex;
            }
            else
            {
                int current = _head;
                while (_nodes[current].Next != -1)
                    current = _nodes[current].Next;

                _nodes[current].Next = newIndex;
            }

            _size++;
        }

        /// <summary>
        /// Inserts data at the specified index.
        /// </summary>
        public void InsertAtIndex(int index, T data)
        {
            if (index < 0 || index > _size || _free == -1) return;

            int newIndex = _free;
            _free = _nodes[newIndex].Next;

            _nodes[newIndex].Data = data;
            _nodes[newIndex].IsUsed = true;

            if (index == 0)
            {
                _nodes[newIndex].Next = _head;
                _head = newIndex;
            }
            else
            {
                int current = _head;
                for (int i = 0; i < index - 1; i++)
                    current = _nodes[current].Next;

                _nodes[newIndex].Next = _nodes[current].Next;
                _nodes[current].Next = newIndex;
            }

            _size++;
        }

        /// <summary>
        /// Deletes the first element that matches the given data.
        /// </summary>
        /// <returns>True if deleted, otherwise false.</returns>
        public bool DeleteElement(T data)
        {
            int current = _head;
            int prev = -1;

            while (current != -1)
            {
                if (_nodes[current].IsUsed && _nodes[current].Data!.Equals(data))
                {
                    if (prev == -1)
                        _head = _nodes[current].Next;
                    else
                        _nodes[prev].Next = _nodes[current].Next;

                    FreeNode(current);
                    _size--;
                    return true;
                }

                prev = current;
                current = _nodes[current].Next;
            }

            return false;
        }

        /// <summary>
        /// Deletes the element at the specified index.
        /// </summary>
        /// <returns>True if deleted, otherwise false.</returns>
        public bool DeleteAtIndex(int index)
        {
            if (index < 0 || index >= _size) return false;

            int current = _head;
            int prev = -1;

            for (int i = 0; i < index; i++)
            {
                prev = current;
                current = _nodes[current].Next;
            }

            if (prev == -1)
                _head = _nodes[current].Next;
            else
                _nodes[prev].Next = _nodes[current].Next;

            FreeNode(current);
            _size--;
            return true;
        }

        /// <summary>
        /// Updates the first element equal to oldData with newData.
        /// </summary>
        /// <returns>True if updated, otherwise false.</returns>
        public bool UpdateElement(T oldData, T newData)
        {
            int current = _head;

            while (current != -1)
            {
                if (_nodes[current].IsUsed && _nodes[current].Data!.Equals(oldData))
                {
                    _nodes[current].Data = newData;
                    return true;
                }
                current = _nodes[current].Next;
            }

            return false;
        }

        /// <summary>
        /// Updates the value at the specified index.
        /// </summary>
        /// <returns>True if updated, otherwise false.</returns>
        public bool UpdateElementAtIndex(int index, T data)
        {
            if (index < 0 || index >= _size) return false;

            int current = _head;
            for (int i = 0; i < index; i++)
                current = _nodes[current].Next;

            _nodes[current].Data = data;
            return true;
        }

        /// <summary>
        /// Searches the list for a value.
        /// </summary>
        /// <returns>True if found, otherwise false.</returns>
        public bool Find(T data)
        {
            int current = _head;
            while (current != -1)
            {
                if (_nodes[current].IsUsed && _nodes[current].Data!.Equals(data))
                    return true;
                current = _nodes[current].Next;
            }
            return false;
        }

        /// <summary>
        /// Gets the value at a given index.
        /// </summary>
        public T Get(int index)
        {
            if (index < 0 || index >= _size)
                throw new IndexOutOfRangeException();

            int current = _head;
            for (int i = 0; i < index; i++)
                current = _nodes[current].Next;

            return _nodes[current].Data;
        }

        /// <summary>
        /// Frees the node at the given index, returning it to the free list.
        /// </summary>
        private void FreeNode(int index)
        {
            _nodes[index].IsUsed = false;
            _nodes[index].Next = _free;
            _free = index;
        }
    }
}
