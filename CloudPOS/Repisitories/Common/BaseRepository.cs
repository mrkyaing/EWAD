using CloudPOS.DAO;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CloudPOS.Repisitories.Common
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet =_appDbContext.Set<T>();//will set the dbset for your entering entity model
        }
        public void Create(T entity)=>_appDbContext.Add<T>(entity);
        public IEnumerable<T> ReteriveAll()=> _dbSet.AsNoTracking().AsEnumerable();
        public IEnumerable<T> ReteriveBy(Expression<Func<T, bool>> expression)=> _dbSet.AsNoTracking().Where(expression).AsEnumerable();
        public void Update(T entity)=>_appDbContext.Update(entity);
        public void Delete(T entity)=>_appDbContext.Remove(entity);
    }
}
