﻿using Newtonsoft.Json;
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
                List<ProductCoreResponseTemplate.Doc> products = new List<ProductCoreResponseTemplate.Doc>();
                {
                    HttpResponseMessage response = await client.GetAsync("ProductCore/select?q=*:*&rows=5&wt=json&indent=true");
                    if (response.IsSuccessStatusCode)
                    {
                        var responseModel = await response.Content.ReadFromJsonAsync<ProductCoreResponseTemplate.Rootobject>();
                        if (responseModel != null)
                        {
                            products = responseModel.response.docs;
                        }
                    }
                }

                //# Get Category
                List<CategoryCoreResponseTemplate.Doc> categories = new List<CategoryCoreResponseTemplate.Doc>();
                {
                    HttpResponseMessage response = await client.GetAsync("CategoryCore/select?q=*:*&rows=5&wt=json&indent=true");
                    if (response.IsSuccessStatusCode)
                    {
                        var responseModel = await response.Content.ReadFromJsonAsync<CategoryCoreResponseTemplate.Rootobject>();
                        if (responseModel != null)
                        {
                            categories = responseModel.response.docs;
                        }
                    }
                }

                return Json(new { success = true, products = products, categories = categories });

            }
        }

        public async Task MainAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:6740");
                var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("", "login")
            });
                var result = await client.PostAsync("/api/Membership/exists", content);
                string resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
            }
        }
    }
}
