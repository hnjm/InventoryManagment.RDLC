using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InventoryApp.Models
{
    public class ItemType
    {
        public int ItemTypeId { get; set; }
        [DisplayName("Item Type")]
        public string ItemName { get; set; }
        public virtual ICollection<ItemInformation> ItemInformations { get; set; }
    }
}