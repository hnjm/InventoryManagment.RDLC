using System.Collections.Generic;
using InventoryApp.Models;

namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InventoryApp.Models.ProjectDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InventoryApp.Models.ProjectDb context)
        {
            //var clientinformations = new List<ClientInformation>
            //{              
            // new ClientInformation{Address = "Uttar-Badda, Dhaka",ClientCode = "C-001",ClientName = "Bellal Group",ContactPerson = "Bellal",Email = "bellal@gmail.com",MobileNumber = "01795452524",CreatedDateTime = DateTime.UtcNow},
            //  new ClientInformation{Address = "Mokbazzar, Dhaka",ClientCode = "C-002",ClientName = "Kamal Group",ContactPerson = "Kamal",Email = "kamal@gmail.com",MobileNumber = "01762554422",CreatedDateTime = DateTime.UtcNow},
            //   new ClientInformation{Address = "Mirpur, Dhaka",ClientCode = "C-003",ClientName = "Jamal Group",ContactPerson = "Jamal",Email = "jamal@gmail.com",MobileNumber = "01777552244",CreatedDateTime = DateTime.UtcNow}
            //};
            //clientinformations.ForEach(s => context.ClientInformations.AddOrUpdate(s));
            //context.SaveChanges();
            //var supplierInformations = new List<SupplierInformation>
            //{              
            // new SupplierInformation{Address = "Moddo-Badda, Dhaka",SupplierCode = "S-001",SupplierName = "Amin Group",ContactPerson = "Amin",Email = "bellal@gmail.com",MobileNumber = "01795452524",CreatedDateTime = DateTime.UtcNow},
            //  new SupplierInformation{Address = "Malibag, Dhaka",SupplierCode = "S-002",SupplierName = "Korim Group",ContactPerson = "Korim",Email = "kamal@gmail.com",MobileNumber = "01762554422",CreatedDateTime = DateTime.UtcNow},
            //   new SupplierInformation{Address = "Aminbazzar, Dhaka",SupplierCode = "S-003",SupplierName = "Hamid Group",ContactPerson = "Hamid",Email = "jamal@gmail.com",MobileNumber = "01777552244",CreatedDateTime = DateTime.UtcNow}
            //};
            //supplierInformations.ForEach(s => context.SupplierInformations.AddOrUpdate(s));
            //context.SaveChanges();
            //var itemCategorys = new List<ItemCategory>
            //{              
            // new ItemCategory{ItemCategoryCode = "001",ItemCategoryName = "Soft Drink",Remarks = "5pak/Box"},
            // new ItemCategory{ItemCategoryCode = "002",ItemCategoryName = "Pen",Remarks = "12p/Box"},
            // new ItemCategory{ItemCategoryCode = "003",ItemCategoryName = "Others",Remarks = "10box"}
             
            //};
            //itemCategorys.ForEach(s => context.ItemCategories.AddOrUpdate(s));
            //context.SaveChanges();
            //var itemInformations = new List<ItemInformation>
            //{              
            // new ItemInformation{ItemCode = "I01",ItemName = "Coca-Cola",Remarks = "5Pcs",ItemCategoryId = 1},
            // new ItemInformation{ItemCode = "I02",ItemName = "Nickon Pen",Remarks = "12pcs",ItemCategoryId = 2},
            // new ItemInformation{ItemCode = "I03",ItemName = "Iphone4",Remarks = "2pcs",ItemCategoryId = 3}

            //};
            //itemInformations.ForEach(s => context.ItemInformations.AddOrUpdate(s));
            //context.SaveChanges();
            //var uoms = new List<Uom>
            //{              
            // new Uom{UomName= "Pcs"},
            // new Uom{UomName = "Carton"},
            // new Uom{UomName = "Box"},
            // new Uom{UomName = "Kg"},
            // new Uom{UomName= "Mtr"},
            // new Uom{UomName = "Ft"},
            // new Uom{UomName = "Inch"},
            // new Uom{UomName = "SqInch"},
            // new Uom{UomName= "Sqft"},
            // new Uom{UomName = "SqMtr"},
      

            //};
            //uoms.ForEach(s => context.Uoms.AddOrUpdate(s));
            //context.SaveChanges();

            var itemInformations = new List<ItemInformation>
            {              
             new ItemInformation{ItemCode = "I01",ItemName = "Coca-Cola",Remarks = "5Pcs",ItemCategoryId = 1,ItemTypeId = 1,UomId = 1},
             new ItemInformation{ItemCode = "I02",ItemName = "Nickon Pen",Remarks = "12pcs",ItemCategoryId = 2,ItemTypeId = 2,UomId = 2},
             new ItemInformation{ItemCode = "I03",ItemName = "Iphone4",Remarks = "2pcs",ItemCategoryId = 3,ItemTypeId = 3,UomId = 3}

            };
            itemInformations.ForEach(s => context.ItemInformations.AddOrUpdate(s));
            context.SaveChanges();

        }
    }
}
