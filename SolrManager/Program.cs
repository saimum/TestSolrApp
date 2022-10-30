using SolrManager.SolrManagers;
using SolrManager.SolrModels;

Console.WriteLine("Hello, World!");

//Add single document
CategoryCore core1 = new CategoryCore();
core1.CategoryName = "C 1";
core1.CategoryId = 1;
var res1 = SolrCategoryManager.Add(core1);
Console.WriteLine("res1=" + res1);


//Add multiple document
var list = new List<CategoryCore>();

CategoryCore core2 = new CategoryCore();
core1.CategoryName = "C 2";
core1.CategoryId = 2;
list.Add(core2);

CategoryCore core3 = new CategoryCore();
core2.CategoryName = "C 3";
core2.CategoryId = 3;
list.Add(core2);
var res2 = SolrCategoryManager.AddRange(list);
Console.WriteLine("res2=" + res2);


Console.ReadKey();
