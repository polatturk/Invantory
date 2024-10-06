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
                // Dosya adýný ve yolunu belirle
                var fileName = Path.GetFileName(Image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                // Dosyayý sunucuya kaydet
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }

                // Modelin ImagePath alanýna dosya yolunu ekle
                model.ImagePath = "/images/" + fileName;
            }

            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;

            // Veritabanýna kaydet
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


    }
}