using NETCoreCRUDOperations.EF;
using NETCoreCRUDOperations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NETCoreCRUDOperations.DataAccessLayer
{
    public class CustomerDataAccessLayer : Controller
    {
        public IEnumerable<Customer> GetAllCustomers()
        {
            IEnumerable<Customer> rtnValue;

            using (var _context = new DataContext())
            {
                try
                {
                    var customers = _context.tblCustomer;

                    var objects =
                        (from customer in customers
                         select new Customer
                         {
                             ID = customer.ID,
                             Name = customer.Name,
                             Country = customer.Country,
                             Email = customer.Email,
                             Gender = customer.Gender
                         });

                    objects = objects.OrderBy(x => x.ID);

                    rtnValue = objects.ToArray();
                }
                catch (Exception ex)
                {
                    rtnValue = null; // error
                }
            }

            return rtnValue;
        }

        //To add new customer record 
        public int AddCustomer(Customer customer)
        {
            var rtnValue = 0;

            using (var _context = new DataContext())
            {
                try
                {
                    _context.tblCustomer.Add(customer);
                    rtnValue = _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    rtnValue = -1; // error
                }
            }

            return rtnValue;
        }

        //To update a customer
        public int UpdateCustomer(Customer customer)
        {
            var rtnValue = 0;

            using (var _context = new DataContext())
            {
                try
                {
                    _context.Entry(customer).State = EntityState.Modified;
                    rtnValue = _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    rtnValue = -1; // error
                }
            }

            return rtnValue;
        }

        //Get the details of a particular customer
        public Customer GetCustomerData(int id)
        {
            Customer rtnValue;

            using (var _context = new DataContext())
            {
                try
                {
                    var customers = _context.tblCustomer;

                    var objects =
                        (from customer in customers
                         where customer.ID == id
                         select new Customer
                         {
                             ID = customer.ID,
                             Name = customer.Name,
                             Country = customer.Country,
                             Email = customer.Email,
                             Gender = customer.Gender
                         }).FirstOrDefault();

                    rtnValue = objects;

                }
                catch (Exception ex)
                {
                    rtnValue = null; // error
                }
            }

            return rtnValue;
        }

        //To delete a particular customer
        public int DeleteCustomer(int id)
        {
            var rtnValue = 0;

            using (var _context = new DataContext())
            {
                try
                {
                    Customer customer = _context.tblCustomer.Find(id);
                    _context.tblCustomer.Remove(customer);
                    rtnValue = _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    rtnValue = -1; // error
                }
            }

            return rtnValue;
        }
    }
}

