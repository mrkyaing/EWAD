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
        public IActionResult Delete(string Id)
        {
            try
            {
                _itemService.Delete(Id);
                TempData["Info"] = "Successfully delete a record from the system";
            }
            catch (Exception e)
            {
                TempData["Info"] = "Error occur when delete a record to the system !" + e.Message;
            }
            return RedirectToAction("List");
        }

        public IActionResult Edit(string Id)
        {
            try
            {
                ItemViewModel item = _itemService.GetBy(Id);
                ViewBag.Categories = _categoryService.GetAll().Where(x=>x.Id!=item.CategoryId);//for binding the category select box
                ViewBag.Brands = _brandService.GetAll().Where(x=>x.Id!=item.BrandId);//for binding the brand select box
                return View(item);//bind the itemview Model to the UI
            }
            catch(Exception e)
            {
                TempData["Info"] = "Error occur when get a record from the system !" + e.Message;
            }
            return View();
        }
        [HttpPost]
        public IActionResult Update(ItemViewModel viewModel)
        {
            try
            {
                _itemService.Update(viewModel);
                //ViewBag.Info = "Successfully save a record to the system";
                TempData["Info"] = "Successfully update a record to the system";
            }
            catch (Exception e)
            {
                TempData["Info"] = "Error occur when update a record to the system !" + e.Message;
            }
            return RedirectToAction("List");
        }
    }
}
