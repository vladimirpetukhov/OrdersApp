using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.API.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public long Views { get; set; }
        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Like> Likers { get; set; } = new List<Like>();
        public virtual ICollection<ProductOrders> Orders { get; set; } = new HashSet<ProductOrders>();
        //public virtual ICollection<Meassure> Meassures { get; set; } = new List<Meassure>();
        public virtual ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();
    }
}
