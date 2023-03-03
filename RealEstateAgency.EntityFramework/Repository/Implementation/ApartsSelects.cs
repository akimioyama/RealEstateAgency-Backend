using Microsoft.EntityFrameworkCore.Query;
using RealEstateAgency.Domain;
using RealEstateAgency.EntityFramework.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.EntityFramework.Repository.Implementation
{
    public class ApartsSelects : IApartsSelects
    {
        //private RealEstateAgencyContext db;
        //public ApartsSelects()
        //{
        //    db = new RealEstateAgencyContext();
        //}

        public bool CreateApart(Aparts newApart)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {   
                try
                {
                    db.Aparts.Add(newApart);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool DeleteApart(int id)
        {
            using(RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    Aparts apart = db.Aparts.FirstOrDefault(p => p.Id == id);
                    if (apart != null)
                    {
                        db.Aparts.Remove(apart);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        public Aparts GetApartById(int id)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                var apart = db.Aparts.Where(p => p.Id == id).FirstOrDefault();
                return apart;
            }
        }

        public List<Aparts> GetApartsAll(int limit, int page)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                int start = limit * (page - 1);

                var aparts = db.Aparts.Skip(start).Take(limit).ToList();
                return aparts;
            }
        }

        public bool UpdateApart(Aparts newApart)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    Aparts aparts = db.Aparts.FirstOrDefault(p => p.Id == newApart.Id);
                    if (aparts != null)
                    {
                        aparts.city = newApart.city;
                        aparts.street = newApart.street;
                        aparts.house = newApart.house;
                        aparts.apart = newApart.apart;
                        aparts.price = newApart.price;
                        aparts.furniture = newApart.furniture;
                        aparts.technic = newApart.technic;
                        aparts.evro_repair = newApart.evro_repair;
                        aparts.animals = newApart.animals;
                        aparts.elevator = newApart.elevator;
                        aparts.loggia = newApart.loggia;
                        aparts.balcony = newApart.balcony;
                        aparts.walls = newApart.walls;
                        aparts.floor = newApart.floor;
                        aparts.floors = newApart.floors;
                        aparts.new_building = newApart.new_building;
                        aparts.type_of_house = newApart.type_of_house;
                        aparts.bathroom_shower = newApart.bathroom_shower;
                        aparts.kitchen_stove = newApart.kitchen_stove;
                        aparts.ceiling_height = newApart.ceiling_height;
                        aparts.lavatory = newApart.lavatory;
                        //aparts.id_arendatel = newApart.id_arendatel;
                        aparts.district = newApart.district;
                        aparts.for_rent = newApart.for_rent;
                        aparts.count_pic = newApart.count_pic;
                        aparts.text = newApart.text;

                        db.SaveChanges();
                        return true;
                    }
                    else { return false; } 
                }
                catch { return false; }
            }
        }
        public int TotalPages()
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                var count = db.Aparts.Count();
                return count;
            }
        }
    }
}
