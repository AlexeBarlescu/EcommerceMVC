using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public IActionResult Index(string category, int pageNumber = 1) => 
            View(new ProductListViewModel 
            {
                Products = _repo.Products
                    .Where(p => category == null || p.Category == category)
                    .Skip((pageNumber - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    PageSize = PageSize,
                    TotalItems = category == null ? 
                        _repo.Products.Count() : 
                        _repo.Products.Count(p => p.Category == category),
                    CurrentPage = pageNumber
                }
            });

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
