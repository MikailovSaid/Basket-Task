using BasketTask.Data;
using BasketTask.Models;
using BasketTask.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.Include(i=>i.Images).ToListAsync();
            SliderImage sliderImage = await _context.SliderImages.FirstOrDefaultAsync();
            List<Categories> categories = await _context.Categories.Include(i => i.CategoryProducts).ToListAsync();
            List<CategoryProducts> categoryProducts = await _context.CategoryProducts.ToListAsync();

            HomeVM homeVM = new HomeVM
            {
                Sliders = sliders,
                SliderImage = sliderImage,
                Categories = categories,
                CategoryProducts = categoryProducts
            };

            return View(homeVM);
        }
    }
}
