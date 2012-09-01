using System.Web.Mvc;

namespace MovePigMove.Web.Controllers
{
    public class HomeController : BaseController
    {
        //temporary fix to no / route
        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("Index", "Workout");
        }
    }
}