using System;
using System.Linq;
using System.Collections.Generic;
using MovePigMove.Core.Documents;
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
            return List().Where(query.IsMatch).ToList();
        }

        protected abstract TEntity CreateFromDataModel(TDataModel dataModel);
    }

    public abstract class Query<TEntity> 
    {
        public abstract bool IsMatch(TEntity entity);
    }

    public class ExerciseWithNoNameQuery : Query<Exercise>
    {
        public override bool IsMatch(Exercise entity)
        {
            return string.IsNullOrWhiteSpace(entity.Description);
        }
    }

    public class ExerciseTypeQuery : Query<Exercise>
    {
        private ExerciseType _exerciseType;

        public ExerciseTypeQuery(ExerciseType exerciseType)
        {
            _exerciseType = exerciseType;
        }

        public override bool IsMatch(Exercise entity)
        {
            return entity.ExerciseType == _exerciseType;
        }
    }

    public class FindUserByUserNameQuery : Query<UserProfile>
    {
        private readonly string _userName;

        public FindUserByUserNameQuery(string userName)
        {
            this._userName = userName;
        }

        public override bool IsMatch(UserProfile entity)
        {
            return entity.UserName.Equals(_userName, StringComparison.InvariantCultureIgnoreCase);
        }
    }

    public class FindUserByProviderAndProviderIdQuery : Query<UserProfile>
    {
        private string _providerName;
        private string _providerUserId;

        public FindUserByProviderAndProviderIdQuery(string providerName, string providerUserId)
        {
            _providerName = providerName;
            _providerUserId = providerUserId;
        }

        public override bool IsMatch(UserProfile entity)
        {
            return entity.ProviderName.Equals(_providerName, StringComparison.InvariantCultureIgnoreCase) &&
                   entity.ProviderUserId.Equals(_providerUserId);
        }
    }

}