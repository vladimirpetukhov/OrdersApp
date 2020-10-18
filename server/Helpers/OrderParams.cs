using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.API.Helpers
{
    public class OrderParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
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
