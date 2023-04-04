using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Hotel hotel;
        [SetUp]
        public void Setup()
        {
            hotel = new Hotel("Struma", 3);
        }

        [TearDown]
        public void TearDown()
        {
            Hotel hotel = null;
        }


        [Test]
        public void ConstructorSetsFullNameAndCategoryCorrectly()
        {
            string expectedFullName = "Struma";
            int expectedCategory = 1;

            Hotel testConstructorHotel = new Hotel(expectedFullName, expectedCategory);

            Assert.AreEqual(expectedFullName, testConstructorHotel.FullName);
            Assert.That(expectedCategory, Is.EqualTo(testConstructorHotel.Category));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("       ")]
        public void FullNameSetterThrowsExceptionWhenValueIsNullOrWhiteSpace(string fullName)
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(fullName, 3));
        }

        [TestCase(-10)]
        [TestCase(0)]
        [TestCase(6)]
        [TestCase(10)]
        public void CategortySetterThrowsExceptionWhenValueOutOfRange(int category)
        {
            Assert.Throws<ArgumentException>(() => new Hotel("Struma", category));
        }

        [Test]
        public void AddRoomAddsRoomCorrectly()
        {
            Room room = new(3, 100);

            hotel.AddRoom(room);

            Assert.AreEqual(1, hotel.Rooms.Count);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void BookRoomThrowsExceptionWhenThereAreNoAdults(int adults)
        {
            Room room = new(3, 300);

            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(adults, 2, 3, 500));
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void BookRoomThrowsExceptionWhenChildrenAreLessThanZero(int children)
        {
            Room room = new(3, 300);

            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, children, 3, 500));
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void BookRoomThrowsExceptionWhenReservationDurationIsLessThanOne(int duration)
        {
            Room room = new(3, 300);

            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, 2, duration, 500));
        }

        [Test]
        public void BookRoomNoTurnoverWhenNotEnoughBeds()
        {

            Room room = new(3, 300);

            hotel.AddRoom(room);

            hotel.BookRoom(3, 1, 2, 50);
            Assert.That(hotel.Turnover, Is.EqualTo(0));
        }


        [Test]
        public void BookRoomNoTurnoveIfBudgetNotEnough()
        {

            Room room = new(3, 50);

            hotel.AddRoom(room);

            hotel.BookRoom(2, 1, 2, 50);
            Assert.That(hotel.Turnover, Is.EqualTo(0));
        }

        [Test]
        public void BookRoomNoTurnoveIfBudgetNotEnoughAndBedCapacityNotEnough()
        {

            Room room = new(3, 50);

            hotel.AddRoom(room);

            hotel.BookRoom(4, 2, 2, 50);
            Assert.That(hotel.Turnover, Is.EqualTo(0));
        }

        [TestCase(100)]
        [TestCase(200)]
        public void BookRoomTestWithCorrectBudgetAndEnoughBedCapaciry(double budget)
        {
            Room room = new Room(2, 50);
            hotel.AddRoom(room);
            hotel.BookRoom(2, 0, 2, budget);

            Assert.AreEqual(1, hotel.Bookings.Count);
            Assert.AreEqual(100, hotel.Turnover);
        }

        [TestCase(5)]
        [TestCase(10)]
        public void BookRoomTestWithCorrectBudgetAndEqualAndMoreBedCapaciry(int bn)
        {
            Room room = new Room(, 50);
            hotel.AddRoom(room);
            hotel.BookRoom(2, 0, 2, budget);

            Assert.AreEqual(1, hotel.Bookings.Count);
            Assert.AreEqual(100, hotel.Turnover);
        }
    }
}