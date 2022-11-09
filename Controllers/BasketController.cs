﻿using FrontToBackFlower.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FrontToBackFlower.ViewModels.Basket;
using Newtonsoft.Json;

namespace FrontToBackFlower.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext appDbContext;
        private object _appdbcontext;

        public BasketController(AppDbContext appDbContext)
        {
            appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var basketItems = GetBasketItems();
            return View(basketItems);

        }
        public async Task<IActionResult> AddToBasket(int? productId)
        {
            if (productId is null) return BadRequest();
            var product = await _appdbcontext.Products.where(x => x.Id == productId).FirstOrDefaultAsync();
            if (product is null) return NotFound();

            var basket = Request.Cookies["basket"];
            var basketItems = new List<BasketItemViewModel>();
            var basketItem = new BasketItemViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
                Discount = product.Discount,
                Count = 1

            };
            if (basket is null)
            {
                basketItems.Add(basketItem);
            }
            else
            {
                basketItems = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(basket);
                var existProduct = basketItems.Where(p => p.Id == product.Id).FirstOrDefault();
                if (existProduct is null) basketItems.Add(basketItem);
                else existProduct.Count += 1;

            }

            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketItems), option);

            return Ok();
        }

        public async Task<IActionResult> GetBasketCount()
        {
            var basketItems = GetBasketItems();
            return Ok(basketItems.Count);
        }

        private List<BasketItemViewModel> GetBasketItems()
        {
            var basket = Request.Cookies["basket"];
            var basketItems = basket is not null
                    ? JsonConvert.DeserializeObject<List<BasketItemViewModel>>(basket)
                    : new List<BasketItemViewModel>();
            return basketItems;
        }
    }
}
