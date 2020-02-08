using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBanking.Models
{
    public class ChangePassword
    {
            public string UserID { get; set; }
            public string CurrentPassword { get; set; }
            public string NewPassword { get; set; }
        
    }
}