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
    public static class SolrItemManager
    {
        public static string Add(ItemCore core)
        {
            var res = "";
            try
            {
                Startup.Init<ItemCore>("http://localhost:8983/solr/ItemCore");
                ISolrOperations<ItemCore> solr = ServiceLocator.Current.GetInstance<ISolrOperations<ItemCore>>();
                solr.Add(core);
                res = solr.Commit().ToString();
            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }
        public static string AddRange(List<ItemCore> cores)
        {
            var res = "";
            try
            {
                Startup.Init<ItemCore>("http://localhost:8983/solr/ItemCore");
                ISolrOperations<ItemCore> solr = ServiceLocator.Current.GetInstance<ISolrOperations<ItemCore>>();
                solr.AddRange(cores);
                res = solr.Commit().ToString();
            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }

        public static string Remove(ItemCore core)
        {
            var res = "";
            try
            {
                Startup.Init<ItemCore>("http://localhost:8983/solr/ItemCore");
                ISolrOperations<ItemCore> solr = ServiceLocator.Current.GetInstance<ISolrOperations<ItemCore>>();
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
                var coreName = "ItemCore";
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
