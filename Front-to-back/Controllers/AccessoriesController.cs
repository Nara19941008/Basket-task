using Front_to_back.Data;
using Front_to_back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Front_to_back.Controllers
{
    public class AccessoriesController : Controller
    {
        private readonly AppDbContext _context;
        public AccessoriesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.count = await _context.Accessories.CountAsync();
            IEnumerable<Accessory> products = await _context.Accessories.Take(3).OrderBy(m => m.Id).ToListAsync();
            return View(products);
        }
        public async Task<IActionResult> LoadMore(int skip)
        {
            IEnumerable<Accessory> products = await _context.Accessories.Include(m => m.Image).Skip(skip).Take(3).ToListAsync();

            return View(products);
        }
    }

}