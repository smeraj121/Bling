using ProofOfConcept.Models;
using ProofOfConcept.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProofOfConcept.Controllers
{
    public class AdminPhotoController : Controller
    {
        IAdminPhotoService aps;
        public AdminPhotoController(IAdminPhotoService aps) {
            this.aps = aps;
        }
        // GET: AdminPhoto
        public ActionResult Index()
        {
            return View(aps.GetUploads());
        }

        // GET: AdminPhoto/Details/5
        public ActionResult Details(int id)
        {
            return View(aps.GetPhoto(id));
        }

        // GET: AdminPhoto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPhoto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminPhoto/Edit/5
        public ActionResult Edit(int id)
        {
            return View(aps.GetPhoto(id));
        }

        // POST: AdminPhoto/Edit/5
        [HttpPost]
        public ActionResult Edit(Photos photo)
        {
            try
            {
                aps.EditPhoto(photo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminPhoto/Delete/5
        public ActionResult Delete(int id)
        {
            return View(aps.GetPhoto(id));
        }

        // POST: AdminPhoto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
