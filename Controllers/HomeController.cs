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
        [HttpPost]
        public IActionResult Add(Item model, IFormFile Image)
        {
            if (Image != null && Image.Length > 0)
            {
                var fileName = Path.GetFileName(Image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }

                model.ImagePath = "/images/" + fileName;
            }

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
        public IActionResult Form(string itemName)
        {
            var model = new Item
            {
                Name = itemName 
            };
            return View(model); 
        }

        public IActionResult Details(string searchItem)
        {
            if (string.IsNullOrWhiteSpace(searchItem))
            {
                ViewBag.ErrorMessage = "Search term cannot be empty!";
                return View("Error"); 
            }

            var item = _context.Items
                .FirstOrDefault(a => a.Name.ToLower() == searchItem.ToLower());

            if (item == null)
            {
                ViewBag.ErrorMessage = "Product not found!";
                return View("Error"); 
            }

            return View(item); 
        }

    }
}