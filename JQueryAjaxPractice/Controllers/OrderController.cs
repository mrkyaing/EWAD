using JQueryAjaxPractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace JQueryAjaxPractice.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult GetTimeNow() => View();//it will render only view UI
        public JsonResult GetCurrentTime()
        {
            string now = DateTime.Now.ToString();
            return Json(now);
        }

        public IActionResult MakeAnOrder()=>View();
        [HttpPost]
        public JsonResult MakeAnOrder(OrderModel order)
        {
            int totalAmount = order.Quantity * order.UnitPrice;//2*1500
            return Json(totalAmount);//3000
        }
    }
}
