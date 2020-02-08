using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineBanking.Models;
using OnlineBanking.DBModel;
using System.Web.Routing;

namespace OnlineBanking.Controllers
{
    public class AdminController : Controller
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
            else if (session != null && (session["UserType"].ToString()) != "Admin")

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
        OnlineBankingEntities onlineBankingEntities = new OnlineBankingEntities();

        public ActionResult AdminHomePage()
        {
            return View();
        }
        public ActionResult CustomerRegistrationForm()
        {
            CustomerDetailsModel customerDetails = new CustomerDetailsModel();
            return View(customerDetails);
        }
        [HttpPost]
        public ActionResult Register(CustomerDetailsModel customerDetails)
        {

            CustomerInfo customer = new CustomerInfo();
            LoginInfo login = new LoginInfo();
            AccountDetail accountDetail = new AccountDetail();
            //Adding details to CustomerInfo
            customer.UserID = customerDetails.UserID;
            customer.UserName = customerDetails.UserName;
            customer.Gender = customerDetails.Gender;
            customer.DOB = customerDetails.DOB;
            customer.AddressLine = customerDetails.AddressLine;
            customer.City = customerDetails.City;
            customer.StateDetails = customerDetails.State;
            customer.Country = customerDetails.Country;
            customer.Pincode = customerDetails.Pincode;
            customer.Email = customerDetails.Email;
            customer.PrimaryPhoneNumber = customerDetails.PrimaryPhoneNumber;
            customer.AccountNumber = customerDetails.AccountNumber;
            customer.Password = customerDetails.Password;
            customer.Status = "Active";
            customer.BalanceAvailable = decimal.Parse(customerDetails.BalanceAvailable);
            //Adding details to LoginInfo
            login.UserID = customerDetails.UserID;
            login.UserName = customerDetails.UserName;
            login.UserType = "Customer";
            login.Password = customerDetails.Password;
            //Adding details to AccountDetails
            accountDetail.UserID= customerDetails.UserID;
            accountDetail.AccountNumber= customerDetails.AccountNumber;
            accountDetail.UserName = customer.UserName;
            accountDetail.BalanceAvailable = customer.BalanceAvailable;
            accountDetail.Status = customer.Status;
            //Adding to Entities
            onlineBankingEntities.CustomerInfo.Add(customer);
            onlineBankingEntities.AccountDetails.Add(accountDetail);
            onlineBankingEntities.LoginInfo.Add(login);
           // onlineBankingEntities.SaveChanges();
            //return View();
            return RedirectToAction("AdminHomePage", "Admin");
        }

        public ActionResult ManageCustomer()
        {
            return View();
        }


        public ActionResult SearchCustomerForEdit(string userId)
        {
            return View();
        }
        [HttpGet]
        public ActionResult SearchCustomer(string userId)
        {
            var cust = onlineBankingEntities.CustomerInfo.Where(x => x.UserID == userId).ToList();


            if (cust == null)
            {
                return HttpNotFound();
            }
            CustomerInfo custInfo = new CustomerInfo();
            foreach (var item in cust)
            {
                custInfo.UserID = item.UserID;
                custInfo.UserName = item.UserName;
                custInfo.Gender = item.Gender;
                custInfo.DOB = item.DOB;
                custInfo.AddressLine = item.AddressLine;
                custInfo.City = item.City;
                custInfo.StateDetails = item.StateDetails;
                custInfo.Country = item.Country;
                custInfo.Pincode = item.Pincode;
                custInfo.PrimaryPhoneNumber = item.PrimaryPhoneNumber;
                custInfo.Email = item.Email;
                custInfo.AccountNumber = item.AccountNumber;
                custInfo.BalanceAvailable = item.BalanceAvailable;
                custInfo.Status = item.Status;
            }
            return View(custInfo);
        }
        [HttpPost]
        public ActionResult UpdateCustomerDetails(CustomerInfo customerInfo)
        {
            OnlineBankingEntities onlineBankingEntities = new OnlineBankingEntities();
            var customer = (from c in onlineBankingEntities.CustomerInfo
                            where c.UserID == customerInfo.UserID
                            select c).First();
            customer.UserName = customerInfo.UserName;
            customer.Gender = customerInfo.Gender;
            customer.DOB = customerInfo.DOB;
            customer.AddressLine = customerInfo.AddressLine;
            customer.City = customerInfo.City;
            customer.StateDetails = customerInfo.StateDetails;
            customer.Country = customerInfo.Country;
            customer.Pincode = customerInfo.Pincode;
            customer.Email = customerInfo.Email;
            customer.PrimaryPhoneNumber = customerInfo.PrimaryPhoneNumber;
            customer.AccountNumber = customerInfo.AccountNumber;
            //    customer.Password = customerInfo.Password;
            customer.Status = customerInfo.Status;
            customer.BalanceAvailable = customerInfo.BalanceAvailable;
            onlineBankingEntities.SaveChanges();
            return RedirectToAction("ManageCustomer", "Admin");
        }


    }//
}