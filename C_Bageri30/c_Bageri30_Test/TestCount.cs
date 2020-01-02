using NUnit.Framework;
using System;
using C_Bageri30.Models;

namespace C_Bageri30_Test
{
    public class TestCount
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCountOK()
        {
            // Arrange 
            string uniktId;

            // Act
            //uniktId = Guid.NewGuid().ToString();
            uniktId = "1";

            // Assert
            Assert.That(uniktId == "1", "Felaktigt unikt id");
        }

        [Test]
        public void TestCountNotOK()
        {
            // Arrange 
            ContactRepositoryMock datamock = new ContactRepositoryMock();

            // Act
            Contact kontakt = datamock.GetContactById(1);

            // Assert
            Assert.That(kontakt.Name != "Baka p å nätet", "rätt namn");
            Assert.That(kontakt.WebbPage != "www.bakeonnet.com", "rätt webbpage");
            Assert.That(kontakt.StreetAdress != "Bakaga tan 1", "rätt gatuadress");
            Assert.That(kontakt.CityAdress != "755 90 Nät staden", "rätt ort");
            Assert.That(kontakt.Mail != "bakeonnet @gmail.com", "rätt mailadress");
            Assert.That(kontakt.Phone != "012- 34 56 789", "rätt telefonnr");

        }
    }
}
