using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrManager.SolrModels
{
    public class ItemCore
    {
        [SolrUniqueKey("ItemId")]
        public long ItemId { get; set; }
        
        [SolrField("ItemName")]
        public string ItemName { get; set; }

        [SolrField("SubCategoryId")]
        public long SubCategoryId { get; set; }
    }
}
