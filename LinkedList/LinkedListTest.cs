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
