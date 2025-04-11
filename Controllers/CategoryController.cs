using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SarlApp.Data;
using SarlApp.Models;

namespace SarlApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly DbContextSarl _db;

        public CategoryController(ILogger<CategoryController> logger, DbContextSarl db)
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
            _db.Categories.Add(item);
            _db.SaveChanges();
            return RedirectToAction("Index");
            // return RedirectToAction("Index", Category); // since we are in the same controller, we do not need to add the controller here
        }
    }
}