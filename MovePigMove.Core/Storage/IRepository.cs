using System.Collections.Generic;
using MovePigMove.Core.Entities;

namespace MovePigMove.Core.Storage
{
    public interface IRepository<TEntity, TDataModel>  where TEntity : IDomainEntity<TDataModel>
    {
        void Add(TEntity item);
        void Remove(TEntity item);
        TEntity Load(int id);
        IList<TEntity> List();
        IList<TEntity> Where(Query<TEntity> criteria);
    }
}