using Microsoft.AspNetCore.Mvc;

namespace vylka.Controllers
{
    public class ShoppingCartController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        /* [HttpPost]
        public IActionResult NewOrder(int id, string address, string city, string amountPaid, string paymentType)
        {
           
        } */
        /* public JsonResult AddData(ShippingDetailModel shippingDetail)
        {
            string msg = string.Empty;
            try{
                SqlCommand command = new("ShippingDetail_Add", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Address", shippingDetail.Address);
                command.Parameters.AddWithValue("@City", shippingDetail.City);
                command.Parameters.AddWithValue("@AmountPaid", shippingDetail.AmountPaid);
                command.Parameters.AddWithValue("@PaymentType", shippingDetail.PaymentType);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return Json(msg, new Newtonsoft.Json.JsonSerializerSettings());
            } catch (Exception) {
                msg = "Error";
                return Json(msg, new Newtonsoft.Json.JsonSerializerSettings());
            }
            
        } */
    }
}