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
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
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

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            byte[] bufferActive = new byte[200];
            if (HttpContext.Session.TryGetValue("active", out bufferActive))
            {
                if (!CheckActive())
                {
                    return RedirectToAction("Index", "Main");
                }
                return View(await _context.Clients.ToListAsync());
            }
        
            return RedirectToAction("Login", "Users");
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            TempData["email"] = "";
            TempData["phonenumber"] = "";
            byte[] bufferActive = new byte[200];
            if (HttpContext.Session.TryGetValue("active", out bufferActive))
            {
                if (!CheckActive())
                {
                    return RedirectToAction("Index", "Main");
                }
                return View();
            }
        
            return RedirectToAction("Login", "Users");
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,FirstName,LastName,PhoneNumber,Email,Adult")] Client client)
        {
            if (ModelState.IsValid)
            {
                if (_context.Clients.Any(c => c.Email == client.Email))
                {
                    TempData["email"] = "There's already a client with that email!";
                    return View();
                }
                else if (_context.Clients.Any(c => c.PhoneNumber == client.PhoneNumber))
                {
                    TempData["phonenumber"] = "There's already a client with that phone number!";
                    return View();
                }
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            TempData["email"] = "";
            TempData["phonenumber"] = "";
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

                var client = await _context.Clients.FindAsync(id);
                if (client == null)
                {
                    return NotFound();
                }
                return View(client);
            }
        
            return RedirectToAction("Login", "Users");
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,FirstName,LastName,PhoneNumber,Email,Adult")] Client client)
        {
            if (id != client.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (_context.Clients.Any(c => c.Email == client.Email))
                {
                    TempData["email"] = "There's already a client with that email!";
                    return View();
                }
                else if (_context.Clients.Any(c => c.PhoneNumber == client.PhoneNumber))
                {
                    TempData["phonenumber"] = "There's already a client with that phone number!";
                    return View();
                }
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ClientId))
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
            return View(client);
        }

        // GET: Clients/Delete/5
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

                var client = await _context.Clients
                    .FirstOrDefaultAsync(m => m.ClientId == id);
                if (client == null)
                {
                    return NotFound();
                }

                return View(client);
            }

            return RedirectToAction("Login", "Users");
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ClientId == id);
        }
    }
}
