using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeadsController : Controller
    {
        private readonly app_developmentContext _context;
        public LeadsController(app_developmentContext context)
        {
            _context = context;
        }

        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var products = _context.Leads.ToList();
                return Ok(products);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            var list = _context.Leads.Include(b => b.Customers);
            if (list == null) {
                return NotFound();
            }

            List<Leads> recent_leads = new List<Leads>();
            DateTime currentDate = DateTime.Now.AddDays(-30);
            foreach (var i in list) {
                if (i.CreatedAt >= currentDate) {
                    if (i.Customers.ToList().Count == 0) {
                        recent_leads.Add(i);
                    }
                }
            }
            return Ok(recent_leads);
        }
    }
}