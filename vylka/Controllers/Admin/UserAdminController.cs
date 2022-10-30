using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using vylka.Models;


namespace Fork_Site.Controllers
{
    public class UserAdminController : Controller
    {
        SqlCommand command = new SqlCommand();
        SqlDataReader dataReader;
        SqlConnection connection = new SqlConnection("Server=localhost;Database=vylka;Trusted_Connection=True;MultipleActiveResultSets=true");
        List<UserModel> UsersList = new List<UserModel>();
       

        public ActionResult Users()
        {
            FetchData();
            return View(UsersList);
        }
        public ActionResult EditUserRole()
        {
            FetchData();
            return View(UsersList);
        }

        private void FetchData()
        {
            if (UsersList.Count > 0)
            {
                UsersList.Clear();
            }
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT TOP (1000) [Id], [Email], [PasswordHash], [PhoneNumber] FROM [vylka].[dbo].[AspNetUsers]";
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    UsersList.Add(new UserModel()
                    {
                        Id = dataReader["Id"].ToString(),
                        Email = dataReader["Email"].ToString(),
                        PasswordHash = dataReader["PasswordHash"].ToString(),
                        PhoneNumber = dataReader["PhoneNumber"].ToString(),
                    });
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
