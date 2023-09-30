using CloudPOS.Models;
using CloudPOS.Models.ViewModels;
using CloudPOS.UnitOfWorks;
namespace CloudPOS.Services
{
    public class CategoryService : ICategoryService
    {
        #region define the constructor and inject the UnitOfWork for db transactions
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region create process by doing  Data Transfer from viewModel to Entity
        public void Create(CategoryViewModel viewModel)
        {
           
            var categoryEntity = new CategoryEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Code = viewModel.Code,
                Description = viewModel.Description
            };
            _unitOfWork.CategoryRepository.Create(categoryEntity);
            _unitOfWork.Commit();
        }
        #endregion
        public void Delete(string Id)
        {
            var category = _unitOfWork.CategoryRepository.ReteriveBy(x => x.Id == Id).FirstOrDefault();
            if (category != null)
            {
                _unitOfWork.CategoryRepository.Delete(category);
                _unitOfWork.Commit();
            }
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            IList<CategoryViewModel> categories = _unitOfWork.CategoryRepository.ReteriveAll()
                                                .Select(s => new CategoryViewModel
                                                {
                                                    Id = s.Id,//to delete, update for UI actions (Delete,Edit/Update)
                                                    Code = s.Code,
                                                    Description = s.Description,
                                                    CreatedAt = s.CreatedAt
                                                }).ToList();
            return categories;
        }

        public CategoryViewModel GetBy(string Id)
        {
              return _unitOfWork.CategoryRepository.ReteriveBy(x=>x.Id== Id)
                                .Select(s=>new CategoryViewModel
                              {
                                  Id = s.Id,
                                  Code = s.Code,
                                  Description = s.Description
                              }).SingleOrDefault();
        }

        public void Update(CategoryViewModel viewModel)
        {
            //Data Transfer from viewModel to Entity
            var categoryEntity = new CategoryEntity()
            {
                Id = viewModel.Id,
                Code = viewModel.Code,
                Description = viewModel.Description,
                ModifiedAt = DateTime.Now
            };
            _unitOfWork.CategoryRepository.Update(categoryEntity);
            _unitOfWork.Commit();
        }
    }
}
