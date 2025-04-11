[Fact]
public void Insert_AppendsElementToTail()
{
    var list = new LinkedList<string>();
    list.Insert("first");
    list.Insert("second");
    Assert.Equal("second", list.Get(1));
}