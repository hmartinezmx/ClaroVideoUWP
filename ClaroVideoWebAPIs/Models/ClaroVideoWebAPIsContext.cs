using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClaroVideoWebAPIs.Models
{
    public class ClaroVideoWebAPIsContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ClaroVideoWebAPIsContext() : base("name=ClaroVideoWebAPIsContext")
        {
        }


        public System.Data.Entity.DbSet<ClaroVideoWebAPIs.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<ClaroVideoWebAPIs.Models.VCard> VCards { get; set; }

        public System.Data.Entity.DbSet<ClaroVideoWebAPIs.Models.RatingCode> RatingCodes { get; set; }

    }
}
