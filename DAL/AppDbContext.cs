using FrontToBackFlower.Models;
using Microsoft.EntityFrameworkCore;

namespace FrontToBackFlower.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Slider>? Sliders { get; set; }
        public DbSet<SliderImage>? SliderImages { get; set; }
    }
}
