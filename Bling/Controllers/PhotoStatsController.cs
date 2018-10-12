using ProofOfConcept.Models;
using ProofOfConcept.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProofOfConcept.Controllers
{
    public class PhotoStatsController : Controller
    {
        IPhotoStatsService photoStatsService;
        public PhotoStatsController(IPhotoStatsService photoStatsService) {
            this.photoStatsService = photoStatsService;
        }
        [HttpPost]
        public ActionResult RecordStats(int id,char action)
        {
            string email = Session["Email"].ToString();
            PhotoStats photoStats = photoStatsService.RecordStats(email,id,action);
            if (photoStats != null)
            {
                if (photoStats.LikedBy.IndexOf("," + Session["UserID"] + ",") > -1)
                    ViewBag.my_Stat = "Liked";
                else if (photoStats.DisLikedBy.IndexOf("," + Session["UserID"] + ",") > -1)
                    ViewBag.my_Stat = "Disliked";
                else if (photoStats.LovedBy.IndexOf("," + Session["UserID"] + ",") > -1)
                    ViewBag.my_Stat = "Loved";
                else
                    ViewBag.my_stat = "No stat";
                return PartialView("PhotoStat", photoStats);
            }
            else return View("Uploads", "Photos");
        }

        public ActionResult AllStats()
        {
            return View(); }
    }
}