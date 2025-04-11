public void Insert(T data)
{
    var newNode = new Node<T>(data);
    if (_head == null)
    {
        _head = newNode;
        return;
    }

    var current = _head;
    while (current.Next != null)
    {
        current = current.Next;
    }
    current.Next = newNode;
}