using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Bager30.Models
{
    // kopplas ihop med interfacet för klassen Product
    public class ProductRepositoryMock : IProduct
    {
        // interfacet till klassen Product kopplas hit, dvs 
        // klassen implementerar interface IProduct
        // tillfälligt testdata, används för att testa data utan databasanrop
        // kallas att "mocka databasanrop" (simulera databasanrop)
        public IEnumerable<Product> AllProducts =>
            new List<Product>
            {
                new Product {Id = 1, Name="Kardemummabulle", Besk = "beskrivning", Price=20},
                new Product {Id = 2, Name="Princesstårta", Besk = "beskrivning", Price=100},
                new Product {Id = 3, Name="Kladdkaka", Besk = "beskrivning", Price=15},
                new Product {Id = 4, Name="Mazarin", Besk = "beskrivning", Price=10},
                new Product {Id = 5, Name="Skorpa", Besk = "beskrivning", Price=5}
            };

        public Product GetProductById(int inProdukt)
        {
            return AllProducts.FirstOrDefault(p => p.Id == inProdukt);
        }
    }
}
