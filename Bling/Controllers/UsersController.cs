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
        public ActionResult ViewUser(string user)
        {
            ViewBag.UserId = Session["UserID"].ToString();
            return View (usersService.GetUser(user));
        }

        public object Follow(string userID) {
            string currentUser = Session["UserID"].ToString();
            UserDetails us=usersService.FollowUser(userID, currentUser);
            var followed = (us.Followers.IndexOf("," + currentUser + ",") > -1) ? true : false;
            return Newtonsoft.Json.JsonConvert.SerializeObject(new { Success = true, Followed = followed, Followers = us.FollowerCount }); 
        }

        public object Block(string userId) {
            string currentUser = Session["UserID"].ToString();
            usersService.BlockUser(currentUser, userId);
            return new object();
        }
    }
}