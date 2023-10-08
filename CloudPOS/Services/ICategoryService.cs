using CloudPOS.Models;
using CloudPOS.Models.ViewModels;

namespace CloudPOS.Services
{
    public interface ICategoryService
    {
        CategoryEntity Create(CategoryViewModel viewModel);
        IEnumerable<CategoryViewModel> GetAll();
        CategoryViewModel GetBy(string Id);
        CategoryEntity Update(CategoryViewModel viewModel);
        bool Delete(string Id);
    }
}
