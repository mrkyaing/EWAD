using Microsoft.AspNetCore.Mvc;

namespace FirstMVCCore.Controllers {
    public class AboutUsController : Controller {
        public IActionResult Index() {
            ViewBag.Message = TempData["message"];
            return View();
        }
    }
}
