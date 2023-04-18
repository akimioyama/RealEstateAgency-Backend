using RealEstateAgency.Domain;
using RealEstateAgency.EntityFramework.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.EntityFramework.Repository.Implementation
{
    public class RequestSelects : IRequestSelects
    {
        public string CreateRequest(Request request)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    request.endDate = null;
                    request.id_empl = null;

                    db.Request.Add(request);
                    db.SaveChanges();
                    return "Added";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public List<Request> getAllRequstFinish()
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    var result = db.Request.Where(r => r.status == "finish");
                    return result.ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        public List<Request> getAllRequstProcessing(int id_empl)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    var result = db.Request.Where(r => r.status == "processing" && r.id_empl == id_empl);
                    return result.ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        public List<Request> getAllRequstStart()
        {
            using(RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    var result = db.Request.Where(r => r.status == "start");
                    return result.ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        public string UpdateRequest(Request request)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    var req = db.Request.FirstOrDefault(r => r.id_request == request.id_request);
                    string tempDate = DateTime.Now.ToString("MM.dd.yyyy, HH:mm:ss");

                    if (req != null && request.status == "processing")
                    {
                        req.endDate = tempDate;
                        req.status = "finish";

                        db.SaveChanges();
                        return "Update";
                    }
                    if (req != null && request.status == "start")
                    {
                        req.status = "processing";
                        req.id_empl = request.id_empl;

                        db.SaveChanges();
                        return "Update";
                    }
                    else
                        return "Нету";
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
