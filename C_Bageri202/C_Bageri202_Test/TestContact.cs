using NUnit.Framework;
using C_Bageri202.Models;

namespace C_Bageri202_Test
{
    public class TestContact
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestContactOK()
        {
            // Arrange 
            ContactRepositoryMock datamock = new ContactRepositoryMock();

            // Act
            Contact kontakt = datamock.GetContactById(1);

            // Assert
            Assert.That(kontakt.Id == 1, "Kontaktinfo saknas");
            Assert.That(kontakt.Name == "Baka på nätet", "fel namn");
            Assert.That(kontakt.WebbPage == "www.bakeonnet.se", "fel webbpage");
            Assert.That(kontakt.StreetAdress == "Bakagatan 1", "fel gatuadress");
            Assert.That(kontakt.CityAdress == "755 90 Nätstaden", "fel ort");
            Assert.That(kontakt.Mail == "bakeonnet@gmail.com", "fel mailadress");
            Assert.That(kontakt.Phone == "012-34 56 789", "fel telefonnr");
        }

        [Test]
        public void TestContactNotOK()
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