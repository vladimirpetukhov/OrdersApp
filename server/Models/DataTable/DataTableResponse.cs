using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.API.Models.DataTable
{
    public class DataTableResponse<T> where T:class
    {
        public IEnumerable<T> data { get; set; }


        public int draw { get; set; }


        public int recordsFiltered { get; set; }


        public int recordsTotal { get; set; }


        public string error { get; set; }
    }
}
