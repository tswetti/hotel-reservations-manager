using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelReservationsManager.Models;

namespace HotelReservationsManager.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }


        public bool CheckActive()
        {
            byte[] bufferActive = new byte[200];
            if (HttpContext.Session.TryGetValue("active", out bufferActive))
            {
                int isActive = BitConverter.ToInt32(bufferActive);
                if (isActive == 1)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            ViewData["Clients"] = "";
            ViewData["Rooms"] = "";
            ViewData["UserId"] = "";
            ViewData["Rooms"] = "";
            ViewData["UserId"] = "";
            byte[] bufferActive = new byte[200];
            if (HttpContext.Session.TryGetValue("active", out bufferActive))
            {
                if (!CheckActive())
                {
                    return RedirectToAction("Index", "Main");
                }
                var applicationDbContext = _context.Reservations.Include(r => r.User);
                return View(await applicationDbContext.ToListAsync());
            }

            return RedirectToAction("Login", "Users");
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            byte[] bufferActive = new byte[200];
            if (HttpContext.Session.TryGetValue("active", out bufferActive))
            {
                if (!CheckActive())
                {
                    return RedirectToAction("Index", "Main");
                }
                if (id == null)
                {
                    return NotFound();
                }

                var reservation = await _context.Reservations
                    .Include(r => r.User)
                    .FirstOrDefaultAsync(m => m.ReservationId == id);
                if (reservation == null)
                {
                    return NotFound();
                }

                return View(reservation);
            }

            return RedirectToAction("Login", "Users");
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            ViewData["Clients"] = "";
            ViewData["Rooms"] = "";
            ViewData["UserId"] = "";
            TempData["date"] = "";
            byte[] bufferActive = new byte[200];
            if (HttpContext.Session.TryGetValue("active", out bufferActive))
            {
                if (!CheckActive())
                {
                    return RedirectToAction("Index", "Main");
                }
                ViewData["Rooms"] = new SelectList(_context.Rooms, "RoomId", "Number");
                ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
                ViewData["Clients"] = new SelectList(_context.Clients, "ClientId", "FirstName", "LastName");
                return View();
            }

            return RedirectToAction("Login", "Users");
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Clients, [Bind("ReservationId,Room,UserId,Clients,ArrivalDate,DepartureDate,Breakfast,AllInclusive,TotalPrice")] Reservation reservation)
        {
            string allClients = Clients;
            ViewData["check"] = allClients;
            return View();
            int childrenCount = 0;
            int adultsCount = 0;
            if (ModelState.IsValid)
            {
                if (reservation.ArrivalDate<reservation.DepartureDate)
                {
                    TempData["resdate"] = "Departure date cannot be before arrival date!";
                    return View();
                }

                

                foreach (Client c in reservation.Clients)
                {
                    if (c.Adult)
                    {
                        adultsCount++;
                    }
                    else
                    {
                        childrenCount++;
                    } 
                }
                //Room room = new Room(r => r.Number == reservation.Room);
                //decimal priceAllAdults = adultsCount * room.PriceAdults;

                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "EGN", reservation.UserId);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            TempData["dates"] = "";
            byte[] bufferActive = new byte[200];
            if (HttpContext.Session.TryGetValue("active", out bufferActive))
            {
                if (!CheckActive())
                {
                    return RedirectToAction("Index", "Main");
                }
                if (id == null)
                {
                    return NotFound();
                }

                var reservation = await _context.Reservations.FindAsync(id);
                if (reservation == null)
                {
                    return NotFound();
                }
                ViewData["UserId"] = new SelectList(_context.Users, "UserId", "EGN", reservation.UserId);
                return View(reservation);
            }

            return RedirectToAction("Login", "Users");
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationId,Room,UserId,ArrivalDate,DepartureDate,Breakfast,AllInclusive,TotalPrice")] Reservation reservation)
        {
            if (id != reservation.ReservationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (reservation.ArrivalDate < reservation.DepartureDate)
                {
                    TempData["resdate"] = "Departure date cannot be before arrival date!";
                    return View();
                }
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ReservationId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "EGN", reservation.UserId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            byte[] bufferActive = new byte[200];
            if (HttpContext.Session.TryGetValue("active", out bufferActive))
            {
                if (!CheckActive())
                {
                    return RedirectToAction("Index", "Main");
                }
                if (id == null)
                {
                    return NotFound();
                }

                var reservation = await _context.Reservations
                    .Include(r => r.User)
                    .FirstOrDefaultAsync(m => m.ReservationId == id);
                if (reservation == null)
                {
                    return NotFound();
                }

                return View(reservation);
            }

            return RedirectToAction("Login", "Users");
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.ReservationId == id);
        }
    }
}
