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
    [BindProperties] // to bind all properties in this class
    public class Create : PageModel
    {
        private readonly ILogger<Create> _logger;
        private readonly DbContextRazorSarl _db;

        //[BindProperty] // in order to access the category in post method
        public CategoryModelRazorApp Category {get; set;}

        public Create(ILogger<Create> logger, DbContextRazorSarl db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        { 
            _db.Categories.Add(Category);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }

    }
}