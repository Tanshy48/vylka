#nullable disable

using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using vylka.Constants;
using vylka.Models;


namespace Fork_Site.Controllers
{
    public class UserAdminController : Controller
    {
        readonly SqlCommand command = new();
        readonly SqlDataReader dataReader;
        readonly SqlConnection connection = new(Constants.Connection);
        readonly List<UserModel> UsersList = new();
       

        public ActionResult Users()
        {
            FetchData(GetDataReader());
            return View(UsersList);
        }
        public ActionResult EditUserRole()
        {
            FetchData(GetDataReader());
            return View(UsersList);
        }

        private SqlDataReader GetDataReader() => dataReader;

        private void FetchData(SqlDataReader dataReader)
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
            catch(Exception)
            {
                throw;
            }
        }
    }
}
