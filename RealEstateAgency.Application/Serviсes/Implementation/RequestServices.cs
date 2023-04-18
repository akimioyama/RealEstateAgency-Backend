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

namespace RealEstateAgency.Application.Serviсes.Implementation
{
    public class RequestServices : IRequestServices
    {
        IRequestSelects requestSelects;
        public RequestServices()
        {
            requestSelects = new RequestSelects();
        }
        public string CreateRequestServices(Request request)
        {
            return requestSelects.CreateRequest(request);
        }

        public List<Request> GetRequestServices(string status, string jwt)
        {
            if (status == "start")
            {
                return requestSelects.getAllRequstStart();
            }
            else if (status == "processing")
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(jwt);
                var tokenS = (JwtSecurityToken)jsonToken;

                int userId = Convert.ToInt32(tokenS.Claims.Where(c => c.Type == ClaimsIdentity.DefaultNameClaimType).
                            Select(claim => claim.Value).FirstOrDefault());

                return requestSelects.getAllRequstProcessing(userId);
            }
            else if (status == "finish")
            {
                return requestSelects.getAllRequstFinish();
            }
            return null;
        }

        public string UpdateRequestServices(Request request)
        {
            return requestSelects.UpdateRequest(request);
        }
    }
}
