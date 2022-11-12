#nullable disable

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vylka.Data;
using vylka.Models;

namespace Fork_Site.Controllers
{
    /* [Authorize(Roles = "Admin")] */
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

    }
}
