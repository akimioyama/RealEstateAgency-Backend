using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Domain;
using System.Threading.Tasks;
using RealEstateAgency.Domain.DTO;
using BCrypt.Net;
using System.Collections.Generic;
using System.Security.Claims;
using System;

namespace RealEstateAgency.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static Arendatels arendatels = new Arendatels();

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(ArendatelsDTO arendatelsDTO)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(arendatelsDTO.password);

            arendatels.login = arendatelsDTO.login;
            arendatels.FIO = arendatelsDTO.FIO;
            arendatels.password = passwordHash;
            arendatels.telefon = arendatelsDTO.telepon;

            return Ok(arendatels);
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(ArendatelsDTO arendatelsDTO)
        {
            if (arendatels.login != arendatelsDTO.login)
            {
                return BadRequest("User not found");
            }
            if (!BCrypt.Net.BCrypt.Verify(arendatelsDTO.password, arendatels.password))
            {
                return BadRequest("Wrong password");
            }
            return Ok(arendatels);
        }
    }
}
