using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgency.Domain;
using RealEstateAgency.Domain.DTO;

namespace RealEstateAgency.Application.Serviсes.Interfaces
{
    public interface IAccountService
    {
        public AccountDTO GetJWTToken(LoginDTO loginDTO);

    }
}
