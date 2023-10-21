using CloudPOS.DAO;
using CloudPOS.Models;
using CloudPOS.Repisitories.Common;

namespace CloudPOS.Repisitories.Domain
{
    public class StockBalanceRepository : BaseRepository<StockBalanceEntity>, IStockBalanceRepository
    {
        public StockBalanceRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
