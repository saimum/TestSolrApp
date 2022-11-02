using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using TestSolrApp.SolrResponseModels;
using Microsoft.DotNet.MSIdentity.Shared;

namespace TestSolrApp.Controllers
{
    public class SolrSearchController : Controller
    {
        public async Task<IActionResult> Search(string query)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8983/solr/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                //# Get Product
                List<ProductCoreResponseTemplate.Doc> Products = new List<ProductCoreResponseTemplate.Doc>();
                {
                    HttpResponseMessage response = await client.GetAsync("ProductCore/select?q=" + query + "&rows=5&wt=json&indent=true");
                    if (response.IsSuccessStatusCode)
                    {
                        var responseModel = await response.Content.ReadFromJsonAsync<ProductCoreResponseTemplate.Rootobject>();
                        if (responseModel != null)
                        {
                            Products = responseModel.response.docs;
                        }
                    }
                }

                //# Get Category
                List<CategoryCoreResponseTemplate.Doc> Categories = new List<CategoryCoreResponseTemplate.Doc>();
                {
                    HttpResponseMessage response = await client.GetAsync("CategoryCore/select?q=" + query + "&rows=5&wt=json&indent=true");
                    if (response.IsSuccessStatusCode)
                    {
                        var responseModel = await response.Content.ReadFromJsonAsync<CategoryCoreResponseTemplate.Rootobject>();
                        if (responseModel != null)
                        {
                            Categories = responseModel.response.docs;
                        }
                    }
                }

                return Json(new { success = true, products = Products, categories = Categories });

            }
        }
    }
}
