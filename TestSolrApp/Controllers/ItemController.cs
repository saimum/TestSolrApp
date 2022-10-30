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
    public class ItemController : Controller
    {
        private readonly TestSolrAppContext _context;

        public ItemController(TestSolrAppContext context)
        {
            _context = context;
        }

        // GET: Item
        public async Task<IActionResult> Index()
        {
            var testSolrAppContext = _context.ItemTable.Include(i => i.SubCategory);
            return View(await testSolrAppContext.ToListAsync());
        }

        // GET: Item/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.ItemTable == null)
            {
                return NotFound();
            }

            var itemTable = await _context.ItemTable
                .Include(i => i.SubCategory)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (itemTable == null)
            {
                return NotFound();
            }

            return View(itemTable);
        }

        // GET: Item/Create
        public IActionResult Create()
        {
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategoryTable, "SubCategoryId", "SubCategoryName");
            return View();
        }

        // POST: Item/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemName,SubCategoryId,UpdatedAt")] ItemTable itemTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemTable);
                await _context.SaveChangesAsync();
                SolrItemManager.Add(new ItemCore
                {
                    ItemId = itemTable.ItemId,
                    ItemName = itemTable.ItemName,
                    SubCategoryId = itemTable.SubCategoryId
                });
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategoryTable, "SubCategoryId", "SubCategoryName", itemTable.SubCategoryId);
            return View(itemTable);
        }

        // GET: Item/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.ItemTable == null)
            {
                return NotFound();
            }

            var itemTable = await _context.ItemTable.FindAsync(id);
            if (itemTable == null)
            {
                return NotFound();
            }
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategoryTable, "SubCategoryId", "SubCategoryName", itemTable.SubCategoryId);
            return View(itemTable);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ItemId,ItemName,SubCategoryId,UpdatedAt")] ItemTable itemTable)
        {
            if (id != itemTable.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemTable);
                    await _context.SaveChangesAsync();
                    SolrItemManager.Add(new ItemCore
                    {
                        ItemId = itemTable.ItemId,
                        ItemName = itemTable.ItemName,
                        SubCategoryId = itemTable.SubCategoryId
                    });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemTableExists(itemTable.ItemId))
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
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategoryTable, "SubCategoryId", "SubCategoryName", itemTable.SubCategoryId);
            return View(itemTable);
        }

        // GET: Item/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.ItemTable == null)
            {
                return NotFound();
            }

            var itemTable = await _context.ItemTable
                .Include(i => i.SubCategory)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (itemTable == null)
            {
                return NotFound();
            }

            return View(itemTable);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.ItemTable == null)
            {
                return Problem("Entity set 'TestSolrAppContext.ItemTable'  is null.");
            }
            var itemTable = await _context.ItemTable.FindAsync(id);
            if (itemTable != null)
            {
                _context.ItemTable.Remove(itemTable);
                SolrItemManager.Remove(new ItemCore
                {
                    ItemId = itemTable.ItemId,
                    ItemName = itemTable.ItemName,
                    SubCategoryId = itemTable.SubCategoryId
                });
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemTableExists(long id)
        {
          return _context.ItemTable.Any(e => e.ItemId == id);
        }
    }
}
