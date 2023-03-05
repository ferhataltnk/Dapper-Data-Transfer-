using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
      
       
        public int ProductId { get; set; }
        public string Name { get; set; } 
        public decimal Price { get; set; }

    }
}
