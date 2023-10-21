using CloudPOS.Models.ViewModels;
using CloudPOS.Reports.Common;
using CloudPOS.Reports.DataSets;
using CloudPOS.Services;
using CloudPOS.Utlis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloudPOS.Controllers
{
    public class StockInComeController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        private readonly IReporting _reporting;
        private readonly IStockInComeService _stockInComeService;

        public StockInComeController(IItemService itemService,
            ICategoryService categoryService,
            IBrandService brandService,
            IReporting reporting,
            IStockInComeService stockInComeService){
            _itemService = itemService;
            _categoryService = categoryService;
            _brandService = brandService;
            _reporting = reporting;
            _stockInComeService = stockInComeService;
        }

        #region create process for new record
        [Authorize(Roles = "admin")]
        public IActionResult Entry()
        {
            ViewBag.Items = _itemService.GetAll();
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Entry(StockInComeViewModel viewModel)
        {
            try
            {
                _stockInComeService.Create(viewModel);
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

        public IActionResult List()=>View(_stockInComeService.GetAll());
        [Authorize(Roles = "admin")]
        public IActionResult Delete(string Id)
        {
            try
            {
                _stockInComeService.Delete(Id);
                TempData["Info"] = "Successfully delete a record from the system";
            }
            catch (Exception e)
            {
                TempData["Info"] = "Error occur when delete a record to the system !" + e.Message;
            }
            return RedirectToAction("List");
        }
        [Authorize(Roles = "admin")]
        public IActionResult Edit(string Id)
        {
            try
            {
                StockInComeViewModel item = _stockInComeService.GetBy(Id);
                ViewBag.Items = _itemService.GetAll().Where(x=>x.Id!=item.ItemId);//for binding the category select box
                return View(item);//bind the itemview Model to the UI
            }
            catch(Exception e)
            {
                TempData["Info"] = "Error occur when get a record from the system !" + e.Message;
            }
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Update(StockInComeViewModel viewModel)
        {
            try
            {
                _stockInComeService.Update(viewModel);
                //ViewBag.Info = "Successfully save a record to the system";
                TempData["Info"] = "Successfully update a record to the system";
            }
            catch (Exception e)
            {
                TempData["Info"] = "Error occur when update a record to the system !" + e.Message;
            }
            return RedirectToAction("List");
        }
        
        [Authorize(Roles ="admin")]
        public IActionResult ReportBy()
        {
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Brands = _brandService.GetAll();
            return View();
        }

        [HttpPost,Authorize(Roles ="admin")]
        public IActionResult ReportBy(string itemCode,string categoryId,string brandId) 
        {
            string fileDownloadName = $"itemReport{Guid.NewGuid():N}.xlsx";
            IList <ItemDetailReportDataSet> itemDetailReportDataSets=_reporting.GetItemReportBy(itemCode, brandId, categoryId);
            if (itemDetailReportDataSets.Count > 0)
            {
                var fileContentsInBytes = ReportHelper.ExportToExcel(itemDetailReportDataSets, fileDownloadName);
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                return File(fileContentsInBytes,contentType,fileDownloadName);
            }
            else
            {
                ViewBag.Info = "There is no data to export!!!";
                ViewBag.Categories = _categoryService.GetAll();
                ViewBag.Brands = _brandService.GetAll();
                return View();
            }
            
        }
    }
}
