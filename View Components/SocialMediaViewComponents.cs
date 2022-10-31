using FrontToBackFlower.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBackFlower.View_Components
{

    public class SocialMediaViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbcontext;

        public SocialMediaViewComponent(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var social = await _dbcontext.SocialMedias.ToListAsync();

            return View(social);
        }
    }
}

