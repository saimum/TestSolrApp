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
    public static class SolrCategoryManager
    {
        public static string Add(CategoryCore core)
        {
            var res = "";
            try
            {
                Startup.Init<CategoryCore>("http://localhost:8983/solr/CategoryCore");
                ISolrOperations<CategoryCore> solr = ServiceLocator.Current.GetInstance<ISolrOperations<CategoryCore>>();
                solr.Add(core);
                res = solr.Commit().ToString();
            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }
        public static string AddRange(List<CategoryCore> cores)
        {
            var res = "";
            try
            {
                Startup.Init<CategoryCore>("http://localhost:8983/solr/CategoryCore");
                ISolrOperations<CategoryCore> solr = ServiceLocator.Current.GetInstance<ISolrOperations<CategoryCore>>();
                solr.AddRange(cores);
                res = solr.Commit().ToString();
            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }

        public static string Remove(CategoryCore core)
        {
            var res = "";
            try
            {
                Startup.Init<CategoryCore>("http://localhost:8983/solr/CategoryCore");
                ISolrOperations<CategoryCore> solr = ServiceLocator.Current.GetInstance<ISolrOperations<CategoryCore>>();
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
                var coreName = "CategoryCore";
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
