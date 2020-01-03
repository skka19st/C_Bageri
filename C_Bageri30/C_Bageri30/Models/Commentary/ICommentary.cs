using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Bageri30.Models
{
    // interface för åtkomst av klassen Commentary
    // visar möjliga accessvägar till Commentary
    public interface ICommentary
    {
        IEnumerable<Commentary> GetCommentaryAll();
        IEnumerable<Commentary> GetCommentaryByProduct(int id);
        void AddCommentary(Commentary inCommentary);
    }
}
