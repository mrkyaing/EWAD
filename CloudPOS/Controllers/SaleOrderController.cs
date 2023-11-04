using CloudPOS.Models.ViewModels;
using CloudPOS.Services;
using CloudPOS.Utlis;
using Microsoft.AspNetCore.Mvc;

namespace CloudPOS.Controllers
{
    public class SaleOrderController : Controller
    {
        private readonly ISaleProcessService _saleProcessService;
        private readonly IItemService _itemService;
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
        public JsonResult AddToCart(SaleDetailViewModel saleDetail)
        {
            ViewBag.Info = "adding an item to the cart!!";
            var item = _itemService.GetBy(saleDetail.ItemId);          
            saleDetail.ItemInfo = item.ItemCode + " " + item.ItemDescription;
            saleDetail.UnitPrice = item.SalePrice;
            if (SessionHelper.GetDataFromSession<List<SaleDetailViewModel>>(HttpContext.Session, "cart") == null)
            {
               var cart = new List<SaleDetailViewModel>();               
                cart.Add(saleDetail);
                SessionHelper.SetDataToSession(HttpContext.Session, "cart", cart);
            }
            else
            {
                var cart = SessionHelper.GetDataFromSession<List<SaleDetailViewModel>>(HttpContext.Session, "cart");
                //check the item is already exists in cart
                int index = IsAlreadyExistsInCart(saleDetail.ItemId);
                if (index != -1)
                    //when item already have in cart,increase the quantity
                    cart[index].Qty++;
                else 
                    //if not in cart,add the new item
                    cart.Add(saleDetail);
                //add the cart record to the session
                SessionHelper.SetDataToSession(HttpContext.Session, "cart", cart);
            }
            return Json(null);
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult CheckCart(SaleViewModel saleViewModel)
        {
            var cart = SessionHelper.GetDataFromSession<List<SaleDetailViewModel>>(HttpContext.Session, "cart");
            TempData["VoucherNo"] = saleViewModel.VoucherNo;
            decimal total = cart.Sum(item => item.UnitPrice * item.Qty);
            TempData["TotalPrice"]= total.ToString();
            TempData["SaledDate"] = saleViewModel.SaledDate;
            ViewBag.total = total;
            return View(cart);
        }
        private int IsAlreadyExistsInCart(string itemId)
        {
            var cart = SessionHelper.GetDataFromSession<List<SaleDetailViewModel>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].ItemId.Equals(itemId))
                 return i;
            }
            return -1;
        }

        [HttpPost]
        public IActionResult Paid(SaleViewModel saleViewModel)
        {
            try
            {
                var cart = SessionHelper.GetDataFromSession<List<SaleDetailViewModel>>(HttpContext.Session, "cart");
                foreach(var itemDetail in cart)
                {                  
                    _saleProcessService.Create(saleViewModel, itemDetail);
                }              
            }
            catch (Exception e)
            {
                TempData["Info"] = "Error occur when saving ordering process :"+e.Message;
            }
            return RedirectToAction("List");
        }
    }
}
