using Microsoft.AspNetCore.Mvc;

namespace FirstMVCCore.Controllers {
    public class StudentController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Entry() => View();//rendering the entry view UI only 

        [HttpPost] //it will fire when you click the submit button at entry view UI
        public IActionResult Entry(string code,string name,string email,string batchId,
            string dob,string phonenumber,string nrc,string fathername,string address) {
            ViewData["result"] = "entry process is complete successfully.";
            ViewData["data"] = $"Hello,{name},Your submitted data :{code},{email},{batchId},{dob},{phonenumber},{nrc},{fathername},{address}";
            return View();
        }
    }
}
