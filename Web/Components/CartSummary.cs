using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Components
{
    public class CartSummary: ViewComponent
    {
        private readonly Cart _cart;
        
        public CartSummary(Cart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke() => View(_cart.Lines.Sum(x => x.Quantity));
        
    }
}