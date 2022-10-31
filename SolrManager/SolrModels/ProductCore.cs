using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrManager.SolrModels
{
    public class ProductCore
    {
        [SolrUniqueKey("Id")]
        public int Id { get; set; }

        [SolrField("Name")]
        public string Name { get; set; }

        //public bool Deleted { get; set; }
        //public DateTime UpdatedOnUtc { get; set; }
    }
}
