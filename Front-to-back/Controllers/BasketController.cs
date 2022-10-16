using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Front_to_back.Data;
using Front_to_back.Models;
using Front_to_back.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Front_to_back.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;

        public BasketController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<BasketVM> basketItems = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            List<BasketDetailVM> basketDetail = new List<BasketDetailVM>();

            foreach (var item in basketItems)
            {
                Product product = await _context.Products.Where(m => m.Id == item.Id && !m.IsDeleted).FirstOrDefaultAsync();

                BasketDetailVM newBasket = new BasketDetailVM
                {
                    Title = product.Title,
                    Image = product.Image,
                    Price = product.Price,
                    Count = item.Count,
                    Total = product.Price * item.Count
                };

                basketDetail.Add(newBasket);
            }

            return View(basketDetail);
        }
    }
}