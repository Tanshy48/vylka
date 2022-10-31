using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Drawing;
using vylka.Models;

namespace vylka.Controllers
{
    public class ProductsController : Controller
    {

        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Server=localhost;Database=vylka;Trusted_Connection=True;MultipleActiveResultSets=true");
        List<ProductModel> ProductsList = new List<ProductModel>();

        public IActionResult Refrigerators()
        {
            FetchDataRegrigerator();
            return View(ProductsList);
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
            FetchDataConditioner();
            return View(ProductsList);
        }


        private void FetchDataRegrigerator()
        {
            if (ProductsList.Count > 0)
            {
                ProductsList.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) [Id], [Name], [Description], [Quantity], [Price], [CategoryId] FROM [vylka].[dbo].[Products] WHERE [CategoryId] = 1";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    ProductsList.Add(new ProductModel()
                    {
                        Id = (int)dr["Id"],
                        Name = (string)dr["Name"],
                        Description = (string)dr["Description"],
                        Quantity = (int)dr["Quantity"],
                        Price = (double)dr["Price"],
                        CategoryId = (int)dr["CategoryId"],
                    });

                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void FetchDataConditioner()
        {
            if (ProductsList.Count > 0)
            {
                ProductsList.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) [Id], [Name], [Description], [Quantity], [Price], [CategoryId] FROM [vylka].[dbo].[Products] WHERE [CategoryId] = 2";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    ProductsList.Add(new ProductModel()
                    {
                        Id = (int)dr["Id"],
                        Name = (string)dr["Name"],
                        Description = (string)dr["Description"],
                        Quantity = (int)dr["Quantity"],
                        Price = (double)dr["Price"],
                        CategoryId = (int)dr["CategoryId"],
                    });

                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


    
}