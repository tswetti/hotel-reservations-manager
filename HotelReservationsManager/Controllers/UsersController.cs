using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelReservationsManager.Models;
using HotelReservationsManager.Utilities;
using System.Text;

namespace HotelReservationsManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Login()
        {
            ViewData["result"] = "";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (username == null || password == null)
            {
                ViewData["result"] = "Type username and password!";
                return View();
            }

            string hashPass = Security.ComputeSha256Hash(password);
            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Username == username && m.Password == hashPass);
            if (user == null)
            {
                ViewData["result"] = "Invalid username or password!";
                return View();
            }
            HttpContext.Session.Set("username", Encoding.UTF8.GetBytes(user.Username));
            HttpContext.Session.Set("firstname", Encoding.UTF8.GetBytes(user.FirstName));
            HttpContext.Session.Set("lastname", Encoding.UTF8.GetBytes(user.LastName));

            bool isAdmin = user.Admin;

            if (isAdmin)
            {
                HttpContext.Session.Set("admin", BitConverter.GetBytes(1));
                TempData["admin"] = true;

            }
            else
            {
                HttpContext.Session.Set("admin", BitConverter.GetBytes(0));
                TempData["admin"] = false;
            }
            //ViewData["admin"] = "test";

            return RedirectToAction("Index", "Main");
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            byte[] bufferAdmin = new byte[200];
            if (HttpContext.Session.TryGetValue("admin", out bufferAdmin))
            {
                int isAdmin = BitConverter.ToInt32(bufferAdmin);
                if (isAdmin == 1)
                {
                    return View(await _context.Users.ToListAsync());
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Users");
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            byte[] bufferAdmin = new byte[200];
            if (HttpContext.Session.TryGetValue("admin", out bufferAdmin))
            {
                int isAdmin = BitConverter.ToInt32(bufferAdmin);
                if (isAdmin == 1)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var user = await _context.Users
                        .FirstOrDefaultAsync(m => m.UserId == id);
                    if (user == null)
                    {
                        return NotFound();
                    }

                    return View(user);
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Users");
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            byte[] bufferAdmin = new byte[200];
            if (HttpContext.Session.TryGetValue("admin", out bufferAdmin))
            {
                int isAdmin = BitConverter.ToInt32(bufferAdmin);
                if (isAdmin==1)
                {
                    return View();
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Users");
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Username,Password,FirstName,MiddleName,LastName,EGN,Email,Admin,HireDate,Active,DismissalDate")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Security.ComputeSha256Hash(user.Password);
                user.HireDate = DateTime.Today;
                user.Active = true;
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            byte[] bufferAdmin = new byte[200];
            if (HttpContext.Session.TryGetValue("admin", out bufferAdmin))
            {
                int isAdmin = BitConverter.ToInt32(bufferAdmin);
                if (isAdmin == 1)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var user = await _context.Users.FindAsync(id);
                    if (user == null)
                    {
                        return NotFound();
                    }
                    return View(user);
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Users");
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Username,Password,FirstName,MiddleName,LastName,EGN,Email,Admin,HireDate,Active,DismissalDate")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            byte[] bufferAdmin = new byte[200];
            if (HttpContext.Session.TryGetValue("admin", out bufferAdmin))
            {
                int isAdmin = BitConverter.ToInt32(bufferAdmin);
                if (isAdmin == 1)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var user = await _context.Users
                        .FirstOrDefaultAsync(m => m.UserId == id);
                    if (user == null)
                    {
                        return NotFound();
                    }

                    return View(user);
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Users");
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
