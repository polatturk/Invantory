using Invantory.Data;
using Invantory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Invantory.Controllers
{
    public class AdminController : Controller
    {
        private readonly InvantoryContext _context;

        public AdminController(InvantoryContext context)
        {
            _context = context;
        }
        public IActionResult Index(Location model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult PlaceAdd(Place model)
        {
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;

            _context.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult SectionAdd(Section model)
        {
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;

            _context.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult LocationAdd(Location model)
        {
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;

            _context.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _context.Remove(_context.Items.Single(a => a.Id == id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
