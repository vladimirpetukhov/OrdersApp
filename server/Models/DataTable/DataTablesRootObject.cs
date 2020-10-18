using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.API.Models.DataTable
{
    public class DataTablesRootObject
    {
        public int draw { get; set; }


        public List<Column> columns { get; set; }


        public List<SearchOrder> searchOrder { get; set; }


        public int start { get; set; }


        public int length { get; set; }


        public Search search { get; set; }
    }
}
