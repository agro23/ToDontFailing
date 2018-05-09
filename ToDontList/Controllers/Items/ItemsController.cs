using Microsoft.AspNetCore.Mvc;
using ToDontList.Models;
using System.Linq;
using System.Collections.Generic;

namespace ToDontList.Controllers
{
    public class ItemsController : Controller
    {
        private ToDontListDbContext db = new ToDontListDbContext();
       
        public IActionResult Index()
        {
            List<Item> model = db.Items.ToList();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            Item thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
            return View(thisItem);
        }
    }
}