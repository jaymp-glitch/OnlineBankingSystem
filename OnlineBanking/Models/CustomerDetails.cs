using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace OnlineBanking.Models
{
    public class CustomerDetailsModel
    {
        [Required]
        [Display(Name = "User ID")]
        public string UserID { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }
        [Required]
        public string AddressLine { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Pincode { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PrimaryPhoneNumber { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Status { get; set; }
        // public string SuccessMessage { get; set; }
        [Required]
        [Display(Name = "Set Account Balance")]
        public string BalanceAvailable { get; set; }

    }
}