using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorApp.Data;
using RazorApp.Models;

namespace RazorApp.Pages.Categories
{
    public class Edit : PageModel
    {
        private readonly ILogger<Edit> _logger;
        private readonly DbContextRazorSarl _db;

        [BindProperty] // in order to access the category in post method
        public CategoryModelRazorApp Category {get; set;}

        public Edit(ILogger<Edit> logger, DbContextRazorSarl db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet(int? id)
        {
            if(id !=null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }
 
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                //TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}