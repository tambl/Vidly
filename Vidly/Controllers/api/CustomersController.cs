using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //GET/api/customers
        [Authorize(Roles = "CanManageMovies")]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            if (User.IsInRole("CanManageMovies"))
            {
                return _context.Customers.Include(i => i.MembershipType).ToList().Select(Mapper.Map<Customer, CustomerDto>);
            }
            else return null;
        }
        //GET/api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {

            var customer = _context.Customers.Include(i => i.MembershipType).FirstOrDefault(f => f.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            else return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST/api/customers/
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);

        }


        //PUT/api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerDB = _context.Customers.FirstOrDefault(f => f.Id == id);

            if (customerDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map<CustomerDto, Customer>(customerDto, customerDB);

            //customerDB.Name = customerDto.Name;
            //customerDB.MembershipTypeId = customerDto.MembershipTypeId;
            //customerDB.IsSubscribedToCustomer = customerDto.IsSubscribedToCustomer;

            _context.SaveChanges();

        }

        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerDB = _context.Customers.FirstOrDefault(f => f.Id == id);

            if (customerDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerDB);

            _context.SaveChanges();

        }
    }
}
