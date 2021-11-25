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
    public class ElevatorController : Controller
    {
        private readonly app_developmentContext _context;

        public ElevatorController(app_developmentContext context)
        {
            _context = context;
        }

        // GET: Elevator 
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lead.ToListAsync());
        }

        // GET: Elevator/id
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

        // GET: Elevator/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Elevator/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SerialNumber,Model,ElevatorType,Status,DateOfCommissioning,DateOfLastInspection,CertificateOfInspection,Notes,CreatedAt,UpdatedAt,ColumnId")] Leads lead)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lead);
        }

        // GET: Elevator/Edit/
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

        // POST: Elevator/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,SerialNumber,Model,ElevatorType,Status,DateOfCommissioning,DateOfLastInspection,CertificateOfInspection,Notes,CreatedAt,UpdatedAt,ColumnId")] Leads lead)
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

        // GET: Elevator/Delete/
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

        // POST: Elevator/Delete/
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