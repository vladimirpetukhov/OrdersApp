using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.API.Models
{
    public class ProductOrders
    {
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }

        public string ProductId { get; set; }
        public virtual Product Product {get;set;}
    }
}
