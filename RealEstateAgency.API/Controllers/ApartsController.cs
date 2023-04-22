using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RealEstateAgency.Domain;
using System.Linq;
using RealEstateAgency.Application.Serviсes.Interfaces;
using System.Threading.Tasks;
using RealEstateAgency.Domain.DTO;

namespace RealEstateAgency.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartsController : Controller
    {
        private readonly IApartsServices _apartsServices;
        public ApartsController(IApartsServices apartsServices)
        {
            _apartsServices = apartsServices;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApart(int id)
        {
            return Json(_apartsServices.GetApartByIdServices(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAparts(int limit, int page)
        {
            int count = _apartsServices.TotalPagesServiсes();
            Response.Headers.Add("x-total-count", count.ToString());
            return Json(_apartsServices.GetApartsAllServiсes(limit, page));
        }
        [HttpPost("filter")]
        public async Task<IActionResult> GetAllAparts(int limit, int page, FilterDTO filter)
        {
            int count = _apartsServices.TotalPagesWhisFilterServiсes(filter);
            Response.Headers.Add("x-total-count", count.ToString());
            return Json(_apartsServices.GetApartsWhisFiltersServices(limit, page, filter));
        }
        [HttpPost]
        public async Task<IActionResult> CreateHouse(Aparts newApart)
        {
            string jwt = (Request.Headers.ContainsKey("authorization")
               ? Request.Headers["authorization"]
               : Request.Headers["Authorization"]).ToString().Replace("Bearer ", "");

            return Json(_apartsServices.CreateApartServiсes(newApart, jwt));
        }
        [HttpGet("byid")]
        public async Task<IActionResult> GetAllApartsByUserId()
        {
            string jwt = (Request.Headers.ContainsKey("authorization")
               ? Request.Headers["authorization"]
               : Request.Headers["Authorization"]).ToString().Replace("Bearer ", "");

            return Json(_apartsServices.GetAllApartsByUserIdServices(jwt));
        }
        [HttpGet("q/{id_apart}")]
        public async Task<IActionResult> ChangeForRent(int id_apart)
        {
            string jwt = (Request.Headers.ContainsKey("authorization")
               ? Request.Headers["authorization"]
               : Request.Headers["Authorization"]).ToString().Replace("Bearer ", "");

            return Json(_apartsServices.ChangeForRentServices(id_apart, jwt));
        }
        [HttpDelete("del/{id}")]
        public async Task<IActionResult> DeleteHouse(int id)
        {
            string jwt = (Request.Headers.ContainsKey("authorization")
               ? Request.Headers["authorization"]
               : Request.Headers["Authorization"]).ToString().Replace("Bearer ", "");

            return Json(_apartsServices.DeleteApartServiсes(id, jwt));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateHouse(ChangeApartDTO changeApartDTO)
        {
            string jwt = (Request.Headers.ContainsKey("authorization")
               ? Request.Headers["authorization"]
               : Request.Headers["Authorization"]).ToString().Replace("Bearer ", "");

            var result = _apartsServices.UpdateApartServiсes(changeApartDTO, jwt);
            return Ok(result);
        }
        [HttpGet("allStreet")]
        public async Task<IActionResult> GetAllStreet()
        {
            return Json(_apartsServices.GetStreetAllServices());
        }
        [HttpDelete("admin/del/{id}")]
        public async Task<IActionResult> DeleteHouseAdmin(int id)
        {
            string jwt = (Request.Headers.ContainsKey("authorization")
               ? Request.Headers["authorization"]
               : Request.Headers["Authorization"]).ToString().Replace("Bearer ", "");

            return Json(_apartsServices.DeleteAparAdmintServiсes(id, jwt));
        }
        [HttpPut("admin/put")]
        public async Task<IActionResult> UpdateHouseAdmin(ChangeApartDTO changeApartDTO)
        {
            string jwt = (Request.Headers.ContainsKey("authorization")
               ? Request.Headers["authorization"]
               : Request.Headers["Authorization"]).ToString().Replace("Bearer ", "");

            var result = _apartsServices.UpdateApartAdminServiсes(changeApartDTO, jwt);
            return Ok(result);
        }
    }
}
