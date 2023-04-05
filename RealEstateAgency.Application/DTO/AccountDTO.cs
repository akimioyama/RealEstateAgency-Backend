using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.Application.DTO
{
    public class AccountDTO
    {
        public string JWTToken { get; set; }
        public string Role { get; set; }
        public string FIO { get; set; }
    }
}
