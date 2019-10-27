using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper101.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<Products> ListOfProducts { get; set; }
    }
}
