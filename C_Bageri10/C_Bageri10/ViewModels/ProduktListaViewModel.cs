using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C_Bageri_10.Models;


namespace C_Bageri_10.ViewModels
{
    // vy som hämtar data från model-klassen CProdukt
    public class ProduktListaViewModel
    {
        public IEnumerable<CProdukt> Lista { get; set;  }
    }
}
