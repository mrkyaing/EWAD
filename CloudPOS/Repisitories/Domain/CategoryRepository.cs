using CloudPOS.DAO;
using CloudPOS.Models;
using CloudPOS.Repisitories.Common;

namespace CloudPOS.Repisitories.Domain
{
    public class CateogryRepository:BaseRepository<CategoryEntity>, ICategoryRepository
    {
        public CateogryRepository(AppDbContext appContext):base(appContext)
        {
        }
        //code your custom implemenation for category functions 
    }
}
