using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Application.Serviсes.Interfaces;
using RealEstateAgency.Domain;
using System.Threading.Tasks;

namespace RealEstateAgency.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        IRequestServices _requestServices;
        public RequestController(IRequestServices requestServices)
        {
            _requestServices = requestServices;
        }
        [HttpPost]
        public async Task<IActionResult> CreateReq(Request request)
        {
            var result = _requestServices.CreateRequestServices(request);
            if (result == "Added")
                return Ok(result);
            else return BadRequest(result);
        }
        [HttpGet("{status}")]
        public async Task<IActionResult> GetReq(string status)
        {
            string jwt = (Request.Headers.ContainsKey("authorization")
              ? Request.Headers["authorization"]
              : Request.Headers["Authorization"]).ToString().Replace("Bearer ", "");

            var result = _requestServices.GetRequestServices(status, jwt);
            if (result != null)
                return Ok(result);
            else return BadRequest(result);
        }
        [HttpPost("change")]
        public async Task<IActionResult> UpdateReq(Request request)
        {
            var result = _requestServices.UpdateRequestServices(request);
            if (result == "Update")
                return Ok(result);
            else return BadRequest(result);
        }
    }
}
