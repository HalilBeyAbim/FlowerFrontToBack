using FrontToBackFlower.DAL;
using FrontToBackFlower.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBackFlower.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext? _dbContext;

        public ProductController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var products = _dbContext.Products.Include(c => c.Category).ToList();
            var homeViewModel = new HomeViewModel
            {
                Products = products,
            };
            return View(homeViewModel);
        }

        public IActionResult Details(int? id)
        {
            var product = _dbContext.Products.SingleOrDefault(x => x.Id == id);
            return View(product);
        }
    }
}
