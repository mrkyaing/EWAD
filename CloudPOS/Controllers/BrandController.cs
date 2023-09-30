using CloudPOS.Models.ViewModels;
using CloudPOS.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudPOS.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)=>this._brandService = brandService;

        public IActionResult List()=>View(_brandService.GetAll());

        public IActionResult Entry() => View();

        [HttpPost]
        public IActionResult Entry(BrandViewModel viewModel)
        {
            try
            {
                _brandService.Create(viewModel);
                //ViewBag.Info = "Successfully save a record to the system";
                TempData["Info"] = "Successfully save a record to the system";
            }
            catch (Exception e)
            {
                TempData["Info"] = "Error occur when save a record to the system !" + e.Message;
            }
            return RedirectToAction("List");
        }
        public IActionResult Delete(string Id)
        {
            try
            {
                var entity = _brandService.GetBy(Id);
                if (entity != null)
                {
                    _brandService.Delete(Id);
                    TempData["Info"] = "Successfully delete a record from the system";
                }
            }
            catch (Exception e)
            {
                TempData["Info"] = "Error occur when delete a record to the system !" + e.Message;
            }
            return RedirectToAction("List");
        }

        public IActionResult Edit(string Id)//1
        {
            var viewModel=_brandService.GetBy(Id);
            if (viewModel != null)
                return View(viewModel);
            else
            {
                TempData["Info"] = "There is no record that you selected";
                return RedirectToAction("List");
            }
        }
        [HttpPost]
       public IActionResult Update(BrandViewModel viewModel)
        {
            try
            {
                _brandService.Update(viewModel);
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
