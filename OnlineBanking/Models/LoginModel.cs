using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineBanking.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Please Enter UserName")]
        public string UserID { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }

    }
}