using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.Domain.DTO
{
    public class ArendatelsDTO
    {
        public string login { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string telepon { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string FIO { get; set; } = string.Empty;
    }
}
