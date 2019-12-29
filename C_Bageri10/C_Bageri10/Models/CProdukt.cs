using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Bageri_10.Models
{
    public class CProdukt
    {
        public int ProduktId { get; set; }
        public string Namn { get; set; }
        public int Pris { get; set; }
        public int LagerSaldo { get; set; }
    }
}