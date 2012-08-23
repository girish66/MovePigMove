using MovePigMove.Core.Documents;
using MovePigMove.Core.Entities;
using Raven.Client;

namespace MovePigMove.Core.Storage
{
    public interface IExerciseRepository : IRepository<Exercise, ExerciseDocument>
    {
         
    }

    public class ExerciseRepository : BaseRepository<Exercise, ExerciseDocument>, IExerciseRepository
    {
        public ExerciseRepository(IDocumentSession documentSession) : base(documentSession)
        {
        }

        protected override Exercise CreateFromDataModel(ExerciseDocument dataModel)
        {
            return new Exercise(dataModel);
        }
    }

    
}