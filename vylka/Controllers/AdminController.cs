using Microsoft.AspNetCore.Mvc;

namespace Fork_Site.Controllers
{
    public class AdminController : Controller
    {
        //public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();

        public IActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Categories()
        {
            /*List<Tbl_Category> allcategories = _unitOfWork.GetRepositoryInstance<Tbl_Category>().GetAllRecordsIQueryable().Where(i => i.IsDelete == false).ToList();
            return View(allcategories);*/
            return View();
        }
    }
}
