using CloudPOS.Models;
using CloudPOS.Models.ViewModels;
using CloudPOS.UnitOfWorks;

namespace CloudPOS.Services
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ItemService(IUnitOfWork unitOfWork)=>_unitOfWork = unitOfWork;
        public void Create(ItemViewModel itemViewModel)
        {
            //Data Transfer from view model to entity to store the recrod to the database!!
            var itemEntity = new ItemEntity()
            {
                Id=Guid.NewGuid().ToString(),
                ItemCode= itemViewModel.ItemCode,
                ItemDescription=itemViewModel.ItemDescription,
                SalePrice=itemViewModel.SalePrice,
                PurchasePrice=itemViewModel.PurchasePrice,
                BrandId=itemViewModel.BrandId,
                CategoryId=itemViewModel.CategoryId,
            };
            _unitOfWork.ItemRepository.Create(itemEntity);//collect the records with repository
            _unitOfWork.Commit();//saving the records to the database 
        }

        public void Delete(ItemViewModel itemViewModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemViewModel> GetAll()
        {
            return _unitOfWork.ItemRepository.ReteriveAll().Select(s=>new ItemViewModel
            {
                Id = s.Id,
                ItemCode=s.ItemCode,
                ItemDescription=s.ItemDescription,
                SalePrice=s.SalePrice,
                PurchasePrice=s.PurchasePrice,
                //s.Brand.name,
                BrandInfo=_unitOfWork.BrandRepository.ReteriveBy(r=>r.Id==s.BrandId).FirstOrDefault().Name,
                CategoryInfo= _unitOfWork.CategoryRepository.ReteriveBy(r => r.Id == s.CategoryId).FirstOrDefault().Description,
            }).OrderBy(o=>o.ItemCode);
        }
        public void Update(ItemViewModel itemViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
