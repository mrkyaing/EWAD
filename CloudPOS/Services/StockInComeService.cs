using CloudPOS.Models;
using CloudPOS.Models.ViewModels;
using CloudPOS.UnitOfWorks;

namespace CloudPOS.Services
{
    public class StockInComeService : IStockInComeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StockInComeService(IUnitOfWork unitOfWork)=>_unitOfWork = unitOfWork;
        public void Create(StockInComeViewModel StockInComeViewModel)
        {
            var StockInComeEntity = new StockInComeEntity()
            {
                Id=Guid.NewGuid().ToString(),
                IncomedDate= StockInComeViewModel.IncomedDate,
                ItemId=StockInComeViewModel.ItemId,
                Qty=StockInComeViewModel.Qty
            };
            _unitOfWork.StockInComeRepository.Create(StockInComeEntity);//collect the records with repository
            _unitOfWork.Commit();//saving the records to the database 
        }

        public void Delete(string Id)
        {
            var item=_unitOfWork.StockInComeRepository.ReteriveBy(x=>x.Id==Id).FirstOrDefault();
            if (item != null)
            { 
                _unitOfWork.StockInComeRepository.Delete(item); 
                _unitOfWork.Commit(); 
            }
        }

        public IEnumerable<StockInComeViewModel> GetAll()
        {
            return _unitOfWork.StockInComeRepository.ReteriveAll().Select(s=>new StockInComeViewModel
            {
                Id = s.Id,
                IncomedDate = s.IncomedDate,
                ItemId = s.ItemId,
                Qty = s.Qty
                //BrandInfo =_unitOfWork.BrandRepository.ReteriveBy(r=>r.Id==s.BrandId).FirstOrDefault().Name,
                //CategoryInfo= _unitOfWork.CategoryRepository.ReteriveBy(r => r.Id == s.CategoryId).FirstOrDefault().Description
            }).OrderBy(o=>o.IncomedDate);
        }

        public StockInComeViewModel GetBy(string Id)
        {
            return _unitOfWork.StockInComeRepository.ReteriveBy(x => x.Id.Equals(Id))
                .Select(s=>new StockInComeViewModel
                {
                    Id = s.Id,
                    IncomedDate = s.IncomedDate,
                    ItemId = s.ItemId,
                    Qty = s.Qty
                   // BrandInfo = _unitOfWork.BrandRepository.ReteriveBy(r => r.Id == s.BrandId).FirstOrDefault().Name,
                    //CategoryInfo = _unitOfWork.CategoryRepository.ReteriveBy(r => r.Id == s.CategoryId).FirstOrDefault().Description
                }).SingleOrDefault();
        }

        public void Update(StockInComeViewModel StockInComeViewModel)
        {
            var StockInComeEntity = new StockInComeEntity()
            {
                Id = StockInComeViewModel.Id,
                IncomedDate = StockInComeViewModel.IncomedDate,
                ItemId = StockInComeViewModel.ItemId,
                Qty = StockInComeViewModel.Qty
            };
            _unitOfWork.StockInComeRepository.Update(StockInComeEntity);//collect the records with repository
            _unitOfWork.Commit();//update the records to the database  
        }
    }
}
