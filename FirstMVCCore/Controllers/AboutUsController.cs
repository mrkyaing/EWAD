using Microsoft.AspNetCore.Mvc;

namespace FirstMVCCore.Controllers {
    public class AboutUsController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
