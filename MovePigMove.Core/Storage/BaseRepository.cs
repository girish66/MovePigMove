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

        public BaseRepository(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        public void Add(TEntity item)
        {
            _documentSession.Store(item.GetInnerModel());
        }

        public void Remove(TEntity item)
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

}