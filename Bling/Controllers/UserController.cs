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
            bool result = userService.AddUser(user);
            if (result)
            {
                TempData["Email"] = user.Email;
                Session["LoggedIn"] = true;
                Session["Email"] = user.Email;
                Session["UserID"] = 1;
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
        public ActionResult Login(UserAuth user)
        {
            int result = userService.AuthenticateUser(user);
            if (result != 0)
            {
                TempData["Email"] = user.Email;
                Session["LoggedIn"] = true;
                Session["Email"] = user.Email;
                Session["UserID"] = result;
                return RedirectToAction("HomePage", "Content");
            }
            else
            {
                ViewBag.Success = "Attempt failed";
                return View();
            }
        }
    }
}