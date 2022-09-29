using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices;
using TestSolrApp.Models;

namespace TestSolrApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetSeachedData(string keyword)
        {
            var list = new List<SearchResultModel>();


            list.Add(new SearchResultModel() { ResultType = "Division", ResultTitle = "Barishal" });
            list.Add(new SearchResultModel() { ResultType = "Division", ResultTitle = "Chattogram" });
            list.Add(new SearchResultModel() { ResultType = "Division", ResultTitle = "Dhaka" });
            list.Add(new SearchResultModel() { ResultType = "Division", ResultTitle = "Khulna" });
            list.Add(new SearchResultModel() { ResultType = "Division", ResultTitle = "Mymensingh" });
            list.Add(new SearchResultModel() { ResultType = "Division", ResultTitle = "Rajshahi" });
            list.Add(new SearchResultModel() { ResultType = "Division", ResultTitle = "Rangpur" });
            list.Add(new SearchResultModel() { ResultType = "Division", ResultTitle = "Sylhet" });

            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Bagerhat" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Bandarban" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Barguna" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Barisal" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Bhola" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Bogra" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Brahmanbaria" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Chandpur" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "ChapaiNawabganj" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Chittagong" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Chuadanga" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Comilla" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Cox'sBazar" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Dhaka" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Dinajpur" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Faridpur" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Feni" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Gaibandha" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Gazipur" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Gopalganj" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Habiganj" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Jamalpur" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Jessore" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Jhalokati" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Jhenaidah" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Joypurhat" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Khagrachhari" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Khulna" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Kishoreganj" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Kurigram" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Kushtia" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Lakshmipur" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Lalmonirhat" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Madaripur" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Magura" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Manikganj" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Meherpur" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Moulvibazar" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Munshiganj" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Mymensingh" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Naogaon" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Narail" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Narayanganj" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Narsingdi" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Natore" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Netrokona" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Nilphamari" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Noakhali" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Pabna" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Panchagarh" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Patuakhali" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Pirojpur" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Rajbari" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Rajshahi" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Rangamati" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Rangpur" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Satkhira" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Shariatpur" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Sherpur" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Sirajganj" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Sunamganj" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Sylhet" });
            list.Add(new SearchResultModel() { ResultType = "District", ResultTitle = "Tangail" });

            return Json(list);
        }

        class SearchResultModel
        {
            public string ResultType { get; set; }
            public string ResultTitle { get; set; }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}