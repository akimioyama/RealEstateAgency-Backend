using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RealEstateAgency.Application.Serviсes.Interfaces;
using RealEstateAgency.Domain;
using RealEstateAgency.Domain.DTO;
using RealEstateAgency.EntityFramework.Repository.Implementation;
using RealEstateAgency.EntityFramework.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.Application.Serviсes.Implementation
{
    public class ApartsServices : IApartsServices
    {
        IConfiguration _configuration;
        IApartsSelects apartsSelects;
        public ApartsServices(IConfiguration conf)
        {
            _configuration = conf;
            apartsSelects = new ApartsSelects();
        }
        public string CreateApartServiсes(Aparts newApart, string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwt);
            var tokenS = (JwtSecurityToken)jsonToken;

            int userId = Convert.ToInt32(tokenS.Claims.Where(c => c.Type == ClaimsIdentity.DefaultNameClaimType).
                        Select(claim => claim.Value).FirstOrDefault());

            newApart.id_arendatel = userId;
            try
            {   
                var result = apartsSelects.CreateApart(newApart);
                if (result != "-1")
                {
                    return result.ToString();
                }
                else
                    return "-1";
            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
        }
        public bool DeleteApartServiсes(int id, string jwt)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(jwt);
                var tokenS = (JwtSecurityToken)jsonToken;

                int userId = Convert.ToInt32(tokenS.Claims.Where(c => c.Type == ClaimsIdentity.DefaultNameClaimType).
                            Select(claim => claim.Value).FirstOrDefault());

                if (apartsSelects.DeleteApart(id, userId))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public Aparts GetApartByIdServices(int id)
        {
            try
            {
                Aparts aparts = apartsSelects.GetApartById(id);
                if(aparts != null)
                {
                    return aparts;
                };
                return null;
            }
            catch
            {
                return null;
            }
        }
        public List<Aparts> GetApartsAllServiсes(int limit, int page)
        {
            try
            {
                List<Aparts> apartsList = apartsSelects.GetApartsAll(limit, page);
                if( apartsList != null)
                {
                    return apartsList;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public List<Aparts> GetApartsWhisFiltersServices(int limit, int page, FilterDTO filter)
        {
            try
            {
                List<Aparts> apartsList = apartsSelects.GetApartsWthisFilters(limit, page, filter);
                if( apartsList != null)
                {
                    return apartsList;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public string UpdateApartServiсes(ChangeApartDTO changeApartDTO, string jwt)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(jwt);
                var tokenS = (JwtSecurityToken)jsonToken;

                int userId = Convert.ToInt32(tokenS.Claims.Where(c => c.Type == ClaimsIdentity.DefaultNameClaimType).
                            Select(claim => claim.Value).FirstOrDefault());


                var newApart = new Aparts()
                {
                    id = changeApartDTO.id,
                    price = changeApartDTO.price,
                    furniture = changeApartDTO.furniture,
                    technic = changeApartDTO.technic,
                    evro_repair = changeApartDTO.evro_repair,
                    animals = changeApartDTO.animals,
                    elevator = changeApartDTO.elevator,
                    walls = changeApartDTO.walls,
                    text = changeApartDTO.text
                };
                return apartsSelects.UpdateApart(newApart, userId);
            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
        }
        public int TotalPagesServiсes()
        {
            try
            {
                int count = apartsSelects.TotalPages();
                return count;
            }
            catch { return 0; }
        }
        public int TotalPagesWhisFilterServiсes(FilterDTO filter)
        {
            try
            {
                int count = apartsSelects.TotalPagesWhisFilter(filter);
                return count;
            }
            catch
            {
                return 0;
            }
        }
        public List<string> GetStreetAllServices()
        {
            try
            {
                var result = apartsSelects.GetStreetAll();
                return result;
            }
            catch { return null; }
        }
        public List<Aparts> GetAllApartsByUserIdServices(string jwt)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(jwt);
                var tokenS = (JwtSecurityToken)jsonToken;

                int userId = Convert.ToInt32(tokenS.Claims.Where(c => c.Type == ClaimsIdentity.DefaultNameClaimType).
                            Select(claim => claim.Value).FirstOrDefault());

                var result = apartsSelects.GetAparrtsByUserId(userId);
                return result;
            }
            catch
            {
                return null;
            }
        }
        public string ChangeForRentServices(int id, string jwt)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(jwt);
                var tokenS = (JwtSecurityToken)jsonToken;

                int userId = Convert.ToInt32(tokenS.Claims.Where(c => c.Type == ClaimsIdentity.DefaultNameClaimType).
                            Select(claim => claim.Value).FirstOrDefault());

                var result = apartsSelects.ChangeForRent(id, userId);
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public bool DeleteAparAdmintServiсes(int id, string Adminjwt)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(Adminjwt);
                var tokenS = (JwtSecurityToken)jsonToken;

                string userRole = tokenS.Claims.Where(c => c.Type == ClaimsIdentity.DefaultRoleClaimType)
                    .Select(claim => claim.Value).FirstOrDefault();

                if (userRole == "admin")
                    return apartsSelects.DeleteApart(id);
                else return false;
            }
            catch
            {
                return false;
            }
        }
        public string UpdateApartAdminServiсes(ChangeApartDTO changeApartDTO, string Adminjwt)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(Adminjwt);
                var tokenS = (JwtSecurityToken)jsonToken;

                string userRole = tokenS.Claims.Where(c => c.Type == ClaimsIdentity.DefaultRoleClaimType)
                    .Select(claim => claim.Value).FirstOrDefault();

                var newApart = new Aparts()
                {
                    id = changeApartDTO.id,
                    price = changeApartDTO.price,
                    furniture = changeApartDTO.furniture,
                    technic = changeApartDTO.technic,
                    evro_repair = changeApartDTO.evro_repair,
                    animals = changeApartDTO.animals,
                    elevator = changeApartDTO.elevator,
                    walls = changeApartDTO.walls,
                    text = changeApartDTO.text
                };

                if (userRole == "admin")
                    return apartsSelects.UpdateApart(newApart);
                else return "Error";
            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
        }
    }
}
