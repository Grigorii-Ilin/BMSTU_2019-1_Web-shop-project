using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public class AutoContext: DbContext
    {
        
        
            public DbSet<AutoRoutePart> AutoRouteParts { get; set; }

    }
}