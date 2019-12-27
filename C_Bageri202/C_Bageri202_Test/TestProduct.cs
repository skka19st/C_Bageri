using NUnit.Framework;
using C_Bageri202.Models;
using System.Collections.Generic;

namespace C_Bageri202_Test
{
    public class TestProduct
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestProductOK()
        {
            // Arrange 
            ProductRepositoryMock datamock = new ProductRepositoryMock();

            // Act
            Product product = datamock.GetProductById(1);

            // Assert
            Assert.That(product.Id == 1, "Produkt saknas");
            Assert.That(product.Name == "Kardemummabulle", "fel namn");
            Assert.That(product.Besk == "beskrivning", "fel besk");
            Assert.That(product.Price == 20, "fel pris");
        }

        [Test]
        public void TestProductNotOK()
        {
            // Arrange 
            ProductRepositoryMock datamock = new ProductRepositoryMock();

            // Act
            Product product = datamock.GetProductById(1);

            // Assert
            Assert.That(product.Name != "Kardemumma bulle", "rätt namn");
            Assert.That(product.Besk != "beskrivn", "rätt besk");
            Assert.That(product.Price != 0, "rätt pris");

        }

        [Test]
        public void TestProductPriceOK()
        {
            // Arrange 
            ProductRepositoryMock datamock = new ProductRepositoryMock();

            // Act
            Product produkt1 = new Product();
            Product produkt2 = new Product();
            Product produkt3 = new Product();
            Product produkt4 = new Product();
            Product produkt5 = new Product();

            produkt1 = datamock.GetProductById(1);
            produkt2 = datamock.GetProductById(2);
            produkt3 = datamock.GetProductById(3);
            produkt4 = datamock.GetProductById(4);
            produkt5 = datamock.GetProductById(5);

            // Assert
            Assert.That(produkt1.Price == 20, "fel belopp");
            Assert.That(produkt2.Price == 100, "fel belopp");
            Assert.That(produkt3.Price == 15, "fel belopp");
            Assert.That(produkt4.Price == 10, "fel belopp");
            Assert.That(produkt5.Price == 5, "fel belopp");
        }

        [Test]
        public void TestProductPriceNotOK()
        {
            // Arrange 
            ProductRepositoryMock datamock = new ProductRepositoryMock();

            // Act
            Product produkt1 = new Product();
            Product produkt2 = new Product();
            Product produkt3 = new Product();
            Product produkt4 = new Product();
            Product produkt5 = new Product();

            produkt1 = datamock.GetProductById(1);
            produkt2 = datamock.GetProductById(2);
            produkt3 = datamock.GetProductById(3);
            produkt4 = datamock.GetProductById(4);
            produkt5 = datamock.GetProductById(5);

            // Assert
            Assert.That(produkt1.Price != 0, "rätt belopp");
            Assert.That(produkt2.Price != 0, "rätt belopp");
            Assert.That(produkt3.Price != 0, "rätt belopp");
            Assert.That(produkt4.Price != 0, "rätt belopp");
            Assert.That(produkt5.Price != 0, "rätt belopp");
        }
    }
}