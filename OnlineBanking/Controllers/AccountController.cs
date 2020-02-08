using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineBanking.DBModel;
using OnlineBanking.Models;

namespace OnlineBanking.Controllers
{
    public class AccountController : Controller
    {
        OnlineBankingEntities onlineBankingEntities = new OnlineBankingEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            LoginModel loginModel = new LoginModel();
            return View(loginModel);
        }
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            OnlineBankingEntities onlineBankingEntities = new OnlineBankingEntities();
            if (ModelState.IsValid)
            {
                if (onlineBankingEntities.LoginInfo.Where(m => m.UserID == loginModel.UserID && m.Password == loginModel.Password).FirstOrDefault() == null)
                {
                    ModelState.AddModelError("Error", "UserID/Password not valid");
                    return View();
                }
                else 
                {
                    var status = (from m in onlineBankingEntities.CustomerInfo
                                    where m.UserID == loginModel.UserID
                                    select m.Status).FirstOrDefault();
                    if(status=="Freeze")
                    {
                        ModelState.AddModelError("Error", "Your account is Freezed,Contact your nearest Bank");
                        return View();
                    }
                    var userType = (from m in onlineBankingEntities.LoginInfo
                                    where m.UserID == loginModel.UserID && m.Password == loginModel.Password
                                    select m.UserType).FirstOrDefault();
                    var userName= (from m in onlineBankingEntities.LoginInfo
                                   where m.UserID == loginModel.UserID && m.Password == loginModel.Password
                                   select m.UserName).FirstOrDefault();
                    var userID = loginModel.UserID;
                    //var userDetails = onlineBankingEntities.LoginInfo.Where(m => m.UserID == loginModel.UserID && m.Password == loginModel.Password).Select(m => new { m.UserName, m.UserType });
                    //var userType = userDetails.Select(e => e.UserType).ToString();
                    //var userName = userDetails.Select(e => e.UserName).ToString();
                    if (userType == "Customer")
                    {
                        Session["UserID"] = userID;
                        Session["UserType"] = userType;
                        Session["UserName"] = userName;
                        return RedirectToAction("UserHomePage", "User");

                    }
                    else if (userType == "Admin")
                    {
                        Session["UserID"] = userID;
                        Session["UserType"] = userType;
                        Session["UserName"] = userName;
                        return RedirectToAction("AdminHomePage", "Admin");
                    }
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
           
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Session["UserID"] = null;
            Session["UserType"] = null;
            Session["UserName"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}