using System;
using System.Linq;
using System.Collections.Generic;
using MovePigMove.Core.Documents;
using MovePigMove.Core.Queries;
using Raven.Client;
using MovePigMove.Core.Entities;


namespace MovePigMove.Core.Storage
{
    public abstract class BaseRepository<TEntity, TDataModel> : IRepository<TEntity, TDataModel>  where TEntity : IDomainEntity<TDataModel>
    {
        private IDocumentSession _documentSession;

        protected IDocumentSession DocumentSession
        {
            get { return _documentSession; }
        }

        public BaseRepository(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        public void Add(TEntity item)
        {
            _documentSession.Store(item.GetInnerModel());
        }

        public virtual void Remove(TEntity item)
        {
            _documentSession.Delete(item.GetInnerModel());
        }

        public TEntity Load(string id)
        {
            return CreateFromDataModel(_documentSession.Load<TDataModel>(id));
        }

        public TEntity Load(int id)
        {
            var document = _documentSession.Load<TDataModel>(id);
            return CreateFromDataModel(document);
        }

        public IList<TEntity> List()
        {
            var documents = _documentSession.Query<TDataModel>();
            return documents.Select(CreateFromDataModel).ToList();
        }

        public IList<TEntity> Where(Query<TEntity> query)
        {
            var list = List();
            var match = list.Where(query.IsMatch);
            return match.ToList();
        }

        protected abstract TEntity CreateFromDataModel(TDataModel dataModel);
    }
}