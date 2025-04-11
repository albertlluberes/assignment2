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
[Fact]
public void UpdateElementAtIndex()
{
    var list = new LinkedList<string>();
    list.Insert("a");
    list.Insert("b");
    list.Insert("c");

    bool result = list.UpdateElementAtIndex(1, "x");

    Assert.True(result);
    Assert.Equal("a", list.Get(0));
    Assert.Equal("x", list.Get(1));
    Assert.Equal("c", list.Get(2));
}

[Fact]
public void UpdateElementAtIndex_ReturnsFalseIfOutOfBounds()
{
    var list = new LinkedList<string>();
    list.Insert("a");
    list.Insert("b");

    bool result = list.UpdateElementAtIndex(5, "x");

    Assert.False(result);
}


