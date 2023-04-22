using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgency.Domain;
using RealEstateAgency.Domain.DTO;

namespace RealEstateAgency.Application.Serviсes.Interfaces
{
    public interface IApartsServices
    {
        public Aparts GetApartByIdServices(int id);
        public List<Aparts> GetApartsAllServiсes(int limit, int page);
        public List<Aparts> GetApartsWhisFiltersServices(int limit, int page, FilterDTO filter);
        public List<string> GetStreetAllServices();
        public string CreateApartServiсes(Aparts newApart, string jwt);
        public string UpdateApartServiсes(ChangeApartDTO changeApartDTO, string jwt);
        public bool DeleteApartServiсes(int id, string jwt);
        public int TotalPagesServiсes();
        public int TotalPagesWhisFilterServiсes(FilterDTO filter);
        public List<Aparts> GetAllApartsByUserIdServices(string jwt);
        public string ChangeForRentServices(int id, string jwt);
        public string UpdateApartAdminServiсes(ChangeApartDTO changeApartDTO, string Adminjwt);
        public bool DeleteAparAdmintServiсes(int id, string Adminjwt);
    }
}
