﻿using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using RealEstateAgency.Domain;
using RealEstateAgency.Domain.DTO;
using RealEstateAgency.EntityFramework.Repository.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.EntityFramework.Repository.Implementation
{
    public class ApartsSelects : IApartsSelects
    {
        public string CreateApart(Aparts apartsRecord)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {   
                try
                {
                    apartsRecord.dele = false;
                    apartsRecord.id = 0;
                    db.Aparts.Add(apartsRecord);
                    db.SaveChanges();

                    return apartsRecord.id.ToString();
                }
                catch (Exception ex)
                {
                    return "-1";
                }
            }
        }
        public bool DeleteApart(int id, int id_arend)
        {
            using(RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    Aparts apart = db.Aparts.FirstOrDefault(p => p.id == id && p.dele == false && p.id_arendatel == id_arend);
                    if (apart != null)
                    {
                        apart.dele = true;
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
                var apart = db.Aparts.Where(p => p.id == id && p.dele == false).FirstOrDefault();
                return apart;
            }
        }
        public List<Aparts> GetApartsAll(int limit, int page)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                int start = limit * (page - 1);

                var aparts = db.Aparts.Where(a => a.for_rent == true && a.dele == false).Skip(start).Take(limit).ToList();
                return aparts;
            }
        }
        public string UpdateApart(Aparts newApart, int id_arendatel)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    var aparts = db.Aparts.FirstOrDefault(p => p.id == newApart.id && p.id_arendatel == id_arendatel);
                    if (aparts != null)
                    {
                        aparts.price = newApart.price;
                        aparts.furniture = newApart.furniture;
                        aparts.technic = newApart.technic;
                        aparts.evro_repair = newApart.evro_repair;
                        aparts.animals = newApart.animals;
                        aparts.elevator = newApart.elevator;
                        aparts.walls = newApart.walls;
                        aparts.text = newApart.text;
                        

                        db.SaveChanges();
                        return "Изменили";
                    }
                    else { return "Нет такой квартиры/не верный id_arendatel"; } 
                }
                catch (Exception ex) 
                {
                    return ex.InnerException.ToString();
                }
            }
        }
        public int TotalPages()
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                var count = db.Aparts.Where(c => c.for_rent == true && c.dele == false).Count();
                return count;
            }
        }
        public List<string> GetStreetAll()
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                var result = db.Aparts.Select(a => a.street).Distinct().ToList();
                return result;
            }
        }
        public List<Aparts> GetApartsWthisFilters(int limit, int page, FilterDTO filter)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                int start = limit * (page - 1);


                var filteredList = db.Aparts
                    .Where(a => (filter.city == null || a.city == filter.city)
                    && (filter.district == null || a.district == filter.district)
                    && (filter.street == null || a.street == filter.street)
                    && (filter.apart == null || filter.apart.Contains(a.apart))
                    && (filter.price == null || a.price <= filter.price)
                    && (filter.furniture == null || a.furniture == filter.furniture)
                    && (filter.technic == null || a.technic == filter.technic)
                    && (filter.evro_repair == null || a.evro_repair == filter.evro_repair)
                    && (filter.animals == null || a.animals == filter.animals)
                    && (filter.elevator == null || a.elevator == filter.elevator)
                    && (filter.balcony == null || a.balcony == filter.balcony)
                    && (filter.loggia == null || a.loggia == filter.loggia)
                    && (filter.walls == null || a.walls == filter.walls)
                    && (filter.floor == null || a.floor == filter.floor)
                    && (filter.floors == null || a.floors == filter.floors)
                    && (filter.new_building == null || a.new_building == filter.new_building)
                    && (filter.type_of_house == null || filter.type_of_house.Contains(a.type_of_house))
                    && (filter.bathroom_shower == null || a.bathroom_shower == filter.bathroom_shower)
                    && (filter.kitchen_stove == null || a.kitchen_stove == filter.kitchen_stove)
                    && (filter.ceiling_height == null || a.ceiling_height == filter.ceiling_height)
                    && (filter.lavatory == null || a.lavatory == filter.lavatory)
                    && (filter.metrov == null || a.metrov >= filter.metrov)
                    && a.for_rent == true && a.dele == false)
                    .ToList().Skip(start).Take(limit).ToList();
                return filteredList;
            }
        }
        public int TotalPagesWhisFilter(FilterDTO filter)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                var filteredList = db.Aparts
                   .Where(a => (filter.city == null || a.city == filter.city)
                   && (filter.district == null || a.district == filter.district)
                   && (filter.street == null || a.street == filter.street)
                   && (filter.apart == null || filter.apart.Contains(a.apart))
                   && (filter.price == null || a.price <= filter.price)
                   && (filter.furniture == null || a.furniture == filter.furniture)
                   && (filter.technic == null || a.technic == filter.technic)
                   && (filter.evro_repair == null || a.evro_repair == filter.evro_repair)
                   && (filter.animals == null || a.animals == filter.animals)
                   && (filter.elevator == null || a.elevator == filter.elevator)
                   && (filter.balcony == null || a.balcony == filter.balcony)
                   && (filter.loggia == null || a.loggia == filter.loggia)
                   && (filter.walls == null || a.walls == filter.walls)
                   && (filter.floor == null || a.floor == filter.floor)
                   && (filter.floors == null || a.floors == filter.floors)
                   && (filter.new_building == null || a.new_building == filter.new_building)
                   && (filter.type_of_house == null || filter.type_of_house.Contains(a.type_of_house))
                   && (filter.bathroom_shower == null || a.bathroom_shower == filter.bathroom_shower)
                   && (filter.kitchen_stove == null || a.kitchen_stove == filter.kitchen_stove)
                   && (filter.ceiling_height == null || a.ceiling_height == filter.ceiling_height)
                   && (filter.lavatory == null || a.lavatory == filter.lavatory)
                   && (filter.metrov == null || a.metrov >= filter.metrov)
                   && a.for_rent == true && a.dele == false).Count();
                return filteredList;
            }
        }
        public List<Aparts> GetAparrtsByUserId(int id)
        {
            using(RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                var aparts = db.Aparts.Where(a => a.id_arendatel == id && a.dele == false);
                return aparts.ToList();
            }
        }
        public string ChangeForRent(int id, int id_arend)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    var apart = db.Aparts.FirstOrDefault(a => a.id == id && a.dele == false);
                    if (apart != null)
                    {
                        if (apart.id_arendatel == id_arend)
                        {
                            if (apart.for_rent == true)
                                apart.for_rent = false;
                            else
                                apart.for_rent = true;

                            db.SaveChanges();
                            return "Изменили";
                        }
                        else
                            return "Разные id_arendatels";
                    }
                    else
                        return "Нет такой квартиры";
                }
                catch (Exception ex)
                {
                    return ex.InnerException.ToString();
                }
            }
        }
        public string UpdateApart(Aparts newApart)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    var aparts = db.Aparts.FirstOrDefault(a => a.id == newApart.id);
                    if (aparts != null)
                    {
                        aparts.price = newApart.price;
                        aparts.furniture = newApart.furniture;
                        aparts.technic = newApart.technic;
                        aparts.evro_repair = newApart.evro_repair;
                        aparts.animals = newApart.animals;
                        aparts.elevator = newApart.elevator;
                        aparts.walls = newApart.walls;
                        aparts.text = newApart.text;


                        db.SaveChanges();
                        return "Изменили";
                    }
                    else { return "Нет такой квартиры"; }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
        public bool DeleteApart(int id)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    var apart = db.Aparts.FirstOrDefault(a => a.id == id);
                    if (apart != null)
                    {
                        apart.dele = true;
                        db.SaveChanges();
                        return true;
                    }
                    else
                        return false;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
