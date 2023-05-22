using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlightBooking1.Data;
using FlightBooking1.Models;

namespace FlightBooking1.Controllers
{
    public class FlightSchedulesController : Controller
    {
        private readonly FlightBooking1Context _context;

        public FlightSchedulesController(FlightBooking1Context context)
        {
            _context = context;
        }

        // GET: FlightSchedules
        public async Task<IActionResult> Index()
        {
              return _context.FlightSchedules != null ? 
                          View(await _context.FlightSchedules.ToListAsync()) :
                          Problem("Entity set 'FlightBooking1Context.FlightSchedules'  is null.");
        }

        // GET: FlightSchedules/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.FlightSchedules == null)
            {
                return NotFound();
            }

            var flightSchedules = await _context.FlightSchedules
                .FirstOrDefaultAsync(m => m.FlightID == id);
            if (flightSchedules == null)
            {
                return NotFound();
            }

            return View(flightSchedules);
        }

        // GET: FlightSchedules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FlightSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StartDay,FlightID,PlaneID,TypeOfPlane")] FlightSchedules flightSchedules)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flightSchedules);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flightSchedules);
        }

        // GET: FlightSchedules/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.FlightSchedules == null)
            {
                return NotFound();
            }

            var flightSchedules = await _context.FlightSchedules.FindAsync(id);
            if (flightSchedules == null)
            {
                return NotFound();
            }
            return View(flightSchedules);
        }

        // POST: FlightSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StartDay,FlightID,PlaneID,TypeOfPlane")] FlightSchedules flightSchedules)
        {
            if (id != flightSchedules.FlightID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flightSchedules);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightSchedulesExists(flightSchedules.FlightID))
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
            return View(flightSchedules);
        }

        // GET: FlightSchedules/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.FlightSchedules == null)
            {
                return NotFound();
            }

            var flightSchedules = await _context.FlightSchedules
                .FirstOrDefaultAsync(m => m.FlightID == id);
            if (flightSchedules == null)
            {
                return NotFound();
            }

            return View(flightSchedules);
        }

        // POST: FlightSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.FlightSchedules == null)
            {
                return Problem("Entity set 'FlightBooking1Context.FlightSchedules'  is null.");
            }
            var flightSchedules = await _context.FlightSchedules.FindAsync(id);
            if (flightSchedules != null)
            {
                _context.FlightSchedules.Remove(flightSchedules);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightSchedulesExists(string id)
        {
          return (_context.FlightSchedules?.Any(e => e.FlightID == id)).GetValueOrDefault();
        }
    }
}
