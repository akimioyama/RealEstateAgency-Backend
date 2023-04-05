using RealEstateAgency.Domain;
using RealEstateAgency.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RealEstateAgency.EntityFramework.Repository.Interfaces
{
    public interface IArendatelsSelects
    {
        public string CreateArendatels(Arendatels arendatels);
        public bool UpdateArendatels(Arendatels arendatels);
        public bool DeleteArendatels(int id);
        public Arendatels GetArendatels(string login, string password);
        public List<Arendatels> GetAllArendatels();

    }
}
