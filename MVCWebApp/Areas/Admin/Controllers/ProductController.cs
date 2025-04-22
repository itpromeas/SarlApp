using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCWebApp.DataAccess.Repository.IRepository;
using MVCWebApp.Models;

namespace MVCWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(ILogger<ProductController> logger, IUnitOfWork db)
        {
            _logger = logger;
            _unitOfWork = db;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.Product.GetAll());
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> categories = _unitOfWork.Category
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

            //ViewBag.CategoryList = categories;
            ViewData["Categories"] = categories;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductModel item)
        {

            if (item.Title == null)
            {
                ModelState.AddModelError("title", "The title should not be empty.");
            }
            else
            {
                if (item.Title.Equals("test", StringComparison.CurrentCultureIgnoreCase))
                {
                    ModelState.AddModelError("", "The title cannot be test.");
                }
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(item);
                _unitOfWork.Save();

                TempData["success"] = "Product created succesfully";

                return RedirectToAction("Index");
                // return RedirectToAction("Index", Product); // since we are in the same controller, we do not need to add the controller here
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            //ProductModel? productFromDb = _db.Products.Find(id);
            ProductModel? productFromDb = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
            //ProductModel? productFromDb2 = _db.Products.Where(u=>u.Id==id).FirstOrDefault();

            if (productFromDb == null)
                return NotFound();

            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(ProductModel obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product updated succesfully";

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
            ProductModel? productFromDb = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);

            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            ProductModel? obj = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted succesfully";

            return RedirectToAction("Index");
        }
    }
}