

namespace Server.API.Dtos.Categories
{
    using Models;
    using System.Collections.Generic;
    public class CategoryListForResponse
    {
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
