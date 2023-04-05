using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.Domain
{
    public class Aparts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string house { get; set; }
        public string apart { get; set;}
        public int price { get; set; }
        public bool furniture { get; set; }
        public bool technic { get; set; }
        public bool evro_repair { get; set; }
        public bool animals { get; set; }
        public bool elevator { get; set; }
        public bool loggia { get; set; }
        public bool balcony { get; set;}
        public string walls { get; set;}
        public string floor { get; set;}
        public string floors { get; set; }
        public bool new_building { get; set; }
        public string type_of_house { get; set;}
        public string bathroom_shower { get; set;}
        public string kitchen_stove { get; set;}
        public string ceiling_height { get; set; }
        public string lavatory { get; set; }
        public int id_arendatel { get; set; }  
        public string district { get; set; }
        public bool for_rent { get; set; }
        public string count_pic { get; set; }
        public string text { get; set; }
    }
}
