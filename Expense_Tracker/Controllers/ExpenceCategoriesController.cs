using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Expense_Tracker.Models;

namespace Expense_Tracker.Controllers
{
    public class ExpenceCategoriesController : Controller
    {
        private readonly DatabaseContext _context;

        public ExpenceCategoriesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: ExpenceCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: ExpenceCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenceCategory = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (expenceCategory == null)
            {
                return NotFound();
            }

            return View(expenceCategory);
        }

        // GET: ExpenceCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExpenceCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName")] ExpenceCategory expenceCategory)
        {
            if (ModelState.IsValid)
            {
                var duplicateCheck = _context.Categories.Where(c => c.CategoryName.Contains(expenceCategory.CategoryName));
                if (duplicateCheck.Count() > 0)
                {
                    TempData["alertMessage"] = "Expense category already exist";
                    //TempData["alertMessage"] = "<script>alert('Expense category already exist');</script>";
                    //ViewBag.Message = string.Format("Hello");
                }
                else
                {
                    _context.Add(expenceCategory);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                
            }
            return View(expenceCategory);
        }

        // GET: ExpenceCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenceCategory = await _context.Categories.FindAsync(id);
            if (expenceCategory == null)
            {
                return NotFound();
            }
            return View(expenceCategory);
        }

        // POST: ExpenceCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName")] ExpenceCategory expenceCategory)
        {
            if (id != expenceCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenceCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenceCategoryExists(expenceCategory.CategoryId))
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
            return View(expenceCategory);
        }

        // GET: ExpenceCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenceCategory = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (expenceCategory == null)
            {
                return NotFound();
            }

            return View(expenceCategory);
        }

        // POST: ExpenceCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expenceCategory = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(expenceCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenceCategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }
    }
}
