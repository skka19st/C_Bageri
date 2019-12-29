using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Bageri_10.Models
{
    // interface för åtkomst av klassen CProdukt
    public interface IProdukt
    {
        // urval enl metoden görs i MockRepository
        IEnumerable<CProdukt> AllaProdukter { get;  }
    }
}
