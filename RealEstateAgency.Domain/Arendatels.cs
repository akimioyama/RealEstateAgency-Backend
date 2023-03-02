using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.Domain
{
    public class Arendatels
    {
        [Key]

        public int id_arendatel { get; set; }
        public string FIO { get; set; }
        public string telefon { get; set; }
        public string login { get; set; }  
        public string password { get; set; }
    }
}
