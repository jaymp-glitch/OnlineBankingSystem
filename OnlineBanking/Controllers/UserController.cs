using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using OnlineBanking.DBModel;
using OnlineBanking.Models;

namespace OnlineBanking.Controllers
{
    public class UserController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)

        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;

            Controller controller = filterContext.Controller as Controller;

            if (session == null)
            {
                ViewBag.updateAccountMessage = "Session Expired";

                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new

                {

                    controller = "Account",

                    action = "Login"

                }));
            }
            else if (session != null && (session["UserType"].ToString())!="Customer")

            {

                ViewBag.updateAccountMessage = "Session Expired";

                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new

                {

                    controller = "Account",

                    action = "Login"

                }));

            }



            base.OnActionExecuting(filterContext);

        }
        // GET: UserHome
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserHomePage()
        {
             string userId = Session["UserID"].ToString();
            //string userId = "TestCust1";

            OnlineBankingEntities onlineBankingEntities = new OnlineBankingEntities();
            var accnt = (from a in onlineBankingEntities.AccountDetails
                         where a.UserID == userId
                         select a).First();
            return View(accnt);
        }
        public ActionResult RecentTransaction()
        {
             string userId = Session["UserID"].ToString();
          //  userId = userId == null ? "TestCust1" : userId;

            OnlineBankingEntities onlineBankingEntities = new OnlineBankingEntities();

            List<Transaction> transactionlist = new List<Transaction>();
            var trans = (from a in onlineBankingEntities.Transactions
                         orderby a.ValueDate descending
                         where a.UserID == userId
                         select a).Take(5);
            foreach (var item in trans)
            {
                Transaction transaction = new Transaction();
                transaction.TransactionID = item.TransactionID;
                transaction.Narration = item.Narration;
                transaction.ValueDate = item.ValueDate;
                transaction.InitialBalance = item.InitialBalance;
                transaction.Withdrawal = item.Withdrawal;
                transaction.Deposit = item.Deposit;
                transaction.ClosingBalance = item.ClosingBalance;
                transactionlist.Add(transaction);
            }
            return View(transactionlist);
        }
        public ActionResult CustomTransaction()
        {
            return View();
        }
        //okay here comes easy codes... 
        [HttpPost]
        public ActionResult GetTransactionSummary(TransactionSummary t)
        {

            var selectedStartDate = t.StartDate;
            var selectedEndDate = t.EndDate;
            OnlineBankingEntities Context = new OnlineBankingEntities();
            List<Transaction> transactionlist = new List<Transaction>();
            var r = Session["UserID"];

        
                var details = (from e in Context.Transactions
                               where e.UserID == r.ToString() &&
                                        (e.ValueDate >= selectedStartDate.Date && e.ValueDate <= selectedEndDate)
                               select e).ToList();
                foreach (var data in details)
                {
                    Transaction trans = new Transaction();
                    trans.TransactionID = data.TransactionID;
                    trans.Narration = data.Narration;
                    trans.ValueDate = data.ValueDate;
                    trans.InitialBalance = data.InitialBalance;
                    trans.Withdrawal = data.Withdrawal;
                    trans.Deposit = data.Deposit;
                    trans.ClosingBalance = data.ClosingBalance;
                    transactionlist.Add(trans);
                }
            return View(transactionlist);

        }
        //N code
        public ActionResult FundTransfer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FundTransfer(FundTransfer fund)
        {
            OnlineBankingEntities Context = new OnlineBankingEntities();
            var r = Session["UserID"];
            var accountDetails = (from e in Context.AccountDetails
                                 where e.UserID == r.ToString()
                                 select e).First();
            var customerInfo= (from e in Context.CustomerInfo
                                       where e.UserID == r.ToString()
                                       select e).First();
            var currentbalance = accountDetails.BalanceAvailable;
            if (fund.TransAmount >= 100)
            {
                Transaction t1 = new Transaction();
                if (accountDetails.BalanceAvailable >= fund.TransAmount)
                {
                    t1.UserID = fund.UserID;
                    t1.ValueDate = DateTime.Now;
                    t1.Narration = "Fund Transfer";
                    t1.InitialBalance = currentbalance;
                    t1.Withdrawal = fund.TransAmount; 
                    t1.ClosingBalance = currentbalance - fund.TransAmount;
                    t1.FundTransferToAccount = fund.ToAccount;
                    accountDetails.BalanceAvailable = t1.ClosingBalance;
                    customerInfo.BalanceAvailable = t1.ClosingBalance;
                    Context.Transactions.Add(t1);
                    Context.SaveChanges();
                    ViewBag.Message = "Current Balance is " + t1.ClosingBalance + " in your account ";
                }
                else
                {
                    ViewBag.Message = "Insufficient Balance";
                }
            }
            else
            {
                ViewBag.Message = "Minimum value is above 100";
            }
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePassword c)
        {
            try
            {
                if (c.CurrentPassword != null && c.NewPassword != null)
                {

                    var r = Session["UserID"];
                    if (c.UserID == r.ToString())
                    {

                        OnlineBankingEntities db = new OnlineBankingEntities();

                        var item = (from LoginInfo in db.LoginInfo
                                    where (LoginInfo.UserID == c.UserID && LoginInfo.Password == c.CurrentPassword)
                                    select LoginInfo).First();
                        var customerInfo = (from e in db.CustomerInfo
                                            where e.UserID == r.ToString()
                                            select e).First();
                        if (item != null)
                        {
                            item.Password = c.NewPassword;
                            customerInfo.Password = c.NewPassword;

                            db.SaveChanges();
                            ViewBag.Message = "Password Changed Successfully!";
                        }
                        else
                        {
                            ViewBag.Message = "Password not Updated!";
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Old Password is wrong! Please /enter Valid one";
                    }

                }
            }
            catch (Exception)
            {
                ViewBag.Message = "Password is not Updated!";
            }
            return View("ChangePassword");

        }

    }
}