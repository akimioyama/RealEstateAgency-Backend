using RealEstateAgency.Domain;
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
        public bool CreateApart(Aparts newApart);
        public bool UpdateApart(Aparts newApart);
        public bool DeleteApart(int id);
        public int TotalPages();
    }
}
