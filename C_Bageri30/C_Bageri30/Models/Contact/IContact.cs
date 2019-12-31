using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Bager30.Models
{
    // interface för åtkomst av klassen Contact
    // visar möjliga accessvägar till Contact
    public interface IContact
    {
        // hämtar företagets kontaktinfo
        Contact GetContactById(int Id);
    }
}
