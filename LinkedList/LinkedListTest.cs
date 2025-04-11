[Fact]
public void Insert_AppendsElementToTail()
{
    var list = new LinkedList<string>();
    list.Insert("first");
    list.Insert("second");
    Assert.Equal("second", list.Get(1));
}
[Fact]
public void InsertAtIndex_InsertsElementAtCorrectPosition()
{
    var list = new LinkedList<string>();
    list.Insert("a");
    list.Insert("b");
    list.Insert("d");

    list.InsertAtIndex(2, "c");

    Assert.Equal("c", list.Get(2));
}
[Fact]
public void DeleteElement_()
{
    var list = new LinkedList<string>();
    list.Insert("a");
    list.Insert("b");
    list.Insert("c");

    bool result = list.DeleteElement("b");

    Assert.True(result);
    Assert.Equal("a", list.Get(0));
    Assert.Equal("c", list.Get(1));
}
[Fact]
public void DeleteAtIndex_()
{
    var list = new LinkedList<string>();
    list.Insert("a");
    list.Insert("b");
    list.Insert("c");

    bool result = list.DeleteAtIndex(1);

    Assert.True(result);
    Assert.Equal("a", list.Get(0));
    Assert.Equal("c", list.Get(1));
}
[Fact]
public void UpdateElement_()
{
    var list = new LinkedList<string>();
    list.Insert("a");
    list.Insert("b");
    list.Insert("c");

    bool result = list.UpdateElement("b", "x");

    Assert.True(result);
    Assert.Equal("a", list.Get(0));
    Assert.Equal("x", list.Get(1));
    Assert.Equal("c", list.Get(2));
}

[Fact]
public void UpdateElement_()
{
    var list = new LinkedList<string>();
    list.Insert("a");
    list.Insert("b");

    bool result = list.UpdateElement("z", "x");

    Assert.False(result);
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
[Fact]
public void Find_Returns()
{
    var list = new LinkedList<string>();
    list.Insert("a");
    list.Insert("b");
    list.Insert("c");

    Assert.True(list.Find("b"));
    Assert.True(list.Find("a"));
    Assert.True(list.Find("c"));
}

[Fact]
public void Find_ReturnsFalseIfElementDoesNotExist()
{
    var list = new LinkedList<string>();
    list.Insert("a");
    list.Insert("b");

    Assert.False(list.Find("z"));
}



