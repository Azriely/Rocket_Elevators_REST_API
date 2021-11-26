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
    public class ElevatorController : Controller
    {
        private readonly app_developmentContext _context;
        public ElevatorController(app_developmentContext context)
        {
            _context = context;
        }

        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var products = _context.Elevators.ToList();
                return Ok(products);
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpect(int id)
        {
            try
            {
                var products = _context.Elevators.Where(b => b.Id == id)
                    .FirstOrDefault();
                    var current_status = products.Status;
                return Ok(current_status);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}