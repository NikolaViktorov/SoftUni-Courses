using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        Database.Database db;
        [SetUp]
        public void Setup()
        {
            db = new Database.Database();      
        }
        [Test]
        public void ConstructurTakesIntegers()
        {
            db = new Database.Database(new int[] { 1, 2, 3, 4, 5 });
        }
        [Test]
        public void AddElementToAvailableSlot()
        {
            int expectedCount = db.Count + 1;
            db.Add(1);
            Assert.That(db.Count, Is.EqualTo(expectedCount), "Couldn't Add element to db.");
        }
        [Test]
        public void AddElementToTheRightIndex()
        {
            int expectedElementIndex = db.Count;
            db.Add(64);
            int[] copyDB = db.Fetch();
            Assert.That(copyDB[db.Count - 1], Is.EqualTo(64), "Couldn't Add element to right index in db.");
        }
        [Test]
        public void AddElementToFullDatabaseShouldThrowException()
        {
            db = new Database.Database(new int[] { 1, 2, 3 ,4 ,5 ,6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16});
            Assert.That(() => db.Add(1), Throws.InvalidOperationException, "Added element to full db");
        }
        [Test]
        public void RemoveElementInLastSpot()
        {
            db.Add(1);
            int expectedCount = db.Count - 1;
            db.Remove();
            Assert.That(db.Count, Is.EqualTo(expectedCount), "Couldn't remove element");
        }
        [Test]
        public void RemoveElementTheRightIndex()
        {
            db.Add(1);
            db.Add(2);
            int[] copyDB = db.Fetch();
            int expectedElementAtLastIndex = copyDB[copyDB.Length - 2];
            db.Remove();
            copyDB = db.Fetch();
            Assert.That(copyDB[copyDB.Length - 1], Is.EqualTo(expectedElementAtLastIndex), "Couldn't Remove element at right index in db.");
        }
        [Test]
        public void RemovingElementWhenDbIsEmptyShouldThrowException()
        {
            db = new Database.Database(new int[] { });
            Assert.That(() => db.Remove(), Throws.InvalidOperationException, "Db removes element even when empty");
        }
    }
}