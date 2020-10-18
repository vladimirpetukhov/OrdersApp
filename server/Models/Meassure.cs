using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.API.Models
{
    public class Meassure
    {
        public int Id { get; set; }
        public MeassureType MeassureType { get; set; }
        public double Quantity { get; set; }
    }
}
