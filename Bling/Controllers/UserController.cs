using ProfilerApp.Models;
using ProofOfConcept.Models;
using ProofOfConcept.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProofOfConcept.Controllers
{
    public class UserController : Controller
    {
        IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            int result = userService.AddUser(user);
            if (result!=0)
            {
                TempData["Email"] = user.Email;
                Session["LoggedIn"] = true;
                Session["Email"] = user.Email;
                Session["UserID"] = result;
                return RedirectToAction("HomePage","Content");
            }
            else
            {
                ViewBag.Success = "Attempt failed";
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login user)
        {
            UserAuth result = userService.AuthenticateUser(user);
            if (result.UserID > 0)
            {
                TempData["Email"] = user.Email;
                Session["LoggedIn"] = true;
                Session["Email"] = user.Email;
                Session["UserID"] = result.UserID;
                if (result.Role.Trim() == "Admin")
                    return RedirectToAction("Index", "Admin");
                else
                {
                    if (user.ReturnURL != null) return Redirect(user.ReturnURL);
                    else
                        return RedirectToAction("HomePage", "Content");
                }
            }
            else
            {
                ViewBag.Success = "Attempt failed";
            }
            return View();
        }

        public ActionResult Signout() {
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ForgotPassword() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(string email) {
            if (userService.ForgotPassword(email))
                return View("MailSent");
            else
                ViewBag.Error="User not found";
                return View();
        }

        public ActionResult SetPassword(string guid, string email) {
            if (userService.MatchGuid(guid, email))
            {
                ViewBag.Email = email;
                return View();
            }
            return View("ForgotPassword");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetPassword(SetPassword passwordmodel) {
            userService.SetPassword(passwordmodel);
            return RedirectToAction("HomePage", "Content");
        }
        public ActionResult ChangePassword() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePassword changePassword) {
            if (ModelState.IsValid)
            {
                if (changePassword.NewPassword == changePassword.ConfirmPassword)
                {
                    if (userService.ChangePassword(changePassword, Session["UserID"].ToString()))
                    {
                        return RedirectToAction("HomePage", "Content");
                    }
                    else {
                        ViewBag.Status = "Attempt failed";
                    }
                }
            }
            return View();
        }
    }
}