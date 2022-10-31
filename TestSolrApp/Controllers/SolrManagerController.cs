using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolrManager.SolrManagers;
using SolrManager.SolrModels;
using TestSolrApp.DBModels;

namespace TestSolrApp.Controllers
{
    public class SolrManagerController : Controller
    {
        private readonly TestSolrAppContext _context;
        public SolrManagerController(TestSolrAppContext context)
        {
            _context = context;
        }
        public IActionResult SyncAllUpdatedTables()
        {
            var dateTimeLowerLimit = DateTime.Now.AddMinutes(-5);

            var categoryTables = _context.CategoryTable.Where(a => a.UpdatedAt > dateTimeLowerLimit).ToList();
            List<CategoryCore> categoryCores = new List<CategoryCore>();
            foreach (var categoryTable in categoryTables)
            {
                categoryCores.Add(new CategoryCore {
                    CategoryId = categoryTable.CategoryId,
                    CategoryName = categoryTable.CategoryName,
                });
            }
            SolrCategoryManager.AddRange(categoryCores);

            var subCategoryTables = _context.SubCategoryTable.Where(a => a.UpdatedAt > dateTimeLowerLimit).ToList();
            List<SubCategoryCore> subCategoryCores = new List<SubCategoryCore>();
            foreach (var subCategoryTable in subCategoryTables)
            {
                subCategoryCores.Add(new SubCategoryCore
                {
                    SubCategoryId = subCategoryTable.SubCategoryId,
                    SubCategoryName = subCategoryTable.SubCategoryName,
                    CategoryId = subCategoryTable.CategoryId
                });
            }
            SolrSubCategoryManager.AddRange(subCategoryCores);

            var itemTables = _context.ItemTable.Where(a => a.UpdatedAt > dateTimeLowerLimit).ToList();
            List<ItemCore> itemCores = new List<ItemCore>();
            foreach (var itemTable in itemTables)
            {
                itemCores.Add(new ItemCore
                {
                    ItemId = itemTable.ItemId,
                    ItemName = itemTable.ItemName,
                });
            }
            SolrItemManager.AddRange(itemCores);

            return View();
        }
    }
}
