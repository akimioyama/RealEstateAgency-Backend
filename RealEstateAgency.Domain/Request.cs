using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAgency.Domain
{
    public class Request
    {
        [Key]
        public int id_request { get; set; }
        public string name { get; set; }
        public string telepone { get; set; }
        public string email { get; set; }
        public string text { get; set; }
        public string status { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int? id_empl { get; set; }
    }
}
