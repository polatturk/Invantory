using Invantory.Data;
using Invantory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Invantory.Controllers
{
    public class HomeController : Controller
    {
        private readonly InvantoryContext _context;

        public HomeController(InvantoryContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Item> items = _context.Items.ToList();

            return View(items);
        }
        public IActionResult Add(Item model)
        {
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            _context.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Form");

        }
        public IActionResult Delete(int id)
        {
            _context.Remove(_context.Items.Single(a => a.Id == id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Form()
        {
            return View();
        }
    }
}
