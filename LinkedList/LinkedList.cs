namespace LinkedListNamespace
{
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
}///Deletes the element at the specified index
/// Returns false if index is out of bounds
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

    while (current.Next != null)
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
///Updates the first element matching oldData with newData
/// Returns true if an element was updated, otherwise false
public bool UpdateElement(T oldData, T newData)
{
    var current = _head;

    while (current != null)
    {
        if (current.Data.Equals(oldData))
        {
            current.Data = newData;
            return true;
        }
        current = current.Next;
    }

    return false;
}
///Updates the value at a specific index in the list
/// Returns true if successful, false if the index is out of bounds

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
}///Checks if an element matching the specified data exists in the list
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
}///Returns the element at the specified index.
/// </summary>
/// <param name="index">The index of the element to retrieve.</param>
/// <returns>The element at the specified index.</returns>
public T Get(int index)
{
    var current = _head;
    int currentIndex = 0;

    while (current != null)
    {
        if (currentIndex == index)
            return current.Data;

        current = current.Next;
        currentIndex++;
    }

    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
}


}
