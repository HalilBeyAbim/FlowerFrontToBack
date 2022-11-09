using FrontToBackFlower.DAL;
using FrontToBackFlower.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBackFlower.View_Components
{
    public class DiscountViewComponents
    {
        private readonly AppDbContext _appDbContext;
        public DiscountViewComponents(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Product> products = await _appDbContext.Products.Where(c => c.Discount != null).Include(x =>
            x.Category).ToListAsync();
            return View(products);
        }

        private IViewComponentResult View(List<Product> products)
        {
            throw new NotImplementedException();
        }
    }
}
