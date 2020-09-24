namespace ParkingSystem.Tests
{
    using NUnit.Framework;

    public class SoftParkTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void SoftParkConstructorWorksProperly()
        {
            SoftPark softPark = new SoftPark();
            int expectedCarCount = 12;
            Assert.That(softPark.Parking.Count, Is.EqualTo(expectedCarCount), "SoftPark constructor made too many or not enough cars.");
        }
        [Test]
        public void ParkCarThrowsArgumentExceptionIfParkingSpotDoesNotExist()
        {
            SoftPark softPark = new SoftPark();
            Car car = new Car("a", "123");
            Assert.That(() => softPark.ParkCar("a", car), Throws.ArgumentException);
        }

    }
}