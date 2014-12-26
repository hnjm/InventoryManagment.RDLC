using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;

namespace InventoryApp.Models
{
    public class Uom
    {
        public int UomId { get; set; }
        [DisplayName("UOM")]
        public string UomName { get; set; }
        public virtual ICollection<ItemInformation> ItemInformations { get; set; }
    }
}