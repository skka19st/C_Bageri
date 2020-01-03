using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Bageri30.Models
{
    // kopplas ihop med interfacet för klassen Product
    public class ProductRepository : IProduct
    {
        // interfacet till klassen Product kopplas hit, dvs 
        // klassen implementerar interface IProdukt

        // databas-objekt 
        private readonly AppDatabase database;

        // constructor
        public ProductRepository(AppDatabase appDbContext)
        {
            database = appDbContext;
        }

        public IEnumerable<Product> AllProducts
        {
            get
            {
                return database.DbProduct;
            }
        }

        public Product GetProductById(int inId)
        {
            return database.DbProduct.FirstOrDefault
                    (p => p.Id == inId);
        }
    }
}
