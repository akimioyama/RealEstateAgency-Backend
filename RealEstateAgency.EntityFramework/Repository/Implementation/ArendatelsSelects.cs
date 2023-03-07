using RealEstateAgency.Domain;
using RealEstateAgency.EntityFramework.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.EntityFramework.Repository.Implementation
{
    public class ArendatelsSelects : IArendatelsSelects
    {
        public string CreateArendatels(Arendatels arendatels)
        {
            using(RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    var user = db.Arendatels.FirstOrDefault(u => u.login == arendatels.login);
                    if (user != null)
                    {
                        user = db.Arendatels.FirstOrDefault(u => u.email == arendatels.email);
                        if (user != null)
                        {
                            db.Arendatels.Add(arendatels);
                            db.SaveChanges();
                            return "Добавили";
                        }
                        return "Почта занята";
                    }
                    return "Логин занят";
                }
                catch
                {
                    return null;
                }
            }
        }

        public bool DeleteArendatels(int id)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    var arendatels = db.Arendatels.FirstOrDefault(u => u.id_arendatel == id);
                    if(arendatels != null)
                    {
                        db.Arendatels.Remove(arendatels);
                        db.SaveChanges(); 
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        public Arendatels GetArendatels(string login, string password)
        {
            throw new NotImplementedException();
        }

        public bool UpdateArendatels(Arendatels arendatels)
        {
            throw new NotImplementedException();

        }
    }
}
