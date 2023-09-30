using CloudPOS.Models;
using CloudPOS.Models.ViewModels;
using CloudPOS.UnitOfWorks;

namespace CloudPOS.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BrandService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(BrandViewModel viewModel)
        {
            var entity = new BrandEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Code = viewModel.Code,
                Name = viewModel.Name
            };
            _unitOfWork.BrandRepository.Create(entity);
            _unitOfWork.Commit();
        }
        public void Delete(string Id)
        {
            var category = _unitOfWork.CategoryRepository.ReteriveBy(x => x.Id == Id).FirstOrDefault();
            if (category != null)
            {
                _unitOfWork.CategoryRepository.Delete(category);
                _unitOfWork.Commit();
            }
        }
        public IEnumerable<BrandViewModel> GetAll()
        {
            IList<BrandViewModel> brands = _unitOfWork.BrandRepository.ReteriveAll()
                .Select(s => new BrandViewModel
            {
                Id = s.Id,//to delete, update for UI actions (Delete,Edit/Update)
                Code = s.Code,
                Name = s.Name,
                ManufacturedCompany = s.ManufacturedCompany,
                CreatedAt = s.CreatedAt
            }).ToList();
            return brands;
        }

        public BrandViewModel GetBy(string Id)
        {
            var viewModel =_unitOfWork.BrandRepository.ReteriveBy(x => x.Id == Id)
                                       .Select(s => new BrandViewModel
                                       {
                                           Id = s.Id,
                                           Code = s.Code,
                                           Name = s.Name,
                                           ManufacturedCompany = s.ManufacturedCompany
                                       }).FirstOrDefault(); 
            return viewModel;
        }
        public void Update(BrandViewModel viewModel)
        {
            var entity = new BrandEntity()
            {
                Id = viewModel.Id,
                Code = viewModel.Code,
                Name = viewModel.Name,
                ManufacturedCompany = viewModel.ManufacturedCompany,
                ModifiedAt = DateTime.Now
            };
            _unitOfWork.BrandRepository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}
