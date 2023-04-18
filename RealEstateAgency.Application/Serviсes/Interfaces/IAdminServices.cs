using RealEstateAgency.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.Application.Serviсes.Interfaces
{
    public interface IAdminServices
    {
        public Employee GetEmployeeByLoginAndPassword(string login, string password);
        public string CreateEm(Employee employee);
        public Employee GetEmployeeById(string jwt);
    }
}
