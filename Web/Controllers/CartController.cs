using Microsoft.AspNetCore.Mvc;
using Web.Data;
using Web.Models;

namespace Web.Controllers
{
    public class CartController : Controller
    {
        private readonly Cart _cart;
        private readonly IDataRepository _repo;
        
        public CartController(IDataRepository repo,Cart cart)
        {
            _cart = cart;
            _repo = repo;
        }

        public IActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(_cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            Product p = _repo.GetProduct(productId);
            _cart.AddItem(p, quantity);
            return Redirect(returnUrl);
        }
        [HttpPost]
        public IActionResult UpdateCart(int productId, int quantity, string returnUrl)
        {
            Product p = _repo.GetProduct(productId);
            _cart.UpdateItem(p, quantity);
            return RedirectToAction(nameof(Index), new {returnUrl = returnUrl});
        }
    }
}