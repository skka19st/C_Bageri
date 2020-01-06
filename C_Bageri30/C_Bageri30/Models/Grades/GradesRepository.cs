using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Bageri30.Models
{
    // Repository innehåller de mest grundläggande anropen mot databasen
    // ta bort, lägga till, hämta en specifik, hämta alla
    // tänk "grundstomme"
    public class GradesRepository : IGrades
    {
        // interfacet till klassen Grades kopplas hit, dvs 
        // klassen implementerar interface IGrades

        // databas-objekt 
        private readonly AppDatabase database;

        // constructor
        public GradesRepository(AppDatabase appDbContext)
        {
            database = appDbContext;
        }

        // hämta alla betyg
        public IEnumerable<Grades> GetGradesAll()
        {
            return database.DbGrades;
        }

        // hämta alla betyg för angiven produkt
        public IEnumerable<Grades> GetGradesByProduct(int inProjektId)
        {
            return database.DbGrades.
                            Where(c => c.ProductId == inProjektId);
            //Where(c => c.ProductId == inProjektId).ToList();
        }

        // lägg till nytt betyg
        public void AddGrades(Grades inGrades)
        {
            database.DbGrades.Add(inGrades);
            database.SaveChanges();
        }
    }
}

