using ProofOfConcept.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProofOfConcept.Controllers
{
    public class PresentController : Controller
    {
        // GET: Present
        IPresentService ps;
        public PresentController(IPresentService ps) { this.ps = ps; }
        public ActionResult Feature()
        {
            Random rnd = new Random();
            ViewBag.UserId = Session["UserID"].ToString();
            return View(ps.Featured().OrderBy(x => rnd.Next()).Take(5));
        }

        public ActionResult Trending() {
            ViewBag.UserId = Session["UserID"].ToString();
            return PartialView(ps.Trending().Take(5));
            return View(ps.Trending().Take(5));
        }

        public ActionResult RecentUploads() {
            ViewBag.UserId = Session["UserID"].ToString();
            return View(ps.RecentUploads().Take(6));
        }
    }
}