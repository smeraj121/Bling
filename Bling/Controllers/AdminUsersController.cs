using ProofOfConcept.Models;
using ProofOfConcept.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProofOfConcept.Controllers
{
    public class AdminUsersController : Controller
    {
        IAdminUsersService aus;
        public AdminUsersController(IAdminUsersService aus) { this.aus = aus; }
        // GET: AdminUsers
        public ActionResult Index()
        {
            return View(aus.GetUsers());
        }

        // GET: AdminUsers/Details/5
        public ActionResult Details(int id)
        {
            return View(aus.GetUser(id));
        }

        // GET: AdminUsers/Create
        public ActionResult Create()
        {
            return RedirectToAction("Register", "User");
        }

        // POST: AdminUsers/Create
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

        // GET: AdminUsers/Edit/5
        public ActionResult Edit(int id)
        {
            return View(aus.GetUser(id));
        }

        // POST: AdminUsers/Edit/5
        [HttpPost]
        public ActionResult Edit(UserDetails user)
        {
            try
            {
                // TODO: Add update logic here
                aus.EditUser(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminUsers/Delete/5
        public ActionResult Delete(int id)
        {
            return View(aus.GetUser(id));
        }

        // POST: AdminUsers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                aus.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
