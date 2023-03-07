using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RealEstateAgency.Domain;
using System.Linq;
using RealEstateAgency.Application.Serviсes.Interfaces;
using System.Threading.Tasks;

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
        [HttpPost]
        public async Task<IActionResult> CreateHouse(Aparts newApart)
        {
            return Json(_apartsServices.CreateApartServiсes(newApart));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteHouse(int id)
        {
            return Json(_apartsServices.DeleteApartServiсes(id));
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateHouse(Aparts newApart)
        {
            return Json(_apartsServices.UpdateApartServiсes(newApart));
        }
    }
}
