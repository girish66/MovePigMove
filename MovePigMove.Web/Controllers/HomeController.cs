using System.Web.Mvc;

namespace MovePigMove.Web.Controllers
{
    public class HomeController : BaseController
    {
        //temporary fix to no / route
        public ViewResult Index()
        {
            return View();
            //return RedirectToAction("Index", "Exercises");
        }
    }
}