using Microsoft.AspNetCore.Mvc;
using ToDontList.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToDontList.Controllers

{
    public class CategoriesController : Controller
    {
        private ToDontListDbContext db = new ToDontListDbContext();
        public IActionResult Index()
        {
            return View(db.Categories.Include(categories => categories.CategoryId).ToList());
        }
        public IActionResult Details(int id)
        {
            var thisCategory = db.Categories.FirstOrDefault(categories => categories.CategoryId == id);
            return View(thisCategory);
        }
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category item)
        {
            db.Categories.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisCategory = db.Categories.FirstOrDefault(categories => categories.CategoryId == id);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View(thisCategory);
        }
        [HttpPost]
        public IActionResult Edit(Category item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisCategory = db.Categories.FirstOrDefault(categories => categories.CategoryId == id);
            return View(thisCategory);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisCategory = db.Categories.FirstOrDefault(categories => categories.CategoryId == id);
            db.Categories.Remove(thisCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}