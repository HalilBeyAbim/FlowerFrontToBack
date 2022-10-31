using FrontToBackFlower.DAL;
using FrontToBackFlower.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
                var product = _dbContext.Products.ToList();

                var homeViewModel = new HomeViewModel
                {
                    Sliders = sliders,
                    SliderImage = sliderImage,
                    Categories = category,
                    Products = product,
                };


                return View(homeViewModel);
            }
    }
}
