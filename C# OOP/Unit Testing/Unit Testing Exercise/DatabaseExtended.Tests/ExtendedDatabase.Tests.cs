using NUnit.Framework;
using ExtendedDatabase;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        ExtendedDatabase.ExtendedDatabase db;
        [SetUp]
        public void Setup()
        {
            db = new ExtendedDatabase.ExtendedDatabase();
        }
        [Test]
        public void AddValidPersonToDb()
        {
            int expectedCount = db.Count + 1;
            Person person = new Person(1, "Pesho");
            db.Add(person);
            Assert.That(db.Count, Is.EqualTo(expectedCount), "Didn't add a person to db.");
        }
        [Test]
        public void AddedPersonWithoutUniqueIdToDbShouldThrowException()
        {
            Person person = new Person(1, "Pesho");
            Person sameIdPerson = new Person(1, "Gosho");
            db.Add(person);
            Assert.That(() => db.Add(sameIdPerson), Throws.InvalidOperationException, "Added person to db with same id person already in it.");
        }
        [Test]
        public void AddedPersonWithoutUniqueNameToDbShouldThrowException()
        {
            Person person = new Person(1, "Pesho");
            Person sameNamePerson = new Person(3, "Pesho");
            db.Add(person);
            Assert.That(() => db.Add(sameNamePerson), Throws.InvalidOperationException, "Added person to db with same name person already in it.");
        }
        [Test]
        public void AddValidPersonToFullDbShouldThrowException()
        {
            #region
            Person p1 = new Person(1, "a1");
            Person p2 = new Person(2, "a2");
            Person p3 = new Person(3, "a3");
            Person p4 = new Person(4, "a4");
            Person p5 = new Person(5, "a5");
            Person p6 = new Person(6, "a6");
            Person p7 = new Person(7, "a7");
            Person p8 = new Person(8, "a8");
            Person p9 = new Person(9, "a9");
            Person p10 = new Person(10, "a10");
            Person p11 = new Person(11, "a11");
            Person p12 = new Person(12, "a12");
            Person p13 = new Person(13, "a13");
            Person p14 = new Person(14, "a14");
            Person p15 = new Person(15, "a15");
            Person p16 = new Person(16, "a16");
            db = new ExtendedDatabase.ExtendedDatabase(new Person[16] { p1, p2, p3, p4, p5, p6, p7, p8, p9 ,p10, p11, p12, p13, p14,p15, p16});
            #endregion
            Assert.That(() => db.Add(new Person(14213, "yett")), Throws.InvalidOperationException, "Added person to full db.");
        }
        [Test]
        public void RemovePersonFromDb()
        {
            Person person = new Person(1, "Pesho");
            db.Add(person);
            int expectedCount = db.Count - 1;
            db.Remove();
            Assert.That(db.Count, Is.EqualTo(expectedCount), "Didn't remove a person from db.");
        }
        [Test]
        public void RemovePersonFromEmptyDbShouldThrowException()
        {
            db = new ExtendedDatabase.ExtendedDatabase();
            while (db.Count > 0)
            {
                db.Remove();
            }
            Assert.That(() => db.Remove(), Throws.InvalidOperationException, "Remove a person from empty db.");
        }
        [Test]
        public void FindByUsername()
        {
            Person person = new Person(1, "Gosho");
            db.Add(person);
            Person samePersonExpected = db.FindByUsername("Gosho");
            Assert.That(samePersonExpected.UserName, Is.EqualTo(person.UserName), "Person doesn't match real person.");
        }
        [Test]
        public void FindByUsernameWithUsernameThatIsNullShouldThrowException()
        {
            Assert.That(() => db.FindByUsername(null), Throws.ArgumentNullException, "Found person with parameter NULL.");
        }
        [Test]
        public void FindByUsernameWithUsernameThatIsNotInDbShouldThrowException()
        {
            Assert.That(() => db.FindByUsername("RandomNameThatDoesNotExistForSure"), Throws.InvalidOperationException, "Found person with parameter NULL.");
        }
        [Test]
        public void FindById()
        {
            Person person = new Person(1, "Gosho");
            db.Add(person);
            Person samePersonExpected = db.FindById(1);
            Assert.That(samePersonExpected.Id, Is.EqualTo(person.Id), "Person doesn't match real person.");
        }
        [Test]
        public void FindByIdWithIdThatIsNotInDbShouldThrowException()
        {
            Assert.That(() => db.FindById(123321679), Throws.InvalidOperationException, "Found person with parameter NULL.");
        }
        [Test]
        public void FindByIdWithIdThatIsNegativeShouldThrowException()
        {
            Assert.That(() => db.FindById(-123), Throws.ArgumentException, "Found person with Id that is negative.");
        }
    }
}