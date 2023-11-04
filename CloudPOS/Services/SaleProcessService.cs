using CloudPOS.Models;
using CloudPOS.Models.ViewModels;
using CloudPOS.Repisitories.Domain;
using CloudPOS.UnitOfWorks;

namespace CloudPOS.Services
{
    public class SaleProcessService : ISaleProcessService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SaleProcessService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(SaleViewModel salevm, SaleDetailViewModel saleDetailvm)
        {
            var sale = new SaleEntity()
            {
                Id=Guid.NewGuid().ToString(),
                VoucherNo=salevm.VoucherNo,
                SaledDate=salevm.SaledDate,
                TotalPrice=salevm.TotalPrice
            };
            var saleDetail = new SaleDetailEntity()
            {
                Id = Guid.NewGuid().ToString(),
                SaleId = sale.Id,//foreign key of sale table
                ItemId = saleDetailvm.ItemId,//foreign key of item table
                Qty = saleDetailvm.Qty,
                Remark = saleDetailvm.Remark
            };           
            //updating the stock balance
            var stockBalanceEntity = _unitOfWork.StockBalanceRepository.ReteriveBy(x => x.ItemId == saleDetail.ItemId).FirstOrDefault();
            if (stockBalanceEntity!=null && stockBalanceEntity.Qty > saleDetail.Qty)
            {
                _unitOfWork.SaleRepository.Create(sale);
                _unitOfWork.SaleDetailRepository.Create(saleDetail);
                stockBalanceEntity.Qty -= saleDetail.Qty;
                stockBalanceEntity.ModifiedAt = DateTime.Now;
                _unitOfWork.StockBalanceRepository.Update(stockBalanceEntity);
            }
            _unitOfWork.Commit();
        }

        public IList<SaleDetailViewModel> GetAll()
        {
            return _unitOfWork.SaleDetailRepository.ReteriveAll().Select(x=>new SaleDetailViewModel
            {
            //ItemInfo=_unitOfWork.ItemRepository.ReteriveBy(r=>r.Id==x.ItemId).
            ItemInfo="NA",
            UnitPrice=101,
            Qty=x.Qty,
            Remark=x.Remark,
            ItemId=x.ItemId,
            }).ToList();
        }
    }
}
