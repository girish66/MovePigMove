using System.Web.Mvc;

namespace MovePigMove.UI.Controllers
{
    public class HomeController : BaseController
    {
        //temporary fix to no / route
        public RedirectToRouteResult Index()
        {
            return RedirectToAction("Index", "Exercises");
        }
    }
}