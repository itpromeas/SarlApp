using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MVCWebApp.DataAccess.Repository.IRepository;
using MVCWebApp.Models;

namespace MVCWebApp.Areas.Customer.Controllers;

[Area("Customer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<ProductModel> productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
        return View(productList);
    }

    public IActionResult Details(int productId) // this variable should match with the html asp-route-productId
    {
        ShoppingCart cart = new()
        {
            Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == productId, includeProperties: "Category"),
            Count = 1,
            ProductId = productId
        };
        return View(cart);
    }

    [HttpPost]
    [Authorize]
    public IActionResult Details(ShoppingCart shoppingCart)
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
        shoppingCart.SarlUserId = userId;

        ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(
            u => u.SarlUserId == userId && u.ProductId == shoppingCart.ProductId);

        if (cartFromDb != null)
        {
            //shopping cart exists
            cartFromDb.Count += shoppingCart.Count;
            _unitOfWork.ShoppingCart.Update(cartFromDb);
        }
        else
        {
            //add cart record
            _unitOfWork.ShoppingCart.Add(shoppingCart);
        }

        TempData["success"] = "Cart updated successfully";

        _unitOfWork.Save();


        return RedirectToAction(nameof(Index));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
