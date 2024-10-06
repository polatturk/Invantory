using Invantory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Invantory.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}
