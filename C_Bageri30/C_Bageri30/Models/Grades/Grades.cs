using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

// Required = obligatoriskt fält
// Display = ledtext (i formuläret)
// StringLength = max antal tecken
// RegularExpression = egenskapade villkor

namespace C_Bageri30.Models
{
    public class Grades
    {
        public string Id { get; set; }
        public int ProductId { get; set; }        
        public int Grade { get; set; }               // betygskala: 1-5
    }
}
