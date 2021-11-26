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
        public async Task<IActionResult> GetResult()
        {
            try
            {
                List<Building> buildingList = new List<Building>();
                var elevators  = _context.Elevators.ToList();
                

                foreach (var e in elevators)
                {
                    var elevator_status = e.Status;
                    var column = _context.Columns.Where(b => b.Id == e.ColumnId)
                    .FirstOrDefault();
                    var column_status = column.Status;

                    var battery = _context.Batteries.Where(b => b.Id == column.BatteryId)
                    .FirstOrDefault();
                    var batter_status = battery.Status;
                    Console.WriteLine(battery.BuildingId);
                    var building = _context.Buildings.Where(b => b.Id == battery.BuildingId)
                    .FirstOrDefault();
                    buildingList.Add(building);
                    //if(elevator_status == "Intervention")
                    //{
                    //    var building = _context.Buildings.Where(b => b.Id == battery.BuildingId)
                    //.FirstOrDefault();
                    //    buildingList.Add(building);

                    //}else if(column_status == "Intervention")
                    //{
                    //    var building = _context.Buildings.Where(b => b.Id == battery.BuildingId)
                    //.FirstOrDefault();
                    //    buildingList.Add(building);
                    //}else if(batter_status == "Intervention")
                    //{
                    //    var building = _context.Buildings.Where(b => b.Id == battery.BuildingId)
                    //.FirstOrDefault();
                    //    buildingList.Add(building);
                    //}

                    //Console.WriteLine("Building Id : " + building.Id);

                }
                return Ok(buildingList);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
