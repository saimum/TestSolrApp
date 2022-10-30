using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrManager.SolrModels
{
    public class CategoryCore
    {
        [SolrUniqueKey("CategoryId")]
        public long CategoryId { get; set; }
        
        [SolrField("CategoryName")]
        public string CategoryName { get; set; }
    }
}
