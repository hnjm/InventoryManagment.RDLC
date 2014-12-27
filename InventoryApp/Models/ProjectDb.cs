using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InventoryApp.Models
{
   
        public class ProjectDb : DbContext
        {
            public ProjectDb(): base("inventoryProject")
            {
            }

            public DbSet<ClientInformation> ClientInformations { get; set; }
            public DbSet<SupplierInformation> SupplierInformations { get; set; }
            public DbSet<ItemCategory> ItemCategories { get; set; }
            public DbSet<ItemInformation> ItemInformations { get; set; }
            public DbSet<ItemType> ItemTypes { get; set; }
            public DbSet<Uom> Uoms { get; set; }
            public DbSet<PriceSetup> PriceSetups { get; set; }
        }
    
}