using RealEstateAgency.Application.Serviсes.Interfaces;
using RealEstateAgency.Domain;
using RealEstateAgency.EntityFramework.Repository.Implementation;
using RealEstateAgency.EntityFramework.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.Application.Serviсes.Implementation
{
    public class AdminServices : IAdminServices
    {
        IAdminSelects adminSelects;
        public AdminServices()
        {
            adminSelects = new AdminSelects();
        }
        public Employee GetEmployeeByLoginAndPassword(string login, string password)
        {
            return adminSelects.GetEmployee(login, password);
        }
        public string CreateEm(Employee employee)
        {
            return adminSelects.CreateEmployee(employee);
        }
        public Employee GetEmployeeById(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwt);
            var tokenS = (JwtSecurityToken)jsonToken;

            int userId = Convert.ToInt32(tokenS.Claims.Where(c => c.Type == ClaimsIdentity.DefaultNameClaimType).
                        Select(claim => claim.Value).FirstOrDefault());

            return adminSelects.GetEmployeeById(userId);
        }
        public List<Employee> GetEmployeeListServuces()
        {
            return adminSelects.GetEmployeeList();
        }
        public string DeleteEmployeeServices(int id)
        {
            return adminSelects.DeleteEmployee(id);
        }
        public string ChangeEmployeeServices(Employee employee)
        {
            return adminSelects.ChangeEmployee(employee);
        }
    }
}
