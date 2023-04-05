using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.Domain
{
    public class Arendatels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_arendatel { get; set; }
        public string FIO { get; set; }
        public string telefon { get; set; }
        public string email { get; set; }
        public string login { get; set; }  
        public string password { get; set; }
        public string role { get; set; }
        public bool status { get; set; }
    }
}
