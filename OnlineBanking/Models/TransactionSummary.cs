using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OnlineBanking.DBModel;

namespace OnlineBanking.Models
{
    public class TransactionSummary
    {
        public List<Transaction> TransactDetails { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("From")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("From")]
        public DateTime EndDate { get; set; }
    }
}