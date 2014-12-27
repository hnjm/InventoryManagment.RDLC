using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryApp.Models
{
    public class ItemInformation
    {
        public int ItemInformationId { get; set; }
        [Required(ErrorMessage = "Enter  Code")]
        [Remote("CodeExist", "ItemInformation", AdditionalFields = "ItemInformationId", ErrorMessage = "Item category code is already Exist!, Please enter different code!!")]
        [DisplayName("Item Code")]
        public string ItemCode { get; set; }
        [Required(ErrorMessage = "Enter  Item Category Name")]
        [DisplayName("Item Name")]
        public string ItemName { get; set; }
         [Required(ErrorMessage = "Please select one ctegory of items")]
        public int ItemCategoryId { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }
        [Required(ErrorMessage = "Please select one type of items")]
        public int ItemTypeId { get; set; }
        public virtual ItemType ItemType { get; set; }

        [Required(ErrorMessage = "Please select one kind of UOMs")]
        public int UomId { get; set; }
        public virtual Uom Uom { get; set; }
        public string Remarks { get; set; }
        public virtual ICollection<PriceSetup> PriceSetups { get; set; }

    }
}