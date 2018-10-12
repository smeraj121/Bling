using ProofOfConcept.Models;
using ProofOfConcept.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProofOfConcept.Controllers
{
    public class PopularsController : Controller
    {
        IPhotoService photoService;
        public PopularsController(IPhotoService photoService)
        {
            this.photoService = photoService;
        }
        // GET: Populars
        public ActionResult Popular()
        {
            if (Session["LoggedIn"] != null && (bool)Session["LoggedIn"] == true)
            {
                List<Photos> photos = photoService.GetPhotos();
                ViewBag.UserId = Session["UserID"].ToString();
                return View(photos);
            }
            else return RedirectToAction("Index", "Home");
        }
    }
}