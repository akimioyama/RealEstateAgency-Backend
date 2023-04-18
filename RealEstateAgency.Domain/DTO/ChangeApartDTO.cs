using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.Domain.DTO
{
    public class ChangeApartDTO
    {
        public int id { get; set; }
        public int price { get; set; }
        public bool furniture { get; set; }
        public bool technic { get; set; }
        public bool evro_repair { get; set; }
        public bool animals { get; set; }
        public bool elevator { get; set; }
        public string walls { get; set; }
        public string text { get; set; }

    }
}
