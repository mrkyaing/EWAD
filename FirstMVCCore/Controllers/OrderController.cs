using Microsoft.AspNetCore.Mvc;

namespace FirstMVCCore.Controllers {
    public class OrderController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
