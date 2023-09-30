using CloudPOS.Models.ViewModels;

namespace CloudPOS.Services
{
    public interface IBrandService
    {
        void Create(BrandViewModel viewModel);
        IEnumerable<BrandViewModel> GetAll();
        BrandViewModel GetBy(string Id);
        void Update(BrandViewModel viewModel);
        void Delete(string Id);
    }
}
