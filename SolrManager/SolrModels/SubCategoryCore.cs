using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrManager.SolrModels
{
    public class SubCategoryCore
    {
        [SolrUniqueKey("SubCategoryId")]
        public long SubCategoryId { get; set; }
        
        [SolrField("SubCategoryName")]
        public string SubCategoryName { get; set; }
        
        [SolrField("CategoryId")]
        public long CategoryId { get; set; }
    }
}
