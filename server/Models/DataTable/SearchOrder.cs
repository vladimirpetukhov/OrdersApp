using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.API.Models.DataTable
{
    public class SearchOrder
    {
        public int column { get; set; }
        public string dir { get; set; }
    }
}
