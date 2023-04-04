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
            Assert.AreEqual("Struma", hotel.FullName);
            Assert.AreEqual("3", hotel.Category);
        }

   
    }
}