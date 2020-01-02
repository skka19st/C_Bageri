using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C_Bageri30.Models;

namespace C_Bageri30.ViewModels
{
    // vy som skapar data till produkt-listan
    public class ProductListViewModel
    {
        public IEnumerable<Product> Lista { get; set; }
    }
}
