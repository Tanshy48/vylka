using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Drawing;
using vylka.Data;
using vylka.Models;

namespace vylka.Controllers
{
    public class ProductsController : Controller
    {
        private readonly vylkaContext _db;
        public ProductsController(vylkaContext db)
        {
            _db = db;
        }
        public IActionResult Refrigerators()
        {
            return View(_db.Products.ToList());
        }
        public IActionResult TVs()
        {
            return View(_db.Products.ToList());
        }
        public IActionResult Vacuums()
        {
            return View(_db.Products.ToList());
        }
        public IActionResult Conditioners()
        {
            return View(_db.Products.ToList());
        }


        
    }


    
}