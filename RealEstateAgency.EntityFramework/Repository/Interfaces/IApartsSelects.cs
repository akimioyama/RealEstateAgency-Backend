using RealEstateAgency.Domain;
using RealEstateAgency.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.EntityFramework.Repository.Interfaces
{
    public interface IApartsSelects
    {
        public Aparts GetApartById(int id);
        public List<Aparts> GetApartsAll(int limit, int page);
        public List<Aparts> GetAparrtsByUserId(int id);
        public List<string> GetStreetAll();
        public string CreateApart(Aparts newApart);
        public bool UpdateApart(Aparts newApart);
        public bool DeleteApart(int id);
        public int TotalPages();
        public int TotalPagesWhisFilter(FilterDTO filter);
        public List<Aparts> GetApartsWthisFilters(int limit, int page, FilterDTO filterDTO);
        public string ChangeForRent(int id, int id_arend);
    }
}
