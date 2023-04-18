using RealEstateAgency.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.EntityFramework.Repository.Interfaces
{
    public interface IAdminSelects
    {
        public Employee GetEmployee(string login, string password);
        public Employee GetEmployeeById(int id);
        public string CreateEmployee(Employee employee);
    }
}
