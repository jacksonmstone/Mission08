using Microsoft.AspNetCore.Mvc;
using Mission8_3_11.Models;
using System.Diagnostics;

namespace Mission8_3_11.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
