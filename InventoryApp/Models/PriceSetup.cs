using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryApp.Models
{
    public class PriceSetup
    {
        public int PriceSetupId { get; set; }
        [Required(ErrorMessage = "Please select one ctegory of items")]
        public int ItemCategoryId { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }
        [Required(ErrorMessage = "Please select one item")]
        public int ItemInformationId { get; set; }
        public virtual ItemInformation ItemInformation { get; set; }
        [DisplayName("Unit Price")]
        [Required(ErrorMessage = "Please put unit price")]
        public double UnitPrice { get; set; }
         [Required(ErrorMessage = "Please put vat price")]
        public double Vat { set; get; }
        [DisplayName("Vat Price")]
        public double VatPrice { get; set; }
    }
}