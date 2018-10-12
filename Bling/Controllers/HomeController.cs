using ProfilerApp.Models;
using ProofOfConcept.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProofOfConcept.Controllers
{
    public class HomeController : Controller
    {
        IPhotoService photoService;
        public HomeController(IPhotoService photoService) {
            this.photoService = photoService;
        }
        public ActionResult Index()
        {
            ViewBag.Images = photoService.GetRandomPics();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}