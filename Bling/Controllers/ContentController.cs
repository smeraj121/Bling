using ProofOfConcept.Models;
using ProofOfConcept.Services;
using System.Web;
using System.Web.Mvc;

namespace ProofOfConcept.Controllers
{
    public class ContentController : Controller
    {
        IUserDetailsService userDetails;
        public ContentController(IUserDetailsService userDetails)
        {
            this.userDetails = userDetails;
        }
        public ActionResult HomePage()
        {
            bool loggedin = (bool)Session["LoggedIn"];
            if (loggedin == true)
            {
                string email = (string)TempData["Email"];
                return View();
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult MyProfile()
        {
            bool loggedin = false;
            if (Session.Count > 0) {
                loggedin = (bool)Session["LoggedIn"];
            }
            
            if (loggedin == true)
            {
                var user = userDetails.GetUser(Session["Email"].ToString());
                return View(user);
            }
            else
                return RedirectToAction("Index", "Home");

        }

        public ActionResult Edit(int id)
        {
            bool loggedin = (bool)Session["LoggedIn"];
            if (loggedin == true)
            {
                var user = userDetails.GetUser(Session["Email"].ToString());
                return View(user);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(UserDetails user)
        {
            bool loggedin = (bool)Session["LoggedIn"];
            if (loggedin == true)
            {
                if (ModelState.IsValid)
                {
                    var result = userDetails.EditUser(user);
                    return RedirectToAction("MyProfile");
                }
                else return View();
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangeProfilePic()
        {
            bool loggedin = (bool)Session["LoggedIn"];
            if (loggedin == true)
            {
                //return RedirectToAction("Picture","UploadPic",new { uploadType= "Change Profile Pic" }) ;
                ViewBag.UploadType = "Change Profile Pic";
                return View("UploadPic");
            }
            else return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeProfilePic(HttpPostedFileBase picture) {
            bool loggedin = (bool)Session["LoggedIn"];
            if (loggedin == true)
            {
                if (picture.ContentLength > 0 && picture.ContentType.Contains("image"))
                {
                    bool result = userDetails.UploadPic(picture, Session["Email"].ToString());
                    if (result == false)
                    {
                        ViewBag.Status = "Upload Failed!!!";
                        return View();
                    }
                }
                return RedirectToAction("MyProfile");
            }
            else return RedirectToAction("Index", "Home");
        }
    }
}