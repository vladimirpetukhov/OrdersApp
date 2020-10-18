using Server.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.API
{
    public class OrderLine
    {
        public int Id { get; set; }
        public string ProductCount { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
