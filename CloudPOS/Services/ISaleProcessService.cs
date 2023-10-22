using CloudPOS.Models.ViewModels;

namespace CloudPOS.Services
{
    public interface ISaleProcessService
    {
        void Create(SaleViewModel salevm, SaleDetailViewModel saleDetailvm);
        IList<SaleDetailViewModel> GetAll();
    }
}
