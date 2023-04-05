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
        
        //[HttpPost("login")]
        //public async Task<IActionResult> LoginUser(ArendatelsDTO arendatelsDTO)
        //{
        //    //if (arendatels.login != arendatelsDTO.login)
        //    //{
        //    //    return BadRequest("User not found");
        //    //}
        //    //if (!BCrypt.Net.BCrypt.Verify(arendatelsDTO.password, arendatels.password))
        //    //{
        //    //    return BadRequest("Wrong password");
        //    //}
        //    //return Ok(arendatels);
        //}
    }
}
