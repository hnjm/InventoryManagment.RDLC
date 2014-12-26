using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace InventoryApp.Models
{
    public class ClientInformation
    {
        public int ClientInformationId { get; set; }
        [Required(ErrorMessage = "Enter Client Code")]
        [Remote("ClientCodeExist", "ClientInformation", AdditionalFields = "ClientInformationId", ErrorMessage = "Client code is already Exist!, Please enter different name!!")]
        [DisplayName("Client Code")]
        public string ClientCode { get; set; }
        [Required(ErrorMessage = "Enter Client Name")]
        [DisplayName("Client Name")]
        [Remote("ClientNameExist", "ClientInformation", AdditionalFields = "ClientInformationId", ErrorMessage = "Client name is already Exist!, Please enter different name!!")]
        public string ClientName { get; set; }
        [Required(ErrorMessage = "Enter Contact Person")]
        [DisplayName("Contact Person")]
        public string ContactPerson { get; set; }
        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        [Remote("EmailExist", "ClientInformation", AdditionalFields = "ClientInformationId", ErrorMessage = "This email already Exist. Please enter different email.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Mobile Number")]
        [DisplayName("Mobile Number")]
        [Remote("MobileNumberExist", "ClientInformation", AdditionalFields = "ClientInformationId", ErrorMessage = "Contact mobile number is already Exist!, Please enter different mobile number!!")]
        public string MobileNumber { get; set; }
          [DisplayName("Created Date")]
        public DateTime CreatedDateTime { get; set; }
    }
}