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
        public ActionResult Feature(int? number)
        {
            Random rnd = new Random();
            ViewBag.UserId = Session["UserID"].ToString();
            if (number == null)
                return View(ps.Featured().OrderBy(x => rnd.Next()).Take(number ?? 5));
            else
                return PartialView(ps.Featured().OrderBy(x => rnd.Next()).Take(number ?? 5));
        }

        public ActionResult Trending(int? number) {
            ViewBag.UserId = Session["UserID"].ToString();
            if (number == null) 
            return PartialView(ps.Trending().Take(number??5));
            else
            return View(ps.Trending().Take(5));
        }
        
        public ActionResult RecentUploads(int? offset) {
            ViewBag.UserId = Session["UserID"].ToString();
            return View(ps.RecentUploads(offset??null).Take(12));
        }
    }
}