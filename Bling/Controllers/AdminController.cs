using ProofOfConcept.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProofOfConcept.Controllers
{
    public class AdminController : Controller
    {
        IAdminService adminservice;
        public AdminController(IAdminService adminservice) { this.adminservice = adminservice; }
        public ActionResult Index() {
            return View();
        }
        public ActionResult ViewPhotos() {
            return View(adminservice.ViewAdmins());
        }
        public ActionResult Edit(int UserID) {
            return View(adminservice.ViewAdmin(UserID));
        }

    }
}