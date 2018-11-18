using ProofOfConcept.Models;
using ProofOfConcept.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProofOfConcept.Controllers
{
    public class UsersController : Controller
    {
        IUsersService usersService;
        public UsersController(IUsersService usersService) {
            this.usersService = usersService;
        }
        // GET: Users
        public ActionResult ViewUser(string email)
        {
            ViewBag.UserId = Session["UserID"].ToString();
            return View (usersService.GetUser(email));
        }

        public object Follow(string email) {
            string userid = Session["UserID"].ToString();
            UserDetails us=usersService.FollowUser(email, userid);
            var followed = (us.Followers.IndexOf("," + userid + ",") > -1) ? true : false;
            return Newtonsoft.Json.JsonConvert.SerializeObject(new { Success = true, Followed = followed, Followers = us.FollowerCount }); 
        }
    }
}