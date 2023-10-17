using CloudPOS.DAO;
using CloudPOS.Models;
using CloudPOS.Repisitories.Common;

namespace CloudPOS.Repisitories.Domain
{
    public class StockInComeRepository : BaseRepository<StockInComeEntity>, IStockInComeRepository
    {
        public StockInComeRepository(AppDbContext appContext):base(appContext)
        {
        }
        //code your custom implemenation for item functions 
    }
}
