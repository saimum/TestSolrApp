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
    public static class SolrSubCategoryManager
    {
        public static string Add(SubCategoryCore core)
        {
            var res = "";
            try
            {
                Startup.Init<SubCategoryCore>("http://localhost:8983/solr/SubCategoryCore");
                ISolrOperations<SubCategoryCore> solr = ServiceLocator.Current.GetInstance<ISolrOperations<SubCategoryCore>>();
                solr.Add(core);
                res = solr.Commit().ToString();
            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }
        public static string AddRange(List<SubCategoryCore> cores)
        {
            var res = "";
            try
            {
                Startup.Init<SubCategoryCore>("http://localhost:8983/solr/SubCategoryCore");
                ISolrOperations<SubCategoryCore> solr = ServiceLocator.Current.GetInstance<ISolrOperations<SubCategoryCore>>();
                solr.AddRange(cores);
                res = solr.Commit().ToString();
            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }

        public static string Remove(SubCategoryCore core)
        {
            var res = "";
            try
            {
                Startup.Init<SubCategoryCore>("http://localhost:8983/solr/SubCategoryCore");
                ISolrOperations<SubCategoryCore> solr = ServiceLocator.Current.GetInstance<ISolrOperations<SubCategoryCore>>();
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
                var coreName = "SubCategoryCore";
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
