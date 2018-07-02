using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
using System.Runtime.Caching;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {

        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Customer

        public ActionResult Index()
        {
            // var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //Data cacheing. დარეფერენსება სჭირდება  System.Runtime.Caching-ის
            if (MemoryCache.Default["MembershipTypes"] == null)
            {
                MemoryCache.Default["MembershipTypes"] = _context.MembershipTypes.ToList();
            }
            else
            {
                var membershipTypes = MemoryCache.Default["MembershipTypes"] as IEnumerable<MembershipType>;
            }

            return View();
        }
        [Authorize(Roles = UserRolesName.CanManageMovies)]
        public ActionResult Create()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var customer = new CustomerViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View(customer);
        }
        [HttpPost]
        public ActionResult Create(CustomerViewModel model)
        {
            var cutomer = new Customer()
            {
                Name = model.Name,
                MembershipTypeId = model.MembershipTypeId,
                IsSubscribedToCustomer = model.IsSubscribedToCustomer,
                BirthDate = DateTime.Now
            };
            _context.Customers.Add(cutomer);
            _context.SaveChanges();

            return Redirect("Index");
        }
        public ActionResult Edit(int id)
        {
            return View();
        }

    }
}