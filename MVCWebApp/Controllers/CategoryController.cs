using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCWebApp.Data;
using MVCWebApp.Models;

namespace MVCWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly DbContextMVCSarl _db;

        public CategoryController(ILogger<CategoryController> logger, DbContextMVCSarl db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var categories = _db.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryModel item)
        {
            if(item.DisplayOrder < 1 || item.DisplayOrder > 100){
                ModelState.AddModelError("DisplayOrder", "The Display Name must be between 1 and 100");
            }

            if(item.Name == item.DisplayOrder.ToString()){
                ModelState.AddModelError("name", "The DisplaName cannot exactly match the Name.");
            }

            if(item.Name == null){
                ModelState.AddModelError("name", "The DisplaName should not be empty.");
            }
            else {
                if(item.Name.Equals("test", StringComparison.CurrentCultureIgnoreCase))
                {
                    ModelState.AddModelError("", "The Displ cannot be test.");
                }
            }

            if(ModelState.IsValid){
                _db.Categories.Add(item);
                _db.SaveChanges();

                TempData["success"] = "Category created succesfully";

                return RedirectToAction("Index");
            // return RedirectToAction("Index", Category); // since we are in the same controller, we do not need to add the controller here
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
                return NotFound();
            
            //CategoryModel? categoryFromDb = _db.Categories.Find(id);
            CategoryModel? categoryFromDb = _db.Categories.FirstOrDefault(u => u.Id == id);
            //CategoryModel? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

            if (categoryFromDb == null)
                return NotFound();
            
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(CategoryModel obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated succesfully";

                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            CategoryModel? categoryFromDb = _db.Categories.FirstOrDefault(u=>u.Id==id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            CategoryModel? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted succesfully";

            return RedirectToAction("Index");
        }
    }
}