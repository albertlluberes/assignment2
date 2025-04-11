using System.Collections.Generic;  
using LinkedListNamespace;          

namespace LinkedListTests
{
    public class LinkedListTests
    {
        [Fact]
        public void Insert_()
        {
            
            LinkedListNamespace.LinkedList<string> list = new LinkedListNamespace.LinkedList<string>();
            list.Insert("first");
            list.Insert("second");
            Assert.Equal("second", list.Get(1));
        }

        [Fact]
        public void InsertAtIndex_()
        {
            LinkedListNamespace.LinkedList<string> list = new LinkedListNamespace.LinkedList<string>();
            list.Insert("a");
            list.Insert("b");
            list.Insert("d");

            list.InsertAtIndex(2, "c");

            Assert.Equal("c", list.Get(2));
        }

        [Fact]
        public void DeleteElement_()
        {
            LinkedListNamespace.LinkedList<string> list = new LinkedListNamespace.LinkedList<string>();
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
            LinkedListNamespace.LinkedList<string> list = new LinkedListNamespace.LinkedList<string>();
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
            LinkedListNamespace.LinkedList<string> list = new LinkedListNamespace.LinkedList<string>();
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
        public void UpdateElement_ReturnsFalseIfElementNotFound()
        {
            LinkedListNamespace.LinkedList<string> list = new LinkedListNamespace.LinkedList<string>();
            list.Insert("a");
            list.Insert("b");

            bool result = list.UpdateElement("z", "x");

            Assert.False(result);
        }

        [Fact]
        public void UpdateElementAtIndex()
        {
            LinkedListNamespace.LinkedList<string> list = new LinkedListNamespace.LinkedList<string>();
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
            LinkedListNamespace.LinkedList<string> list = new LinkedListNamespace.LinkedList<string>();
            list.Insert("a");
            list.Insert("b");

            bool result = list.UpdateElementAtIndex(5, "x");

            Assert.False(result);
        }

        [Fact]
        public void Find()
        {
            LinkedListNamespace.LinkedList<string> list = new LinkedListNamespace.LinkedList<string>();
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
            LinkedListNamespace.LinkedList<string> list = new LinkedListNamespace.LinkedList<string>();
            list.Insert("a");
            list.Insert("b");

            Assert.False(list.Find("z"));
        }

        [Fact]
        public void Get()
        {
            LinkedListNamespace.LinkedList<int> list = new LinkedListNamespace.LinkedList<int>();
            list.Insert(10);
            list.Insert(20);
            list.Insert(30);

            Assert.Equal(10, list.Get(0));
            Assert.Equal(20, list.Get(1));
            Assert.Equal(30, list.Get(2));
        }

        [Fact]
        public void Get_ThrowsExceptionIfIndexOutOfRange()
        {
            LinkedListNamespace.LinkedList<int> list = new LinkedListNamespace.LinkedList<int>();
            list.Insert(10);

            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(2));
        }
    }
}
