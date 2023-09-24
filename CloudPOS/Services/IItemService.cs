using CloudPOS.Models.ViewModels;

namespace CloudPOS.Services
{
    public interface IItemService
    {
        void Create(ItemViewModel itemViewModel);
        IEnumerable<ItemViewModel> GetAll();
        void Update(ItemViewModel itemViewModel);
        void Delete(ItemViewModel itemViewModel);
    }
}
