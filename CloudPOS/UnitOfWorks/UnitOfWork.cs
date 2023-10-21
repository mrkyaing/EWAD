using CloudPOS.DAO;
using CloudPOS.Repisitories.Domain;

namespace CloudPOS.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        #region define the constructor
        private readonly AppDbContext _appDbContext;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        #endregion

        #region define the itemRepository
        private IItemRepository _itemRepository;
        public IItemRepository ItemRepository
        {
            get 
            {
                return _itemRepository = _itemRepository ?? new ItemRepository(_appDbContext);
            }
        }
        #endregion

        #region define the categoryRepository
        private ICategoryRepository _categoryRepository;
        public ICategoryRepository CategoryRepository
        {
            get { return _categoryRepository = _categoryRepository ?? new CateogryRepository(_appDbContext); }
        }
        #endregion

        #region define the brandRepository
        private IBrandRepository _brandRepository;
        public IBrandRepository BrandRepository
        {
            get { return _brandRepository = _brandRepository ?? new BrandRepository(_appDbContext); }
        }

        #endregion

        #region define the StockInComeRepository
        private IStockInComeRepository _stockInComeRepository;
        public IStockInComeRepository StockInComeRepository
        {
            get { return _stockInComeRepository = _stockInComeRepository ?? new StockInComeRepository(_appDbContext); }
        }
        #endregion

        #region define the StockBalanceRepository
        private IStockBalanceRepository _stockBalanceRepository;
        public IStockBalanceRepository StockBalanceRepository
        {
            get { return _stockBalanceRepository = _stockBalanceRepository ?? new StockBalanceRepository(_appDbContext); }
        }
        #endregion

        #region define the transactions methods
        public void Commit()
        {
           _appDbContext.SaveChanges();
        }

        public void Rollback()
        {
            _appDbContext.Dispose();
        }
        #endregion
    }
}
