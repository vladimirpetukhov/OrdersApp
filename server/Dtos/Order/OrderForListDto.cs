using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.API.Dtos.Order
{
    public class OrderForListDto
    {
        public string Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderNumber { get; set; }
        public string Seller { get; set; }
        public string Buyer { get; set; }
        public string Contact { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Tax { get; set; }
    }
}
