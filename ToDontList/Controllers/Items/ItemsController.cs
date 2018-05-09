using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDontList.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDontList.Controllers
{
    public class ItemsController : Controller
    {
        private ToDontListDbContext db = new ToDontListDbContext();
        public IActionResult Index()
        {
            return View(db.Items.Include(items => items.Category).ToList());
        }
        public IActionResult Details(int id)
        {
            var thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
            return View(thisItem);
        }
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View(thisItem);
        }
        [HttpPost]
        public IActionResult Edit(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
            return View(thisItem);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
            db.Items.Remove(thisItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}


//using Microsoft.AspNetCore.Mvc;
//using ToDontList.Models;
//using System.Linq;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace ToDontList.Controllers

//{
//    public class ItemsController : Controller
//    {
//        private ToDontListDbContext db = new ToDontListDbContext();
//        public IActionResult Index()
//        {
//            //return View(db.Items.Include(items => items.Category).ToList());
//            return View(db.Items.Include(items => items.Category).ToList());
//            //return View();
//        }

//        public IActionResult Details(int id)
//        {
//            var thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
//            return View(thisItem);
//        }
//        public IActionResult Create()
//        {
//            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
//            return View();
//        }
//        [HttpPost]
//        public IActionResult Create(Item item)
//        {
//            db.Items.Add(item);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }
//        public IActionResult Edit(int id)
//        {
//            var thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
//            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
//            return View(thisItem);
//        }
//        [HttpPost]
//        public IActionResult Edit(Item item)
//        {
//            db.Entry(item).State = EntityState.Modified;
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }
//        public ActionResult Delete(int id)
//        {
//            var thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
//            return View(thisItem);
//        }
//        [HttpPost, ActionName("Delete")]
//        public IActionResult DeleteConfirmed(int id)
//        {
//            var thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
//            db.Items.Remove(thisItem);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }
//    }
//}
//{
//    public class ItemsController : Controller
//    {
//        private ToDontListDbContext db = new ToDontListDbContext();
       
//        public IActionResult Index()
//        {
//            List<Item> model = db.Items.ToList();
//            return View(db.Items.Include(items => items.Category).ToList());
//        }

//        public IActionResult Details(int id)
//        {
//            Item thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
//            return View(thisItem);
//        }

//        public IActionResult Create()
//        {
//            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Create(Item item)
//        {
//            db.Items.Add(item);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        public IActionResult Edit(int id)
//        {
//            var thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
//            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
//            return View(thisItem);
//        }

//        [HttpPost]
//        public IActionResult Edit(Item item)
//        {
//            db.Entry(item).State = EntityState.Modified;
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        public IActionResult Delete(int id)
//        {
//            var thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
//            return View(thisItem);
//        }

//        [HttpPost, ActionName("Delete")]
//        public IActionResult DeleteConfirmed(int id)
//        {
//            var thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
//            db.Items.Remove(thisItem);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }
//    }
//}