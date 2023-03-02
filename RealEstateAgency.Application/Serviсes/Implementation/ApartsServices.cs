using Microsoft.Extensions.Configuration;
using RealEstateAgency.Application.Serviсes.Interfaces;
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
    public class ApartsServices : IApartsServices
    {
        IConfiguration _configuration;
        IApartsSelects apartsSelects;
        public ApartsServices(IConfiguration conf)
        {
            _configuration = conf;
            apartsSelects = new ApartsSelects();
        }

        public bool CreateApartServiсes(Aparts nreApart)
        {
            throw new NotImplementedException();
        }

        public bool DeleteApartServiсes(int id)
        {
            throw new NotImplementedException();
        }

        public Aparts GetApartByIdServices(int id)
        {
            try
            {
                Aparts aparts = apartsSelects.GetApartById(id);
                if(aparts != null)
                {
                    return aparts;
                };
                return null;
            }
            catch
            {
                return null;
            }
        }

        public List<Aparts> GetApartsAllServiсes(int limit, int page)
        {
            try
            {
                List<Aparts> apartsList = apartsSelects.GetApartsAll(limit, page);
                if( apartsList != null)
                {
                    return apartsList;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateApartServiсes(Aparts nreApart)
        {
            throw new NotImplementedException();
        }
    }
}
