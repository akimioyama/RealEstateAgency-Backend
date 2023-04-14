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
                    if (user == null)
                    {
                        var user1 = db.Arendatels.FirstOrDefault(u => u.email == arendatels.email);
                        if (user1 == null)
                        {
                            var user2 = db.Arendatels.FirstOrDefault(u => u.telefon == arendatels.telefon);
                            if (user2 == null)
                            {
                                arendatels.id_arendatel = 0;
                                arendatels.status = true;
                                arendatels.role = "user";

                                db.Arendatels.Add(arendatels);
                                db.SaveChanges();
                                return "Добавили";
                            }
                            else
                                return "Телефон занят";
                        }
                        else
                            return "Почта занята";
                    }
                    else
                        return "Логин занят";
                }
                catch (Exception ex)
                {
                    return ex.InnerException.Message;
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
                        arendatels.status = false;
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

        public List<Arendatels> GetAllArendatels()
        {
            throw new NotImplementedException();
        }

        public Arendatels GetArendatels(string login, string password)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    var user = db.Arendatels.FirstOrDefault(u => u.login == login);
                    if (user != null)
                    {
                        if (BCrypt.Net.BCrypt.Verify(password, user.password))
                            return user;
                        else
                            return null;
                            
                    }
                    else
                        return null;

                }
                catch
                {
                    return null;
                }
            }
        }

        public string UpdateArendatels(Arendatels arendatels)
        {
            using(RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    var user = db.Arendatels.FirstOrDefault(u => u.email == arendatels.email 
                    && u.id_arendatel != arendatels.id_arendatel);
                    if (user == null)
                    {
                        var user1 = db.Arendatels.FirstOrDefault(u => u.telefon == arendatels.telefon
                        && u.id_arendatel != arendatels.id_arendatel);
                        if (user1 == null)
                        {
                            Arendatels arendatelsMain = db.Arendatels.FirstOrDefault(u =>
                            u.id_arendatel == arendatels.id_arendatel);
                            arendatelsMain.FIO = arendatels.FIO;
                            arendatelsMain.telefon = arendatels.telefon;
                            arendatelsMain.email = arendatels.email;

                            db.SaveChanges();

                            return "Изменили";
                        }
                        else
                            return "Телефон занят";
                    }
                    else
                        return "Почта занята";
                }
                catch (Exception ex)
                {
                    return ex.InnerException.ToString();
                }
            }

        }
        public Arendatels GetArendatelsById(int id)
        {
            using(RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    var user = db.Arendatels.FirstOrDefault(u => u.id_arendatel == id);
                    if (user != null)
                        return user;
                    else
                        return null;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
