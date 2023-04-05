using RealEstateAgency.Application.Serviсes.Interfaces;
using RealEstateAgency.Domain.DTO;
using RealEstateAgency.Domain;
using RealEstateAgency.EntityFramework.Repository.Implementation;
using RealEstateAgency.EntityFramework.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.Application.Serviсes.Implementation
{
    public class ArendatelsServices : IArendatelsServices
    {
        IArendatelsSelects arendatelsSelects;
        public ArendatelsServices()
        {
            arendatelsSelects = new ArendatelsSelects();
        }
        public bool ChangeUserServices(ArendatelsDTO arendatels, int userId)
        {
            throw new NotImplementedException();
        }

        public string CreateUserServices(ArendatelsDTO arendatels)
        {
            return arendatelsSelects.CreateArendatels(new Arendatels()
            {   login = arendatels.login,
                password = arendatels.password,
                FIO = arendatels.FIO,
                email = arendatels.email,
                telefon = arendatels.telepon
            }
            );
        }

        public bool DeleteuserServices(int id)
        {
            throw new NotImplementedException();
        }

        public List<ArendatelsDTO> GetArendatelsServices()
        {
            throw new NotImplementedException();
        }
        public Arendatels GetArendatelsByLoginAndPassword(string login, string password)
        {
            return arendatelsSelects.GetArendatels(login, password);
        }
    }
}
