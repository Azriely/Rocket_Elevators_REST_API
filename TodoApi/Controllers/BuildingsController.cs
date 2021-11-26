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
    public class BuildingsController : Controller
    {
        private readonly app_developmentContext _context;
        public BuildingsController(app_developmentContext context)
        {
            _context = context;
        }

        [Produces("application/json")]
        [HttpGet]
        public List<Building> GetResult()
        {



            var elevator_status = _context.Buildings.Include(blog => blog.Batteries).ToList();
            return elevator_status;
            //try
            //{

            //    var elevator_status = _context.Buildings.Include(blog => blog.Batteries).ToList();
            //    return elevator_status;
            //    //return Ok(elevator_status);
            //}
            //catch
            //{
            //    return BadRequest();
            //}
        }
    }
}
