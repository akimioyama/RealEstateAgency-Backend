using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Domain;
using System.Threading.Tasks;
using RealEstateAgency.Domain.DTO;
using BCrypt.Net;
using System.Collections.Generic;
using System.Security.Claims;
using System;
using RealEstateAgency.Application.Serviсes.Interfaces;

namespace RealEstateAgency.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArendatelsController : ControllerBase
    {
        IArendatelsServices _arendatelsService;
        public ArendatelsController(IArendatelsServices usersService)
        {
            _arendatelsService = usersService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(ArendatelsDTO arendatelsDTO)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(arendatelsDTO.password);
            arendatelsDTO.password = passwordHash;
            string result = _arendatelsService.CreateUserServices(arendatelsDTO);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetInfoById()
        {
            string jwt = (Request.Headers.ContainsKey("authorization") 
                ? Request.Headers["authorization"] 
                : Request.Headers["Authorization"]).ToString().Replace("Bearer ", "");
            var result = _arendatelsService.GetArendatelByJWTServices(jwt);
            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> ChangeUser(ArendatelsDTO arendatelsDTO)
        {
            string jwt = (Request.Headers.ContainsKey("authorization")
                ? Request.Headers["authorization"]
                : Request.Headers["Authorization"]).ToString().Replace("Bearer ", "");

            var result = _arendatelsService.ChangeUserServices(arendatelsDTO, jwt);

            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }
    }
}
