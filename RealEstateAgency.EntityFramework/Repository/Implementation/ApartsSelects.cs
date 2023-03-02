using Microsoft.EntityFrameworkCore.Query;
using RealEstateAgency.Domain;
using RealEstateAgency.EntityFramework.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.EntityFramework.Repository.Implementation
{
    public class ApartsSelects : IApartsSelects
    {
        //private RealEstateAgencyContext db;
        //public ApartsSelects()
        //{
        //    db = new RealEstateAgencyContext();
        //}

        public bool CreateApart(Aparts nreApart)
        {
            throw new NotImplementedException();
        }

        public bool DeleteApart(int id)
        {
            throw new NotImplementedException();
        }

        public Aparts GetApartById(int id)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                var apart = db.Aparts.Where(p => p.Id == id).FirstOrDefault();
                return apart;
            }
        }

        public List<Aparts> GetApartsAll(int limit, int page)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                int start = limit * (page - 1);

                var aparts = db.Aparts.Skip(start).Take(limit).ToList();
                return aparts;
            }
        }

        public bool UpdateApart(Aparts nreApart)
        {
            throw new NotImplementedException();
        }
    }
}
