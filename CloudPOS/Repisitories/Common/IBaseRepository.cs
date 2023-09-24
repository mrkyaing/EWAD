using System.Linq.Expressions;

namespace CloudPOS.Repisitories.Common
{
    public interface IBaseRepository<T> where T:class
    {
        //CRUD Process 
        void Create(T entity);// Create process for entering Entity 
        IEnumerable<T> ReteriveAll();// reverive process for entering Entity 
        IEnumerable<T> ReteriveBy(Expression<Func<T,bool>> expression);//reverive process for condition 
        void Update(T entity);// Update process for entering Entity 
        void Delete(T entity);// Delete process for entering Entity 
    }
}
