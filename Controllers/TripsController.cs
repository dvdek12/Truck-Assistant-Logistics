using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TruckAssistant.Data;
using TruckAssistant.Models;

namespace TruckAssistant.Controllers
{
    public class TripsController : Controller
    {
        private readonly TruckAssistantContext _context;

        public TripsController(TruckAssistantContext context)
        {
            _context = context;
        }

        // GET: Trips
        public async Task<IActionResult> Index(int? id)
        {
            
              return _context.Trip != null ? 
                          View(await _context.Trip.Include(s => s.Truck).ToListAsync()) :
                          Problem("Entity set 'TruckAssistantContext.Trip'  is null.");
        }

        // GET: Trips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trip == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip.Include(s => s.Truck)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Trips/Create
        public IActionResult Create()
        {
            ViewData["Truck"] = new SelectList(_context.Truck, "Id", "Name");
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate,CreateDate,Range,Description, TruckId")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                Truck truck = await _context.Truck.FirstOrDefaultAsync(m => m.Id == trip.TruckId);

                trip.CreateDate = DateTime.Now;
                trip.EndDate = this.GetEndDate(trip, truck);

                _context.Add(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Truck"] = new SelectList(_context.Truck, "Id", "Name");
            return View(trip);
        }

        private DateTime GetEndDate(Trip trip, Truck truck)
        {
            DateTime StartDate = (DateTime)trip.StartDate; //25.07.2022
            int Range = trip.Range; // 2000 km
            int BreakLength = truck.DriverBreaksLength; // 30 min
            int BreakInterval = truck.DriverBreaksInterval; // 8 h
            int Vmax = truck.Vmax; // 150 km/h

            int hours = Range / Vmax; // 13 h
            int lastKm = Range % Vmax; // 50 km
            double lastDistanceTime = Math.Round(((double)lastKm / (double)Vmax), 2); // 0.33 h

            int intervals = hours / BreakInterval; // 1
            double breaksTime = ((double)intervals * (double)BreakLength) / 60; // 0.5 h 
            double AbsoluteHoursToEndTrip = (double)hours + lastDistanceTime + breaksTime;
            DateTime EndDate = StartDate.AddHours(AbsoluteHoursToEndTrip);

            return EndDate;
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trip == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate,EndDate,CreateDate,Range,Description")] Trip trip)
        {
            if (id != trip.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var InstanceOfTrip = await _context.Trip.FirstOrDefaultAsync(m => m.Id == trip.Id);
                    var InstanceOfTruck = await _context.Truck.FirstOrDefaultAsync(m => m.Id == trip.TruckId);
                    InstanceOfTrip.StartDate = trip.StartDate;
                    InstanceOfTrip.Range = trip.Range;
                    InstanceOfTrip.Description = trip.Description;
                    InstanceOfTrip.EndDate = this.GetEndDate(InstanceOfTrip, InstanceOfTruck);

                    
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.Id))
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
            return View(trip);
        }

        // GET: Trips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trip == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trip == null)
            {
                return Problem("Entity set 'TruckAssistantContext.Trip'  is null.");
            }
            var trip = await _context.Trip.FindAsync(id);
            if (trip != null)
            {
                _context.Trip.Remove(trip);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(int id)
        {
          return (_context.Trip?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
