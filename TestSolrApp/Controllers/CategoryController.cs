using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SolrManager.SolrManagers;
using SolrManager.SolrModels;
using TestSolrApp.DBModels;

namespace TestSolrApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly TestSolrAppContext _context;

        public CategoryController(TestSolrAppContext context)
        {
            _context = context;
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoryTable.ToListAsync());
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.CategoryTable == null)
            {
                return NotFound();
            }

            var categoryTable = await _context.CategoryTable
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (categoryTable == null)
            {
                return NotFound();
            }

            return View(categoryTable);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,UpdatedAt")] CategoryTable categoryTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryTable);
                await _context.SaveChangesAsync();
                SolrCategoryManager.Add(new CategoryCore
                {
                    CategoryId = categoryTable.CategoryId,
                    CategoryName = categoryTable.CategoryName,
                });
                return RedirectToAction(nameof(Index));
            }
            return View(categoryTable);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.CategoryTable == null)
            {
                return NotFound();
            }

            var categoryTable = await _context.CategoryTable.FindAsync(id);
            if (categoryTable == null)
            {
                return NotFound();
            }
            return View(categoryTable);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("CategoryId,CategoryName,UpdatedAt")] CategoryTable categoryTable)
        {
            if (id != categoryTable.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryTable);
                    await _context.SaveChangesAsync();
                    SolrCategoryManager.Add(new CategoryCore
                    {
                        CategoryId = categoryTable.CategoryId,
                        CategoryName = categoryTable.CategoryName,
                    });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryTableExists(categoryTable.CategoryId))
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
            return View(categoryTable);
        }

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.CategoryTable == null)
            {
                return NotFound();
            }

            var categoryTable = await _context.CategoryTable
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (categoryTable == null)
            {
                return NotFound();
            }

            return View(categoryTable);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.CategoryTable == null)
            {
                return Problem("Entity set 'TestSolrAppContext.CategoryTable'  is null.");
            }
            var categoryTable = await _context.CategoryTable.FindAsync(id);
            if (categoryTable != null)
            {
                _context.CategoryTable.Remove(categoryTable);
                SolrCategoryManager.Remove(new CategoryCore
                {
                    CategoryId = categoryTable.CategoryId,
                    CategoryName = categoryTable.CategoryName,
                });
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryTableExists(long id)
        {
            return _context.CategoryTable.Any(e => e.CategoryId == id);
        }
    }
}
