﻿using CloudPOS.Models.ViewModels;
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
            saleDetail.UnitPrice = _itemService.GetBy(saleDetail.ItemId).SalePrice;
            if (SessionHelper.GetObjectFromJson<List<SaleDetailViewModel>>(HttpContext.Session, "cart") == null)
            {
               var cart = new List<SaleDetailViewModel>();               
                cart.Add(saleDetail);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                var cart = SessionHelper.GetObjectFromJson<List<SaleDetailViewModel>>(HttpContext.Session, "cart");
                int index = IsAlreadyExistsInCart(saleDetail.ItemId);
                if (index != -1)
                    cart[index].Qty++;
                else 
                    cart.Add(saleDetail);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return Json(null);
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult CheckCart(SaleViewModel saleViewModel)
        {
            var cart = SessionHelper.GetObjectFromJson<List<SaleDetailViewModel>>(HttpContext.Session, "cart");
            TempData["VoucherNo"] = saleViewModel.VoucherNo;
            decimal total = cart.Sum(item => item.UnitPrice * item.Qty);
            TempData["TotalPrice"]= total.ToString();
            TempData["SaledDate"] = saleViewModel.SaledDate;
            ViewBag.total = total;
            return View(cart);
        }
        private int IsAlreadyExistsInCart(string id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<SaleDetailViewModel>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].ItemId.Equals(id))
                 return i;

            }
            return -1;
        }
    }
}
