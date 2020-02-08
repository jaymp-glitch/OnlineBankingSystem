using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBanking.Models
{
    public class Account
    {
        public class TransactionDetails
        {
            public string TransactionDate { get; set; }
            public string TransactionType { get; set; }
            public string ReferenceNumber { get; set; }
            public string Withdrawal { get; set; }
            public string Deposit { get; set; }
            public string ClosingBalance { get; set; }
        }
        public class AccountGeneralDetails
        {
            public string AccountNumber { get; set; }
            public string AccountType { get; set; }
            public string AvailableAmount { get; set; }
            public TransactionDetails Transactions { get; set; }
        }
    }
}