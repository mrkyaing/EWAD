﻿using CloudPOS.Repisitories.Domain;

namespace CloudPOS.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IItemRepository ItemRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IBrandRepository BrandRepository { get; }
        void Commit();//insert,update,delete,reterive 
        void Rollback();//rollback process when CRUD process occur errors
    }
}