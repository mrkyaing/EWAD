using CloudPOS.Repisitories.Domain;

namespace CloudPOS.UnitOfWorks
{
    public interface IUnitOfWork
    {  
        ICategoryRepository CategoryRepository { get; }     
        IBrandRepository BrandRepository { get; }
        IItemRepository ItemRepository { get; }
        IStockInComeRepository StockInComeRepository { get; }
        IStockBalanceRepository StockBalanceRepository { get; }
        ISaleRepository SaleRepository { get; }
        ISaleDetailRepository SaleDetailRepository { get; }
        void Commit();//insert,update,delete,reterive 
        void Rollback();//rollback process when CRUD process occur errors
    }
}
