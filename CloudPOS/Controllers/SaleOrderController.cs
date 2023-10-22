using CloudPOS.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudPOS.Controllers
{
    public class SaleOrderController : Controller
    {
        private readonly ISaleProcessService _saleProcessService;

        public SaleOrderController(ISaleProcessService saleProcessService)
        {
            _saleProcessService = saleProcessService;
        }
        public IActionResult Entry()
        {
            return View();
        }
        public IActionResult List()
        {
            return View();
        }
    }
}
