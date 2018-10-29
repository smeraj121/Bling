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
        public string RecordStats(int id,char action)
        {
            string email = Session["Email"].ToString();
            PhotoStats photoStats = photoStatsService.RecordStats(email,id,action);
            if (photoStats != null)
            {
                Stats stats = new Stats() { Success=true, Loves = photoStats.Loves, Stat = "Nostats", Likes = photoStats.Likes, Dislikes = photoStats.Dislikes };
                if (photoStats.LikedBy.IndexOf("," + Session["UserID"] + ",") > -1)
                    stats.Stat = "L"; //ViewBag.my_Stat = "Liked";
                else if (photoStats.DisLikedBy.IndexOf("," + Session["UserID"] + ",") > -1)
                    stats.Stat = "D"; //ViewBag.my_Stat = "Disliked";
                else if (photoStats.LovedBy.IndexOf("," + Session["UserID"] + ",") > -1)
                    stats.Stat = "H";//ViewBag.my_Stat = "Loved";
                else
                    stats.Stat = "No Stat"; //ViewBag.my_stat = "No stat";
                return Newtonsoft.Json.JsonConvert.SerializeObject(stats);
            }
            else return Newtonsoft.Json.JsonConvert.SerializeObject(new Stats() { Success = false });
        }

        public ActionResult AllStats()
        {
            return View(); }
    }
    public class Stats {
        public int Likes;
        public int Loves;
        public int Dislikes;
        public bool Success;
        public string Stat;
    }
}