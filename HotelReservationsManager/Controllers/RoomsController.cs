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
    public class RoomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomsController(ApplicationDbContext context)
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

        public bool CheckAdmin()
        {
            byte[] bufferAdmin = new byte[200];
            if (HttpContext.Session.TryGetValue("admin", out bufferAdmin))
            {
                int isAdmin = BitConverter.ToInt32(bufferAdmin);
                if (isAdmin == 1)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            byte[] bufferActive = new byte[200];
            if (HttpContext.Session.TryGetValue("active", out bufferActive))
            {
                if (!CheckActive())
                {
                    return RedirectToAction("Index", "Home");
                }
                return View(await _context.Rooms.ToListAsync());
            }
            return RedirectToAction("Login", "Users");
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            byte[] bufferActive = new byte[200];
            if (HttpContext.Session.TryGetValue("active", out bufferActive))
            {
                if (!CheckActive())
                {
                    return RedirectToAction("Index", "Main");
                }
            }
            byte[] bufferAdmin = new byte[200];
            if (HttpContext.Session.TryGetValue("admin", out bufferAdmin))
            {
                if (CheckAdmin())
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var room = await _context.Rooms
                        .FirstOrDefaultAsync(m => m.RoomId == id);
                    if (room == null)
                    {
                        return NotFound();
                    }

                    return View(room);
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Users");
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            TempData["room"] = "";
            byte[] bufferActive = new byte[200];
            if (HttpContext.Session.TryGetValue("active", out bufferActive))
            {
                if (!CheckActive())
                {
                    return RedirectToAction("Index", "Main");
                }
            }
            byte[] bufferAdmin = new byte[200];
            if (HttpContext.Session.TryGetValue("admin", out bufferAdmin))
            {
                if (CheckAdmin())
                {
                    return View();
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Users");
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomId,Capacity,Type,Available,PriceAdults,PriceChildren,Number")] Room room)
        {
            if (ModelState.IsValid)
            {
                if (_context.Rooms.Any(r => r.Number == r.Number))
                {
                    TempData["room"] = "A room with that number already exists!";
                    return View();
                }
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            TempData["room"] = "";
            byte[] bufferActive = new byte[200];
            if (HttpContext.Session.TryGetValue("active", out bufferActive))
            {
                if (!CheckActive())
                {
                    return RedirectToAction("Index", "Main");
                }
            }
            byte[] bufferAdmin = new byte[200];
            if (HttpContext.Session.TryGetValue("admin", out bufferAdmin))
            {
                if (CheckAdmin())
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var room = await _context.Rooms.FindAsync(id);
                    if (room == null)
                    {
                        return NotFound();
                    }
                    return View(room);
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Users");
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomId,Capacity,Type,Available,PriceAdults,PriceChildren,Number")] Room room)
        {
            if (id != room.RoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (_context.Rooms.Any(r => r.Number == r.Number))
                {
                    TempData["room"] = "A room with that number already exists!";
                    return View();
                }
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.RoomId))
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
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            byte[] bufferActive = new byte[200];
            if (HttpContext.Session.TryGetValue("active", out bufferActive))
            {
                if (!CheckActive())
                {
                    return RedirectToAction("Index", "Main");
                }
            }
            byte[] bufferAdmin = new byte[200];
            if (HttpContext.Session.TryGetValue("admin", out bufferAdmin))
            {
                if (CheckAdmin())
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var room = await _context.Rooms
                        .FirstOrDefaultAsync(m => m.RoomId == id);
                    if (room == null)
                    {
                        return NotFound();
                    }

                    return View(room);
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Users");
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.RoomId == id);
        }
    }
}
