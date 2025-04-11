using NUnit.Framework;

namespace LinkedListTests
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void TestInsert()
        {
            var list = new LinkedList<int>();
            list.Insert(10);

            Assert.AreEqual(10, list.Get(0)); // Check if the first element inserted is 10
        }
    }
}