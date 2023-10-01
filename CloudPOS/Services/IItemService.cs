using CloudPOS.Models.ViewModels;

namespace CloudPOS.Services
{
    public interface IItemService
    {
        void Create(ItemViewModel itemViewModel);
        IEnumerable<ItemViewModel> GetAll();
        void Update(ItemViewModel itemViewModel);
        void Delete(string Id);
        ItemViewModel GetBy(string Id);
    }
}
