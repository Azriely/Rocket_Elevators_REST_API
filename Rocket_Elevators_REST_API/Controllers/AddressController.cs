using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_REST_API.Models;

namespace Rocket_Elevators_REST_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : Controller
    {
        private readonly matthewdandurandContext _context;
        public AddressController(matthewdandurandContext context)
        {
            _context = context;
        }

        

        [Produces("application/json")]
        [HttpGet("{email}")]
        public async Task<IActionResult> GetSpect(string email)
        {
            try
            {
                var products = _context.Customers.Where(b => b.ContactEmail == email)
                    .FirstOrDefault();

                var address = _context.Addresses.Where(b => b.Id == products.AddressId).FirstOrDefault();

                Address selectedInfo = new Address();
                selectedInfo.NumberAndStreet = address.NumberAndStreet;
                selectedInfo.City = address.City;
                selectedInfo.Country = address.Country;
                selectedInfo.PostalCode = address.PostalCode;
                
                return Ok(selectedInfo);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost("{email}")]
        public async Task<IActionResult> Process(string  email, Address input)
        {
            try
            {
                var products = _context.Customers.Where(b => b.ContactEmail == email)
                    .FirstOrDefault();

                var address = _context.Addresses.Where(b => b.Id == products.AddressId).FirstOrDefault();
                
                address.NumberAndStreet = input.NumberAndStreet;
                address.City = input.City;
                address.Country = input.Country;
                address.SuiteAndApartment = input.SuiteAndApartment;
                address.PostalCode = input.PostalCode;
                _context.SaveChanges();
                return Ok("Address has been successfully updated");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{email}/phone")]
        public async Task<IActionResult> GetPhone(string email)
        {
            try
            {
                var products = _context.Customers.Where(b => b.ContactEmail == email)
                    .FirstOrDefault();
                
                return Ok(products.ContactPhone);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{email}/{phone}")]
        public async Task<IActionResult> UpdatePhone(string email,string phone)
        {
            try
            {
                var products = _context.Customers.Where(b => b.ContactEmail == email)
                    .FirstOrDefault();
                products.ContactPhone = phone;
                _context.SaveChanges();
                return Ok("Phone has been successfully updated");
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}