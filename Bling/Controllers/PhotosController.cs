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
            ViewBag.UploadType = "Upload Pic";
            return View("UploadPic");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase file, string caption)
        {
            if(Session["LoggedIn"]!=null && (bool)Session["LoggedIn"] == true)
            {
                if (file != null && file.ContentLength > 0 && (file.ContentType.Contains("image") || file.ContentType.Contains("video")))
                {
                    bool result = photoService.UploadPic(file, Session["Email"].ToString(), caption);
                    if (result != false) {
                        if (file.ContentType.Contains("video")) {
                            ViewBag.filepath = result;
                            return View("Thumnail");
                        }
                    }
                    else
                    {
                        ViewBag.Status = "Upload Failed!!!";
                        return View();
                    }
                }
                else {
                    //ModelState.AddModelError("PhotoPath", "Please select an image to upload");
                    ViewBag.Status = "Please select an image to upload";
                    ViewBag.UploadType = "Upload Pic";
                    return View("UploadPic");
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

        public ActionResult DisplayPhoto(int photoId)
        {
            if (Session["LoggedIn"] != null && (bool)Session["LoggedIn"] == true)
            {
                string email = Session["Email"].ToString(); 
                bool result = photoService.SetTrending(photoId);
                Photos photo = photoService.GetPhoto(photoId);
                ViewBag.UserId = Session["UserID"].ToString();
                return View(photo);
            }
            else return RedirectToAction("Index", "Home");
        }
    }
}