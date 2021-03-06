//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineBanking.DBModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerInfo
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string StateDetails { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public string Email { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string AccountNumber { get; set; }
        public Nullable<decimal> BalanceAvailable { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }
}
