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

            //var categoryTables = _context.Category.Where(a => a.UpdatedOnUtc > dateTimeLowerLimit).ToList();
            var categoryTables = _context.Category.ToList();
            List<CategoryCore> categoryCores = new List<CategoryCore>();
            foreach (var Category in categoryTables)
            {
                categoryCores.Add(new CategoryCore {
                    Id = Category.Id,
                    Name = Category.Name,
                });
            }
            CategoryCoreManager.AddRange(categoryCores);


            //var productTables = _context.Product.Where(a => a.UpdatedOnUtc > dateTimeLowerLimit).ToList();
            var productTables = _context.Product.ToList();
            List<ProductCore> productCores = new List<ProductCore>();
            foreach (var productTable in productTables)
            {
                productCores.Add(new ProductCore
                {
                    Id = productTable.Id,
                    Name = productTable.Name,
                });
            }
            ProductCoreManager.AddRange(productCores);

            return View();
        }
    }
}
