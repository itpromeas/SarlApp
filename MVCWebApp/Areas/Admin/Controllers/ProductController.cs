using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCWebApp.DataAccess.Repository.IRepository;
using MVCWebApp.Models;
using MVCWebApp.Models.ViewModels;
using MVCWebApp.Utility;

namespace MVCWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(ILogger<ProductController> logger, IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _unitOfWork = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.Product.GetAll(includeProperties: "Category"));
        }

        public IActionResult UpdateOrCreate(int? id)
        {
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new ProductModel()
            };

            if (id == null || id == 0)
            {
                // create
                return View(productVM);
            }
            else
            {
                // update
                productVM.Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
                return View(productVM);
            }
        }

       
        #region API Calls
        [HttpPost]
        public IActionResult UpdateOrCreate(ProductVM item, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    String pathDir = @"images/products";
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, pathDir);

                    if (!string.IsNullOrEmpty(item.Product.ImageUrl))
                    {
                        //delete the old image
                        var oldImagePath = Path.Combine(wwwRootPath, item.Product.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    item.Product.ImageUrl = pathDir + @"/" + fileName;
                }

                if (item.Product.Title == null)
                {
                    ModelState.AddModelError("title", "The title should not be empty.");
                }
                else
                {
                    if (item.Product.Title.Equals("test", StringComparison.CurrentCultureIgnoreCase))
                    {
                        ModelState.AddModelError("", "The title cannot be test.");
                    }
                }

                if (item.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(item.Product);
                    TempData["success"] = "Product created succesfully";
                }
                else
                {
                    _unitOfWork.Product.Update(item.Product);
                    TempData["success"] = "Product updated succesfully";
                }

                _unitOfWork.Save();

                return RedirectToAction("Index");
                // return RedirectToAction("Index", Product); // since we are in the same controller, we do not need to add the controller here
            }
            else
            {
                item.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(item);
            }
        }

        

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ProductModel> objProductList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = objProductList });
        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ProductModel? productToBeDeleted = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);

            if (productToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            if (productToBeDeleted.ImageUrl != null)
            {
                var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, productToBeDeleted.ImageUrl.TrimStart('\\'));

                if (System.IO.File.Exists(oldImagePath))
                    System.IO.File.Delete(oldImagePath);

            }

            _unitOfWork.Product.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
            //return View(productFromDb);
        }

        #endregion
    }
}