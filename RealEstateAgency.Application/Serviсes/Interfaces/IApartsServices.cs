using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgency.Domain;

namespace RealEstateAgency.Application.Serviсes.Interfaces
{
    public interface IApartsServices
    {
        public Aparts GetApartByIdServices(int id);
        public List<Aparts> GetApartsAllServiсes(int limit, int page);
        public bool CreateApartServiсes(Aparts nreApart);
        public bool UpdateApartServiсes(Aparts nreApart);
        public bool DeleteApartServiсes(int id);
        public int TotalPagesServiсes();
    }
}
