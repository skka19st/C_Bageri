using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Bageri_10.Models
{
    // kopplas ihop med interfacet för klassen CProdukt
    public class MockProduktRepository : IProdukt
    {

        // interfacet till klassen IProdukt kopplas hit, dvs 
        // klassen implementerar interface IProdukt
        // anrop av metoden AllaProdukter (i interfacet) hamnar här och 
        // skickar tillbaka en lista (IENumerable) av produkter

        // tillfälligt testdata, används för att testa data utan databasanrop
        // kallas att "mocka databasanrop" (simulera databasanrop)

        public IEnumerable<CProdukt> AllaProdukter =>
            new List<CProdukt>
            {
                new CProdukt {ProduktId = 1, Namn="Kardemummabulle", Pris=20, LagerSaldo=50},
                new CProdukt {ProduktId = 2, Namn="Princesstårta", Pris=100, LagerSaldo=5},
                new CProdukt {ProduktId = 3, Namn="Kladdkaka", Pris=15, LagerSaldo=20},
                new CProdukt {ProduktId = 4, Namn="Mazarin", Pris=10, LagerSaldo=40}
            };
    }
}
