using CloudPOS.DAO;
using CloudPOS.Models;
using CloudPOS.Repisitories.Common;

namespace CloudPOS.Repisitories.Domain
{
    public class SaleRepository : BaseRepository<SaleEntity>, ISaleRepository
    {
        public SaleRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
