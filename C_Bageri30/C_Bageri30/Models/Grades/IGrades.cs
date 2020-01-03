using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Bageri30.Models
{
    // interface för åtkomst av klassen Grades
    // visar möjliga accessvägar till Grades
    public interface IGrades
    {
        IEnumerable<Grades> GetGradesAll();
        IEnumerable<Grades> GetGradesByProduct(int id);
        void AddGrades(Grades inGrades);
    }
}
