﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBanking.Models
{
    public class FundTransfer
    {
        public string UserID { get; set; }
        public string ToAccount { get; set; }
        public string Summary { get; set; }
        public Nullable<decimal> TransAmount { get; set; }

    }
}