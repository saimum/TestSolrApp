using SolrManager.SolrManagers;
using SolrManager.SolrModels;
using SolrNet.Impl;

Console.WriteLine("Bismillah");

//////Add single document
//CategoryCore core1 = new CategoryCore();
//core1.CategoryName = "C 1";
//core1.CategoryId = 1;
//var res1 = SolrCategoryManager.Add(core1);
//Console.WriteLine("res1=" + res1);


//////Add multiple document
//var list = new List<CategoryCore>();

//CategoryCore core2 = new CategoryCore();
//core2.CategoryName = "C 2";
//core2.CategoryId = 2;
//list.Add(core2);

//CategoryCore core3 = new CategoryCore();
//core3.CategoryName = "C 3";
//core3.CategoryId = 3;
//list.Add(core3);
//var res2 = SolrCategoryManager.AddRange(list);
//Console.WriteLine("res2=" + res2);


//////Delete a document
//CategoryCore deleteCore = new CategoryCore() {CategoryId= 1 };
//SolrCategoryManager.Remove(deleteCore);

////Delete all document
SolrCategoryManager.RemoveAll();


Console.ReadKey();
