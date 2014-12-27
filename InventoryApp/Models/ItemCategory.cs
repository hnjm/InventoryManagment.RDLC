using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryApp.Models
{
    public class ItemCategory
    {

        public int ItemCategoryId { get; set; }
        [Required(ErrorMessage = "Enter  Code")]
        [Remote("CodeExist", "ItemCategory", AdditionalFields = "ItemCategoryId", ErrorMessage = "Item category code is already Exist!, Please enter different code!!")]
        [DisplayName("Code")]
        public string ItemCategoryCode { get; set; }
        [Required(ErrorMessage = "Enter  Item Category Name")]
        [DisplayName("Category Name")]
        public string ItemCategoryName { get; set; }
        public string Remarks { get; set; }
        public virtual ICollection<ItemInformation> ItemInformations { get; set; }
        public virtual ICollection<PriceSetup> PriceSetups{ get; set; }

    }
}