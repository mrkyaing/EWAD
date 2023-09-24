using CloudPOS.DAO;
using CloudPOS.Models;
using CloudPOS.Repisitories.Common;

namespace CloudPOS.Repisitories.Domain
{
    public class ItemRepository:BaseRepository<ItemEntity>, IItemRepository
    {
        public ItemRepository(AppDbContext appContext):base(appContext)
        {
        }
        //code your custom implemenation for item functions 
    }
}
