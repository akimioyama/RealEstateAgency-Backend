using RealEstateAgency.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.EntityFramework.Repository.Interfaces
{
    public interface IRequestSelects
    {
        public List<Request> getAllRequstStart();
        public List<Request> getAllRequstProcessing(int id_empl);
        public List<Request> getAllRequstFinish();
        public string CreateRequest(Request request);
        public string UpdateRequest(Request request);
    }
}
