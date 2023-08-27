using Microsoft.AspNetCore.Mvc;

namespace FirstMVCCore.Controllers {
    public class HomeController:Controller  {
        //https://localhost:home/index
        public IActionResult Index() { // Index is action Name
            string message = null;
            int hour=DateTime.Now.Hour;
            if (hour > 12)
                message = "Good afternoo " + DateTime.Now.ToShortDateString();
            else
                message = "Good Monring " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            ViewBag.Msg=message;// Good Monring 26-08-2023 21:01:10
            TempData["message"]=message;
            return View();
        }
        //https://localhost:home/sayyourname
        [ActionName("iam")]//https://localhost:home/iam
        public IActionResult SayYourName() {
            return View("SayYourName");//re-define your view name
        }
        //https://localhost:home/hi
        [NonAction] //you can not hit like via the url   https://localhost:home/hi
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
        //https://localhost:home/say //http
        public JsonResult Say() {
            return Json(new { Id="001",Name="Mg Mg",Age=21});
        }
        //https://localhost:home/Sum?n1=3&n2=3&n3=1
        [HttpGet]
        public string Sum(int n1,int n2,int n3) {
            int result = n1 + n2 + n3;
            return result.ToString();
        }

        //https://localhost:home/GetMultiple?n1=3&n2=3
        [HttpGet]
        public IActionResult GetMultiple(int n1,int n2) {
            ViewBag.Result = n1 * n2;
            return View("Multiple");
        }
        //https://localhost:home/SubmitSum?n1=
        [HttpPost]
        public int PostSum(int n1,int n2) {
            return n1 + n2;
        }
        public int GetSum(int n1, int n2) {
            return n1 + n2;
        }
    }
}
