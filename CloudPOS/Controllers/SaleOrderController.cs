using CloudPOS.Models.ViewModels;
using CloudPOS.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudPOS.Controllers
{
    public class SaleOrderController : Controller
    {
        private readonly ISaleProcessService _saleProcessService;
        private readonly IItemService _itemService;
        public IList<SaleDetailViewModel> saleDetails=new List<SaleDetailViewModel>();
        public SaleOrderController(ISaleProcessService saleProcessService,IItemService itemService)
        {
            _saleProcessService = saleProcessService;
            _itemService = itemService;
        }
        public IActionResult Entry()
        {
            ViewBag.Items = _itemService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult AddToCart(SaleViewModel sale,SaleDetailViewModel saleDetail)
        {
            saleDetails.Add(saleDetail);
            ViewBag.Info = "adding an item to the cart!!";
            ViewBag.Items = _itemService.GetAll();
            ViewBag.VoucherNo = sale.VoucherNo;
            ViewBag.SaledDate = sale.SaledDate;
            return View("Entry");
        }
        public IActionResult List()
        {
            return View();
        }
    }
}
