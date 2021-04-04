using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationsManager.Controllers
{
    public class LoggedInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
