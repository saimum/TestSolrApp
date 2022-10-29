using Microsoft.AspNetCore.Mvc;
using TestSolrApp.DBModels;

namespace TestSolrApp.Controllers
{
    public class DBController : Controller
    {
        TestSolrAppContext db;
        public DBController()
        {
            db = new TestSolrAppContext();
        }
        public IActionResult CategorySynch()
        {
            var list = db.CategoryTable.ToList();
            return View();
        }
    }
}
