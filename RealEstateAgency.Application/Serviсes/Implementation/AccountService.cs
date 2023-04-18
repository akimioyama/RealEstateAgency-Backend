using RealEstateAgency.Domain.DTO;
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
using RealEstateAgency.Common;
using Microsoft.IdentityModel.Tokens;

namespace RealEstateAgency.Application.Serviсes.Implementation
{
    public class AccountService : IAccountService
    {
        IArendatelsSelects arendatelsSelects;
        IAdminSelects adminSelects;
        public AccountService()
        {
            arendatelsSelects = new ArendatelsSelects();
            adminSelects = new AdminSelects();
        }
        public AccountDTO GetJWTToken(LoginDTO loginDTO)
        {
            try
            {
                ClaimsIdentity claimsIdentity;
                Arendatels arendatels = arendatelsSelects.GetArendatels(loginDTO.login, loginDTO.password);
                if (arendatels != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, arendatels.id_arendatel.ToString()),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, arendatels.role)
                    };
                    claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                }
                else return null;

                var now = DateTime.UtcNow;

                var jwt = new JwtSecurityToken(
                            issuer: AuthOptions.ISSUER,
                            audience: AuthOptions.AUDIENCE,
                            notBefore: now,
                            claims: claimsIdentity.Claims,
                            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), 
                            SecurityAlgorithms.HmacSha256));
                string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                AccountDTO result = new AccountDTO
                {
                    JWTToken = encodedJwt,
                    Role = arendatels.role,
                    FIO = arendatels.FIO,
                    id = arendatels.id_arendatel
                };
                return result;
            }
            catch
            {
                return null;
            }
        }
        public AccountDTO GetJwtAdmin(LoginDTO loginDTO)
        {
            try
            {
                ClaimsIdentity claimsIdentity;
                Employee employee = adminSelects.GetEmployee(loginDTO.login, loginDTO.password);
                if (employee != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, employee.id.ToString()),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, employee.role)
                    };
                    claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                }
                else return null;

                var now = DateTime.UtcNow;

                var jwt = new JwtSecurityToken(
                            issuer: AuthOptions.ISSUER,
                            audience: AuthOptions.AUDIENCE,
                            notBefore: now,
                            claims: claimsIdentity.Claims,
                            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                            SecurityAlgorithms.HmacSha256));
                string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);


                AccountDTO result = new AccountDTO
                {
                    JWTToken = encodedJwt,
                    Role = employee.role,
                    FIO = employee.FIO,
                    id = employee.id
                };
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
