using Microsoft.AspNetCore.Mvc;

namespace FirstMVCCore.Controllers {
    public class HomeController:Controller  {
        //https://localhost:home/index
        public IActionResult Index() { // Index is action Name
            string message = null;
            int hour=DateTime.Now.Hour;
            if (hour > 12)
                message = "Good afternoo" + DateTime.Now.ToShortDateString();
            else
                message = "Good Monring" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            ViewBag.Msg=message;// Good Monring 26-08-2023 21:01:10
            return View();
        }
        //https://localhost:home/sayyourname
        public IActionResult SayYourName() {
            return View();
        }
        //https://localhost:home/hi
        public string Hi() {
            return "Hi,Okay";
        }
        public ViewResult Calculate2Number() {
            return View();
        }
        //https://localhost:home/calculate2number
        [HttpPost]
        public ViewResult Calculate2Number(int n1,int n2) {
            ViewBag.n1=n1;
            ViewBag.n2 = n2;
            ViewBag.Result = n1*n2;
            return View();
        }
        //https://localhost:home/say
        public JsonResult Say() {
            return Json(new { Id="001",Name="Mg Mg",Age=21});
        }
    }
}
