using SolrManager.SolrManagers;
using SolrManager.SolrModels;

Console.WriteLine("Hello, World!");
 var list = new List<CategoryCore>();

CategoryCore core1 = new CategoryCore();
core1.CategoryName = "C 1";
core1.CategoryId = 1;
list.Add(core1);


CategoryCore core2 = new CategoryCore();
core2.CategoryName = "C 2";
core2.CategoryId = 2;
list.Add(core2);



//var res = SolrCategoryManager.Add(core);
var res = SolrCategoryManager.AddRange(list);
Console.WriteLine(res);
Console.ReadKey();
