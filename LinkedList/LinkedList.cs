///Inserts data at the end (tail) of the linked list.
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
///Inserts data at the specified index of the linked list
/// Throws ArgumentOutOfRangeException if index is invalid
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
}///Deletes the first occurrence of the specified data in the list
/// Returns true if an element was deleted, otherwise  will retrn false
public bool DeleteElement(T data)
{
    if (_head == null) return false;

    if (_head.Data.Equals(data))
    {
        _head = _head.Next;
        return true;
    }

    var current = _head;
    while (current.Next != null)
    {
        if (current.Next.Data.Equals(data))
        {
            current.Next = current.Next.Next;
            return true;
        }
        current = current.Next;
    }

    return false;
}
