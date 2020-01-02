using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace C_Bageri30.Models
{
    // databas (Entity Framework)
    // DbContext är ett mellanlager som konverterar egen kod (C#) till 
    // databastabell och databastabell till egen kod (C#)
    public class AppDatabase : DbContext
    {
        // constructor
        // måste finnas ett objekt av DbContextOptions
        public AppDatabase(DbContextOptions<AppDatabase> options) : base(options)
        {

        }

        //  kopplar ihop egen kod med databasen genom instansvariabler
        public DbSet<Product> DbProduct { get; set; }
        public DbSet<Contact> DbContact { get; set; }
        public DbSet<Commentary> DbCommentary { get; set; }
    }
}
