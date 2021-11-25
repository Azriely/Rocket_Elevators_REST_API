using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoApi;

namespace TodoApi.Controllers
{
    public class BatteryController : Controller
    {
        private readonly app_developmentContext _context;

        public BatteryController(app_developmentContext context)
        {
            _context = context;
        }

        // GET: Battery
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lead.ToListAsync());
        }

        // GET: Battery/id
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lead = await _context.Lead
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lead == null)
            {
                return NotFound();
            }

            return View(lead);
        }

        // GET: Battery/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Battery/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BatteryType,Status,DateOfCommissioning,DateOfLastInspection,CertificateOfOperations,Information,Notes,CreatedAt,UpdatedAt,BuildingId,EmployeeId")] Leads lead)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lead);
        }

        // GET: Battery/Edit/
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lead = await _context.Lead.FindAsync(id);
            if (lead == null)
            {
                return NotFound();
            }
            return View(lead);
        }

        // POST: Battery/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,BatteryType,Status,DateOfCommissioning,DateOfLastInspection,CertificateOfOperations,Information,Notes,CreatedAt,UpdatedAt,BuildingId,EmployeeId")] Leads lead)
        {
            if (id != lead.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lead);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeadExists(lead.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(lead);
        }

        // GET: Battery/Delete/
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lead = await _context.Lead
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lead == null)
            {
                return NotFound();
            }

            return View(lead);
        }

        // POST: Battery/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var lead = await _context.Lead.FindAsync(id);
            _context.Lead.Remove(lead);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeadExists(long id)
        {
            return _context.Lead.Any(e => e.Id == id);
        }
    }
}