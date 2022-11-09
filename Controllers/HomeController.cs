using FrontToBackFlower.DAL;
using FrontToBackFlower.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBackFlower.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public IActionResult Index()
        {
            var sliderImage = _dbContext.SliderImages.ToList();

            var sliders = _dbContext.Sliders.SingleOrDefault();
            var category = _dbContext.Categories.ToList();
            var product = _dbContext.Products.Include(c => c.Category).ToList();

                var homeViewModel = new HomeViewModel
                {
                    Sliders = sliders,
                    SliderImages = sliderImage,
                    Categories = category,
                    Products = product,
                };


                return View(homeViewModel);
            }
    }
}
