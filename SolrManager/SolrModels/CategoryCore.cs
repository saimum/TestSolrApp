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
        [SolrUniqueKey("Id")]
        public long Id { get; set; }
        
        [SolrField("Name")]
        public string Name { get; set; }
    }
}
