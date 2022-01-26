using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Sibly.Models;
using Sibly.ViewModels;

namespace Sibly.Controllers
{
    public class CustomersController : Controller
    {

        public ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }




        //         //GET: /Customers/
        //public ActionResult New()
        //{
        //    var customer = new Customers
        //    {
        //        Id = 0
        //    };
        //    var viewModel = new CustomerFormViewModel
        //    {
        //        MembershipType = _context.MembershipType.ToList()

        //    };
        //    Console.WriteLine(viewModel);

        //    return View("CustomerForm",viewModel);
        //}



               //GET: /Customers/
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }



         //GET: /Customers/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer Customers)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customers = Customers,
                    MembershipTypes = _context.MembershipTypes.ToList()

                };
                return View("CustomerForm", viewModel);
            }

 
            if (Customers.CustomerId == 0)
                {
                    _context.Customers.Add(Customers);
                }
                else
                {
                    var curcustomer = _context.Customers.Single(c => c.CustomerId == Customers.CustomerId);
                    curcustomer.Birthdate = Customers.Birthdate;
                    curcustomer.Name = Customers.Name;
                    curcustomer.MembershipTypeId = Customers.MembershipTypeId;
                    curcustomer.isSubscribedToNewsletter = Customers.isSubscribedToNewsletter;
                };
                _context.SaveChanges();
                return RedirectToAction("Index", "Customers");
            }
        
       







        public ActionResult Edit(int id)
        {
            Customer customer = null;
            if (id == 0)
            {
                customer = new Customer
                {
                    CustomerId = 0
                };
            }
            else
            {
                customer = _context.Customers.Single(c => c.CustomerId == id);
            }
            



            var viewModel = new CustomerFormViewModel
            {
                Customers = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };
            return View("CustomerForm", viewModel);
        }



        //
         //GET: /Customers/
        public ActionResult Index()
        {
            var customer = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customer);
        }
	}
}