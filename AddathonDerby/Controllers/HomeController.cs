using System.Web.Mvc;

namespace AddathonDerby.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = GetDerbies();
            return View(model);
        }
    }
}