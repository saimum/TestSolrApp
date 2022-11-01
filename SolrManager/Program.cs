using SolrManager.SolrManagers;
using SolrManager.SolrModels;
using SolrNet.Impl;

Console.WriteLine("Bismillah");

//////Add single document
//CategoryCore core1 = new CategoryCore();
//core1.Name = "C 1";
//core1.Id = 1;
//var res1 = CategoryCoreManager.Add(core1);
//Console.WriteLine("res1=" + res1);


//////Add multiple document
//var list = new List<CategoryCore>();

//CategoryCore core2 = new CategoryCore();
//core2.Name = "C 2";
//core2.Id = 2;
//list.Add(core2);

//CategoryCore core3 = new CategoryCore();
//core3.Name = "C 3";
//core3.Id = 3;
//list.Add(core3);
//var res2 = CategoryCoreManager.AddRange(list);
//Console.WriteLine("res2=" + res2);


//////Delete a document
//CategoryCore deleteCore = new CategoryCore() { Id = 1 };
//CategoryCoreManager.Remove(deleteCore);

//Delete all document
//ProductCoreManager.RemoveAll();


Console.ReadKey();
