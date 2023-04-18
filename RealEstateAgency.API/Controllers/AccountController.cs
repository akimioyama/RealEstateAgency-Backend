using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Domain.DTO;
using RealEstateAgency.Application.Serviсes.Interfaces;
using System.Threading.Tasks;

namespace RealEstateAgency.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IAccountService _accountService;
        public AccountController (IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginDTO loginDTO)
        {
            AccountDTO result = _accountService.GetJWTToken(loginDTO);
            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }
        [HttpPost("loginadmin")]
        public async Task<IActionResult> LoginAdmin(LoginDTO loginDTO)
        {
            AccountDTO result = _accountService.GetJwtAdmin(loginDTO);
            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }
    }
}
