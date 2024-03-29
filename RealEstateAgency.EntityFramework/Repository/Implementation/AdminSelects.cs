﻿using RealEstateAgency.Domain;
using RealEstateAgency.EntityFramework.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.EntityFramework.Repository.Implementation
{
    public class AdminSelects : IAdminSelects
    {
        public Employee GetEmployee(string login, string password)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    var employee = db.Employee.FirstOrDefault(u => u.login == login && u.dele == false);
                    if (employee != null)
                    {
                        if (BCrypt.Net.BCrypt.Verify(password, employee.password))
                        {
                            return employee;
                        }
                        else
                            return null;
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            }
        }
        public string CreateEmployee(Employee employee)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    db.Employee.Add(employee);
                    db.SaveChanges();
                    return "Добавили";
                }
                catch (Exception ex)
                {
                    return ex.InnerException.ToString();
                }
            }
        }
        public Employee GetEmployeeById(int id)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    var result = db.Employee.FirstOrDefault(e => e.id == id && e.dele == false);
                    if (result != null)
                        return result;
                    else return null;
                }
                catch 
                {
                    return null;
                }
            }
        }
        public List<Employee> GetEmployeeList()
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    var result = db.Employee.Where(e => e.dele == false).Distinct().ToList();
                    if (result != null)
                        return result;
                    else return null;
                }
                catch
                {
                    return null;
                }
            }
        }
        public string DeleteEmployee(int id)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    var emloyee = db.Employee.FirstOrDefault(e => e.id == id);
                    if (emloyee != null)
                    {
                        emloyee.dele = true;

                        db.SaveChanges();
                        return "Delete";
                    }
                    else
                        return "Nan";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
        public string ChangeEmployee(Employee employee)
        {
            using (RealEstateAgencyContext db = new RealEstateAgencyContext())
            {
                try
                {
                    var result = db.Employee.FirstOrDefault(e => e.id == employee.id);
                    if (result != null)
                    {
                        result.FIO = employee.FIO;
                        result.role = employee.role;
                        result.password = employee.password;

                        db.SaveChanges();
                        return "Change";
                    }
                    else return "Nan";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}
