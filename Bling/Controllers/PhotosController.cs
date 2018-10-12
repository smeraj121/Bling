using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProofOfConcept.Models;
using ProofOfConcept.Services;

namespace ProofOfConcept.Controllers
{
    public class PhotosController : Controller
    {
        // GET: Photos
        IPhotoService photoService;
        public PhotosController(IPhotoService photoService) {
            this.photoService = photoService;
        }

        public ActionResult Upload()
        {
            //ViewBag.UploadType = "Upload Pic";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase picture, string caption)
        {
            if(Session["LoggedIn"]!=null && (bool)Session["LoggedIn"] == true)
            {
                if (picture != null && picture.ContentLength > 0 && picture.ContentType.Contains("image"))
                {
                    bool result = photoService.UploadPic(picture, Session["Email"].ToString(), caption);
                    if (result != false) { }
                    else
                    {
                        ViewBag.Status = "Upload Failed!!!";
                        return View();
                    }
                }
                else {
                    ModelState.AddModelError("PhotoPath", "Please select an image to upload");
                    return View();
                }
                return RedirectToAction("Uploads");
            }
            else return RedirectToAction("Index", "Home");
        }

        public ActionResult Uploads()
        {
            if (Session["LoggedIn"] != null && (bool)Session["LoggedIn"] == true)
            {
                string email = Session["Email"].ToString();
                List<Photos> photos = photoService.GetUploads(email);
                ViewBag.UserId = Session["UserID"].ToString();
                return View(photos);
            }
            else return RedirectToAction("Index", "Home");
        }
    }
}