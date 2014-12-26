using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryApp.Models
{
    public class SupplierInformation
    {
        public int SupplierInformationId { get; set; }
        [Required(ErrorMessage = "Enter Client Code")]
        [Remote("CodeExist", "SupplierInformation", AdditionalFields = "SupplierInformationId", ErrorMessage = "Client code is already Exist!, Please enter different code!!")]
        [DisplayName("Supplier Code")]
        public string SupplierCode { get; set; }
        [Required(ErrorMessage = "Enter Client Name")]
        [DisplayName("Supplier Name")]
        [Remote("NameExist", "SupplierInformation", AdditionalFields = "SupplierInformationId", ErrorMessage = "Client name is already Exist!, Please enter different name!!")]
        public string SupplierName { get; set; }
        [Required(ErrorMessage = "Enter Contact Person")]
        [DisplayName("Contact Person")]
        public string ContactPerson { get; set; }
        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        [Remote("EmailExist", "SupplierInformation", AdditionalFields = "SupplierInformationId", ErrorMessage = "This email already Exist. Please enter different email.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Mobile Number")]
        [DisplayName("Mobile Number")]
        [Remote("MobileNumberExist", "SupplierInformation", AdditionalFields = "SupplierInformationId", ErrorMessage = "Contact mobile number is already Exist!, Please enter different mobile number!!")]
        public string MobileNumber { get; set; }
        [DisplayName("Updated Date")]
        public DateTime CreatedDateTime { get; set; }
    }
}