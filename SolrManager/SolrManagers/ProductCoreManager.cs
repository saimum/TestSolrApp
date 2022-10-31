using Microsoft.Practices.ServiceLocation;
using SolrManager.SolrModels;
using SolrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SolrManager.SolrManagers
{
    public static class ProductCoreManager
    {
        public static string Add(ProductCore core)
        {
            var res = "";
            try
            {
                Startup.Init<ProductCore>("http://localhost:8983/solr/ProductCore");
                ISolrOperations<ProductCore> solr = ServiceLocator.Current.GetInstance<ISolrOperations<ProductCore>>();
                solr.Add(core);
                res = solr.Commit().ToString();
            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }
        public static string AddRange(List<ProductCore> cores)
        {
            var res = "";
            try
            {
                Startup.Init<ProductCore>("http://localhost:8983/solr/ProductCore");
                ISolrOperations<ProductCore> solr = ServiceLocator.Current.GetInstance<ISolrOperations<ProductCore>>();
                solr.AddRange(cores);
                res = solr.Commit().ToString();
            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }

        public static string Remove(ProductCore core)
        {
            var res = "";
            try
            {
                Startup.Init<ProductCore>("http://localhost:8983/solr/ProductCore");
                ISolrOperations<ProductCore> solr = ServiceLocator.Current.GetInstance<ISolrOperations<ProductCore>>();
                solr.Delete(core);
                res = solr.Commit().ToString();
            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }

        public static string RemoveAll()
        {
            var res = "";
            try
            {
                var coreName = "ProductCore";
                var url = @"http://localhost:8983/solr/" + coreName + @"/update?stream.body=<delete><query>*:*</query></delete>&commit=true";
                res = new WebClient().DownloadString(url);
            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }
    }
}
