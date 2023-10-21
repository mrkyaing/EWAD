using CloudPOS.Models.ViewModels;

namespace CloudPOS.Services
{
    public interface IStockInComeService
    {
        void Create(StockInComeViewModel vm);
        IEnumerable<StockInComeViewModel> GetAll();
        void Update(StockInComeViewModel vm);
        void Delete(string Id);
        StockInComeViewModel GetBy(string Id);
        bool CheckStockItemAlreadyExistsInStockBalance(string itemId);
    }
}
