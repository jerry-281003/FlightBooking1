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
    public class PlanesController : Controller
    {
        private readonly FlightBooking1Context _context;

        public PlanesController(FlightBooking1Context context)
        {
            _context = context;
        }

        // GET: Planes
        public async Task<IActionResult> Index()
        {
              return _context.Plane != null ? 
                          View(await _context.Plane.ToListAsync()) :
                          Problem("Entity set 'FlightBooking1Context.Plane'  is null.");
        }

        // GET: Planes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plane == null)
            {
                return NotFound();
            }

            var plane = await _context.Plane
                .FirstOrDefaultAsync(m => m.PlaneID == id);
            if (plane == null)
            {
                return NotFound();
            }

            return View(plane);
        }

        // GET: Planes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaneID,TypeOfPlane")] Plane plane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plane);
        }

        // GET: Planes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Plane == null)
            {
                return NotFound();
            }

            var plane = await _context.Plane.FindAsync(id);
            if (plane == null)
            {
                return NotFound();
            }
            return View(plane);
        }

        // POST: Planes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlaneID,TypeOfPlane")] Plane plane)
        {
            if (id != plane.PlaneID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaneExists(plane.PlaneID))
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
            return View(plane);
        }

        // GET: Planes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Plane == null)
            {
                return NotFound();
            }

            var plane = await _context.Plane
                .FirstOrDefaultAsync(m => m.PlaneID == id);
            if (plane == null)
            {
                return NotFound();
            }

            return View(plane);
        }

        // POST: Planes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Plane == null)
            {
                return Problem("Entity set 'FlightBooking1Context.Plane'  is null.");
            }
            var plane = await _context.Plane.FindAsync(id);
            if (plane != null)
            {
                _context.Plane.Remove(plane);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaneExists(int id)
        {
          return (_context.Plane?.Any(e => e.PlaneID == id)).GetValueOrDefault();
        }
    }
}
