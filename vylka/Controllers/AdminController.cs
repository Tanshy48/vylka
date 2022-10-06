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

        /*public IActionResult Categories()
        {
            List<Tbl_Category> allCategories = _unitOfWork.GetRepositoryInstance<Tbl_Category>().GetAllRecordsIQueryable().Where(i => i.IsDelete == false).toList();
            return View(allCategories);
        }*/
    }
}
