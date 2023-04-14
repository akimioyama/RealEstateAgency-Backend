using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgency.Domain;
using RealEstateAgency.Domain.DTO;

namespace RealEstateAgency.Application.Serviсes.Interfaces
{
    public interface IArendatelsServices
    {
        public string CreateUserServices(ArendatelsDTO arendatels);
        public Arendatels GetArendatelsByLoginAndPassword(string login, string password);
        public bool DeleteuserServices(int id);
        public string ChangeUserServices(ArendatelsDTO arendatels, string jwt);
        public List<ArendatelsDTO> GetArendatelsServices();
        public Arendatels GetArendatelByJWTServices(string jwt);

    }
}
