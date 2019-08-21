using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MvcPosApp.Models.Models;

namespace MvcPossAppDatabseContext.DatabaseContext
{
    public class DatabaseContext: DbContext
    {
        public DbSet<CustomerModel> CustomerModels { set; get; }
        public DbSet<Sale> Sales { set; get; }
        public DbSet<SalesDetails> SalesDetails { set; get; }
    }
}