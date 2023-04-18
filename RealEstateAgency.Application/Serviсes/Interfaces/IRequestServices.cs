using RealEstateAgency.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.Application.Serviсes.Interfaces
{
    public interface IRequestServices
    {
        public string CreateRequestServices(Request request);
        public string UpdateRequestServices(Request request);
        public List<Request> GetRequestServices(string status, string jwt);
    }
}
