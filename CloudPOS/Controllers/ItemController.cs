using CloudPOS.DAO;
using CloudPOS.Models.ViewModels;
using CloudPOS.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudPOS.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;

        public ItemController(IItemService itemService,ICategoryService categoryService,IBrandService brandService)
        {
            _itemService = itemService;
            _categoryService = categoryService;
            _brandService = brandService;
        }

        #region create process for new record
        public IActionResult Entry()
        {
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Brands = _brandService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Entry(ItemViewModel viewModel)
        {
            try
            {
                _itemService.Create(viewModel);
                //ViewBag.Info = "Successfully save a record to the system";
                TempData["Info"] = "Successfully save a record to the system";
            }
            catch (Exception e)
            {
                TempData["Info"] = "Error occur when save a record to the system !" + e.Message;
            }
            return RedirectToAction("List");
        }
        #endregion 

        public IActionResult List()=>View(_itemService.GetAll());
    }
}
