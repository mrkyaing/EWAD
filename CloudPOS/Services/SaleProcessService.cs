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
                SaledDate=salevm.SaledDate,
                TotalPrice=salevm.TotalPrice
            };
            _unitOfWork.SaleRepository.Create(sale);

            var saleDetail = new SaleDetailEntity()
            {
                Id = Guid.NewGuid().ToString(),
                SaleId = sale.Id,//foreign key of sale table
                ItemId = saleDetailvm.ItemId,//foreign key of item table
                Qty = saleDetailvm.Qty,
                Remark = saleDetailvm.Remark
            };
            _unitOfWork.SaleDetailRepository.Create(saleDetail);

            _unitOfWork.Commit();
        }

        public IList<SaleDetailViewModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
