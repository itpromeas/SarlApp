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
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;

        private readonly DbContextRazorSarl _db;
        public List<CategoryModelRazorApp> CategoryList {get; set;}

        public Index(ILogger<Index> logger, DbContextRazorSarl db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}