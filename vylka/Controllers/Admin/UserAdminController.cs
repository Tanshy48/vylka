#nullable disable

using Microsoft.AspNetCore.Mvc;
using vylka.Data;


namespace Fork_Site.Controllers
{
    public class UserAdminController : Controller
    {
        private readonly vylkaContext _db;
        public UserAdminController(vylkaContext db)
        {
            _db = db;
        }
        
        public ActionResult Users()
        {
            return View(_db.User.ToList());
        }
        public ActionResult EditUserRole()
        {
            return View(_db.User.ToList());
        }

    }
}
