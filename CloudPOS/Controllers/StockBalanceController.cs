using CloudPOS.Models.ViewModels;
using CloudPOS.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace CloudPOS.Controllers
{
    public class StockBalanceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StockBalanceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult List()
        {
            return View(_unitOfWork.StockBalanceRepository.ReteriveAll().Select(x=>new StockBalanceViewModel
            {
                Quantity=x.Qty,
                MininumQuantity=x.MininumQty,
                CreatedAt=x.CreatedAt,
                ItemInfo=_unitOfWork.ItemRepository.ReteriveBy(s=>s.Id==x.ItemId).FirstOrDefault().ItemDescription
            }).ToList());
        }
    }
}
