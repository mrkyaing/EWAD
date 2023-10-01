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

        public void Delete(string Id)
        {
            var item=_unitOfWork.ItemRepository.ReteriveBy(x=>x.Id==Id).FirstOrDefault();
            if (item != null)
            { 
                _unitOfWork.ItemRepository.Delete(item); 
                _unitOfWork.Commit(); 
            }
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
                CreatedAt=s.CreatedAt,
                //s.Brand.name,
                BrandInfo=_unitOfWork.BrandRepository.ReteriveBy(r=>r.Id==s.BrandId).FirstOrDefault().Name,
                CategoryInfo= _unitOfWork.CategoryRepository.ReteriveBy(r => r.Id == s.CategoryId).FirstOrDefault().Description
            }).OrderBy(o=>o.ItemCode);
        }

        public ItemViewModel GetBy(string Id)
        {
            return _unitOfWork.ItemRepository.ReteriveBy(x => x.Id.Equals(Id))
                .Select(s=>new ItemViewModel
                {
                    Id=s.Id,
                    ItemCode=s.ItemCode,
                    ItemDescription=s.ItemDescription,
                    SalePrice=s.SalePrice,
                    PurchasePrice=s.PurchasePrice,
                    CategoryId=s.CategoryId,
                    BrandId=s.BrandId,
                    CreatedAt=s.CreatedAt,
                    BrandInfo = _unitOfWork.BrandRepository.ReteriveBy(r => r.Id == s.BrandId).FirstOrDefault().Name,
                    CategoryInfo = _unitOfWork.CategoryRepository.ReteriveBy(r => r.Id == s.CategoryId).FirstOrDefault().Description
                }).SingleOrDefault();
        }

        public void Update(ItemViewModel itemViewModel)
        {
            var itemEntity = new ItemEntity()
            {
                Id = itemViewModel.Id,
                ItemCode = itemViewModel.ItemCode,
                ItemDescription = itemViewModel.ItemDescription,
                SalePrice = itemViewModel.SalePrice,
                PurchasePrice = itemViewModel.PurchasePrice,
                BrandId = itemViewModel.BrandId,
                CategoryId = itemViewModel.CategoryId,
            };
            _unitOfWork.ItemRepository.Update(itemEntity);//collect the records with repository
            _unitOfWork.Commit();//update the records to the database  
        }
    }
}
