﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace TestSolrApp.DBModels
{
    public partial class CategoryTable
    {
        public CategoryTable()
        {
            SubCategoryTable = new HashSet<SubCategoryTable>();
        }

        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<SubCategoryTable> SubCategoryTable { get; set; }
    }
}