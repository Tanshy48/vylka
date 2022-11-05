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
            return View();
        }
        public IActionResult Vacuums()
        {

            return View();
        }
        public IActionResult Conditioners()
        {
            return View();
        }


        
    }


    
}