using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationsManager.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            byte[] bufferUser = new byte[200];
            byte[] bufferFName = new byte[200];
            byte[] bufferLName = new byte[200];
            //byte[] bufferAdmin = new byte[200];
            if (HttpContext.Session.TryGetValue("username", out bufferUser))
            {
                HttpContext.Session.TryGetValue("firstname", out bufferFName);
                HttpContext.Session.TryGetValue("lastname", out bufferLName);
                //HttpContext.Session.TryGetValue("admin", out bufferAdmin);
                ViewData["names"] = Encoding.UTF8.GetString(bufferFName) + " " +
                                    Encoding.UTF8.GetString(bufferLName);
                //bool admin = BitConverter.ToBoolean(bufferAdmin);
                return View();
            }
            return RedirectToAction("Login", "Users");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["admin"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
