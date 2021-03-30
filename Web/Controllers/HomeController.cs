using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using Web.Data;
using Web.Models;
using Web.Models.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataRepository _repo;
        private const int PageSize = 8;

        public HomeController(IDataRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index(string category, int pageNumber = 1)
        {
            var query = _repo.Products;
            if (category != null)
            {
                query = query.Where(p => p.Category == category);
                ViewBag.SelectedCategory = category;
            }


            return View(new ProductListViewModel
            {
                Products = query.Skip((pageNumber - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    PageSize = PageSize,
                    TotalItems = query.Count(),
                    CurrentPage = pageNumber
                }
            });
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
}
