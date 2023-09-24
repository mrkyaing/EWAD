using CloudPOS.DAO;
using CloudPOS.Repisitories.Domain;

namespace CloudPOS.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        private IItemRepository _itemRepository;
        public IItemRepository ItemRepository
        {
            get 
            {
                return _itemRepository = _itemRepository ?? new ItemRepository(_appDbContext);
            }
        }
        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Commit()
        {
           _appDbContext.SaveChanges();
        }

        public void Rollback()
        {
            _appDbContext.Dispose();
        }
    }
}
