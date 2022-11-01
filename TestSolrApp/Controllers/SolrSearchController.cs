using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Microsoft.AspNetCore.Mvc;

namespace TestSolrApp.Controllers
{
    public class SolrSearchController : Controller
    {
        //public IActionResult Search(string query)
        //{
        //    RestClient client = new RestClient("http://localhost:8983");
        //    RestRequest request = new RestRequest("/solr/coursesdemo/select");
        //    request.AddParameter("wt", "json");
        //    request.AddParameter("q", query);
        //    request.AddParameter("indent", "true");

        //    IRestResponse queryResult = client.Execute(request);

        //    PrintOut(queryResult.Content.ToString());
        //}
    }
}
