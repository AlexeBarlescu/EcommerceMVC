using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

namespace Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly Cart _cart;
        private readonly IDataRepository _repo;
        public OrderController(Cart cart, IDataRepository repo)
        {
            _cart = cart;
            _repo = repo;
        }
        public IActionResult Checkout()
        {
            return View(new Order());
        }
        
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (!_cart.Lines.Any())
            {
                ModelState.AddModelError("", "Your cart is empty");
            }

            if (!ModelState.IsValid) return View();


            order.Lines = _cart.Lines.ToArray();
            _repo.SaveOrder(order);
            _cart.Clear();
            return RedirectToAction(nameof(Completed), new {orderId = order.OrderId});
        }

        public ViewResult Completed(int orderId) => View(orderId);
    }
}