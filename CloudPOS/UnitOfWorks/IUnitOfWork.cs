using CloudPOS.Repisitories.Domain;

namespace CloudPOS.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IItemRepository ItemRepository { get; }
        void Commit();//insert,update,delete
        void Rollback();//rollback process when CRUD process occur errors
    }
}
