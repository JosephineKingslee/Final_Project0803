using FoodOrderingKingslee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingKingslee.Controllers
{
    public class MainMenuController : Controller
    {
        private MenuContext context;

        public MainMenuController(MenuContext ctx)
        {
            context = ctx;
        }
        // GET: MainMenuController1
        public async Task<IActionResult> Index()
        {
            var a = await context.Varities.Include(s => s.Menus).AsNoTracking().ToListAsync();
            return View(a);
        }
    }
}
