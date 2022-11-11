using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fork_Site.Controllers
{
    //[Authorize(Roles = "Admin")]
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
