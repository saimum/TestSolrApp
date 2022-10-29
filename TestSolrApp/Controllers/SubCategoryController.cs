using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestSolrApp.DBModels;

namespace TestSolrApp.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly TestSolrAppContext _context;

        public SubCategoryController(TestSolrAppContext context)
        {
            _context = context;
        }

        // GET: SubCategory
        public async Task<IActionResult> Index()
        {
            var testSolrAppContext = _context.SubCategoryTable.Include(s => s.Category);
            return View(await testSolrAppContext.ToListAsync());
        }

        // GET: SubCategory/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.SubCategoryTable == null)
            {
                return NotFound();
            }

            var subCategoryTable = await _context.SubCategoryTable
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.SubCategoryId == id);
            if (subCategoryTable == null)
            {
                return NotFound();
            }

            return View(subCategoryTable);
        }

        // GET: SubCategory/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.CategoryTable, "CategoryId", "CategoryName");
            return View();
        }

        // POST: SubCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubCategoryId,SubCategoryName,CategoryId,UpdatedAt")] SubCategoryTable subCategoryTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subCategoryTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.CategoryTable, "CategoryId", "CategoryName", subCategoryTable.CategoryId);
            return View(subCategoryTable);
        }

        // GET: SubCategory/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.SubCategoryTable == null)
            {
                return NotFound();
            }

            var subCategoryTable = await _context.SubCategoryTable.FindAsync(id);
            if (subCategoryTable == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.CategoryTable, "CategoryId", "CategoryName", subCategoryTable.CategoryId);
            return View(subCategoryTable);
        }

        // POST: SubCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("SubCategoryId,SubCategoryName,CategoryId,UpdatedAt")] SubCategoryTable subCategoryTable)
        {
            if (id != subCategoryTable.SubCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subCategoryTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubCategoryTableExists(subCategoryTable.SubCategoryId))
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
            ViewData["CategoryId"] = new SelectList(_context.CategoryTable, "CategoryId", "CategoryName", subCategoryTable.CategoryId);
            return View(subCategoryTable);
        }

        // GET: SubCategory/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.SubCategoryTable == null)
            {
                return NotFound();
            }

            var subCategoryTable = await _context.SubCategoryTable
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.SubCategoryId == id);
            if (subCategoryTable == null)
            {
                return NotFound();
            }

            return View(subCategoryTable);
        }

        // POST: SubCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.SubCategoryTable == null)
            {
                return Problem("Entity set 'TestSolrAppContext.SubCategoryTable'  is null.");
            }
            var subCategoryTable = await _context.SubCategoryTable.FindAsync(id);
            if (subCategoryTable != null)
            {
                _context.SubCategoryTable.Remove(subCategoryTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubCategoryTableExists(long id)
        {
          return _context.SubCategoryTable.Any(e => e.SubCategoryId == id);
        }
    }
}
