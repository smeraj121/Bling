using System.Web.Mvc;

namespace ProfilerApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddFAQ(FAQuestions question)
        //{
        //    int result = crudService.AddFAQ(question);
        //    if (result > 0)
        //    {
        //        TempData["Success"] = "Successfully Added";
        //        return RedirectToAction("Edit", new { id = result });
        //    }
        //    else
        //    {
        //        ViewBag.Success = "Attempt failed";
        //        return View();
        //    }
        //}
    }
}