using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Application.DTO;
using RealEstateAgency.Application.Serviсes.Interfaces;
using RealEstateAgency.Domain;
using RealEstateAgency.Domain.DTO;
using System.Threading.Tasks;

namespace RealEstateAgency.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _adminServices;
        public AdminController(IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmpl(Employee employee)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(employee.password);
            employee.password = passwordHash;

            string result = _adminServices.CreateEm(employee);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetEmpl()
        {
            string jwt = (Request.Headers.ContainsKey("authorization")
                ? Request.Headers["authorization"]
                : Request.Headers["Authorization"]).ToString().Replace("Bearer ", "");

            var result = _adminServices.GetEmployeeById(jwt);
            if (result != null)
                return Ok(result);
            else return BadRequest(result);
        }
        [Authorize(Roles = "admin")]
        [HttpGet("/all")]
        public async Task<IActionResult> GetEmplList()
        {
            var result = _adminServices.GetEmployeeListServuces();
            if (result != null)
                return Ok(result);
            else
                return BadRequest(result);
        }
        //[Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> ChangeEmp(Employee employee)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(employee.password);
            employee.password = passwordHash;

            var result = _adminServices.ChangeEmployeeServices(employee);
            if (result == "Change")
                return Ok(result);
            else
                return BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DelEmp(int id)
        {
            var result = _adminServices.DeleteEmployeeServices(id);
            
            if (result == "Delete")
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
