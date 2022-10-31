using Microsoft.AspNetCore.Mvc;

namespace Fork_Site.Controllers
{
    public class OrderAdminController : Controller
    {
        public ActionResult Orders()
        {
            return View();
        }
        public ActionResult DeleteOrder()
        {
            return View();
        }
    }
}
