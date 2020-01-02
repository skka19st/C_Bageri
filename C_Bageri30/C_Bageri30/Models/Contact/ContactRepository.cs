using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Repository innehåller de mest grundläggande anropen mot databasen
// ta bort, lägga till, hämta en specifik, hämta alla
// tänk "grundstomme"
namespace C_Bageri30.Models
{
    public class ContactRepository : IContact
    {
        // interfacet till klassen Contact kopplas hit, dvs 
        // klassen implementerar interface IContact

        // databas-objekt 
        private readonly AppDatabase database;

        // constructor
        public ContactRepository(AppDatabase appDbContext)
        {
            database = appDbContext;
        }

        // hämtar företagets kontaktinfo
        public Contact GetContactById(int inId)
        {
            return database.DbContact
                        .Where(c => c.Id == inId).FirstOrDefault();
        }
    }
}
