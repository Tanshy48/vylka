using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Drawing;
using vylka.Models;

namespace vylka.Controllers
{
    public class ProductsController : Controller
    {


        public IActionResult Refrigerators()
        {
            return View();
        }
        public IActionResult TVs()
        {
            FetchDataTV();
            return View(ProductsList);
        }
        public IActionResult Vacuums()
        {

            FetchDataVacuums();
            return View(ProductsList);
        }
        public IActionResult Conditioners()
        {
            return View();
        }


        
    }


    
}