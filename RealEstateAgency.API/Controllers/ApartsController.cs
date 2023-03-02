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
        [HttpGet("apart/{id}")]
        public async Task<IActionResult> GetApart(int id)
        {
            return Json(_apartsServices.GetApartByIdServices(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAparts(int limit, int page)
        {
            return Json(_apartsServices.GetApartsAllServiсes(limit, page));
        }
    }
}
