using CloudPOS.DAO;
using CloudPOS.Models;
using CloudPOS.Repisitories.Common;

namespace CloudPOS.Repisitories.Domain
{
    public class BrandRepository:BaseRepository<BrandEntity>, IBrandRepository
    {
        public BrandRepository(AppDbContext appContext):base(appContext)
        {
        }
        //code your custom implemenation for brand functions 
    }
}