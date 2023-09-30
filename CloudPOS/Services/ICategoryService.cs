using CloudPOS.Models.ViewModels;

namespace CloudPOS.Services
{
    public interface ICategoryService
    {
        void Create(CategoryViewModel viewModel);
        IEnumerable<CategoryViewModel> GetAll();
        CategoryViewModel GetBy(string Id);
        void Update(CategoryViewModel viewModel);
        void Delete(string Id);
    }
}
