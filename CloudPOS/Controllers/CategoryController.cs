using CloudPOS.Models.ViewModels;
using CloudPOS.Services;
using Microsoft.AspNetCore.Mvc;


namespace CloudPOS.Controllers
{
    public class CategoryController : Controller
    {
        #region define the constructor and inject the ICategoryService for db transactions
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)=>_categoryService = categoryService;
        #endregion

        #region create process for new record
        public IActionResult Entry() => View();
        [HttpPost]
        public IActionResult Entry(CategoryViewModel viewModel)
        {
            try
            {
                _categoryService.Create(viewModel);
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

        #region reterive process from database
        public IActionResult List()=> View(_categoryService.GetAll());//return to the view with categories IList Data 
        #endregion

        #region update process for existing record
        public IActionResult Edit(string Id)//1
        {
            CategoryViewModel categoryViewModel = _categoryService.GetBy(Id);
            //CategoryEntity category1 = (from c in _context.Categories where c.Id == Id select c).FirstOrDefault();//Query Style Linq
            if (categoryViewModel != null)
                return View(categoryViewModel);
            else
            {
                TempData["Info"] = "There is no record that you selected";
                return RedirectToAction("List");
            }
        }
        [HttpPost]
        public IActionResult Update(CategoryViewModel viewModel)
        {
            try
            {
                _categoryService.Update(viewModel);
                TempData["Info"] = "Successfully update a record to the system";
            }
            catch (Exception e)
            {
                TempData["Info"] = "Error occur when update a record to the system !" + e.Message;
            }
            return RedirectToAction("List");
        }
        #endregion

        #region delete process for existing record
        public IActionResult Delete(string Id)
        {
            try
            {
                _categoryService.Delete(Id);
                TempData["Info"] = "Successfully delete a record from the system";
            }
            catch (Exception e)
            {
                TempData["Info"] = "Error occur when delete a record to the system !" + e.Message;
            }
            return RedirectToAction("List");
        }
        #endregion

    }
}
