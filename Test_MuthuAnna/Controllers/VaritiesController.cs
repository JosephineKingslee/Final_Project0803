using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodOrderingKingslee.Models;

namespace FoodOrderingKingslee.Controllers
{
    public class VaritiesController : Controller
    {
        private readonly MenuContext context;

        public VaritiesController(MenuContext ctx)
        {
            context = ctx;
        }

        // GET: Varities
        public async Task<IActionResult> Index()
        {
            return View(await context.Varities.ToListAsync());
        }

        // GET: Varities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var varities = await context.Varities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (varities == null)
            {
                return NotFound();
            }

            return View(varities);
        }

        // GET: Varities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Varities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Varities varities)
        {
            if (ModelState.IsValid)
            {
                context.Add(varities);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(varities);
        }

        // GET: Varities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var varities = await context.Varities.FindAsync(id);
            if (varities == null)
            {
                return NotFound();
            }
            return View(varities);
        }

        // POST: Varities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Varities varities)
        {
            if (id != varities.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(varities);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaritiesExists(varities.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(varities);
        }

        // GET: Varities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var varities = await context.Varities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (varities == null)
            {
                return NotFound();
            }

            return View(varities);
        }

        // POST: Varities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var varities = await context.Varities.FindAsync(id);
            context.Varities.Remove(varities);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaritiesExists(int id)
        {
            return context.Varities.Any(e => e.Id == id);
        }
    }
}
