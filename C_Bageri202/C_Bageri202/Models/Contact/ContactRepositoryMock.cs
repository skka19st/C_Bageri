using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Bageri202.Models
{
    // kopplas ihop med interfacet för klassen Contact
    public class ContactRepositoryMock : IContact
    {
        // interfacet till klassen Contact kopplas hit, dvs 
        // klassen implementerar interface IContact
        // tillfälligt testdata, används för att testa data utan databasanrop
        // kallas att "mocka databasanrop" (simulera databasanrop)
        public Contact GetContactById(int inId)
        {
            return new Contact
            {
                Id = 1,
                Name = "Baka på nätet",
                WebbPage = "www.bakeonnet.se",
                StreetAdress = "Bakagatan 1",
                CityAdress = "755 90 Nätstaden",
                Mail = "bakeonnet@gmail.com",
                Phone = "012-34 56 789"
            };
        }
    }
}
