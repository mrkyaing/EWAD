using CloudPOS.DAO;
using CloudPOS.Models;
using CloudPOS.Repisitories.Common;

namespace CloudPOS.Repisitories.Domain
{
    public class SaleDetailRepository : BaseRepository<SaleDetailEntity>, ISaleDetailRepository
    {
        public SaleDetailRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
