using Xunit;
using StaticLinkedListNamespace;

namespace StaticLinkedListTests;

public class StaticLinkedListTest
{
    [Fact]
    public void Insert_AddsElementAtTail()
    {
        var list = new StaticLinkedList<int>();
        list.Insert(10);
        Assert.Equal(10, list.Get(0));
    }

    [Fact]
    public void InsertAtIndex_InsertsCorrectly()
    {
        var list = new StaticLinkedList<int>();
        list.Insert(10);
        list.Insert(20);
        list.InsertAtIndex(1, 15);
        Assert.Equal(15, list.Get(1));
    }

    [Fact]
    public void DeleteElement_()
    {
        var list = new StaticLinkedList<int>();
        list.Insert(10);
        list.Insert(20);
        Assert.True(list.DeleteElement(10));
        Assert.False(list.Find(10));
    }

    [Fact]
    public void DeleteAtIndex_()
    {
        var list = new StaticLinkedList<int>();
        list.Insert(10);
        list.Insert(20);
        Assert.True(list.DeleteAtIndex(1));
        Assert.False(list.Find(20));
    }

    [Fact]
    public void UpdateElement_()
    {
        var list = new StaticLinkedList<int>();
        list.Insert(10);
        Assert.True(list.UpdateElement(10, 99));
        Assert.True(list.Find(99));
    }

    [Fact]
    public void UpdateElementAtIndex_()
    {
        var list = new StaticLinkedList<int>();
        list.Insert(10);
        list.UpdateElementAtIndex(0, 50);
        Assert.Equal(50, list.Get(0));
    }

    [Fact]
    public void Find_()
    {
        var list = new StaticLinkedList<int>();
        list.Insert(10);
        Assert.True(list.Find(10));
    }

    [Fact]
    public void Get_()
    {
        var list = new StaticLinkedList<int>();
        list.Insert(5);
        list.Insert(15);
        Assert.Equal(15, list.Get(1));
    }
}
