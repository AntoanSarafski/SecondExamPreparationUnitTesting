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


    }
}