using MovePigMove.Core.Documents;
using MovePigMove.Core.Entities;
using Raven.Client;

namespace MovePigMove.Core.Storage
{
    public interface IWorkoutRepository : IRepository<Workout, WorkoutDocument>{}

    public class WorkoutRepository : BaseRepository<Workout, WorkoutDocument>,  IWorkoutRepository{
        
        public WorkoutRepository(IDocumentSession documentSession) : base(documentSession)
        {
        }

        protected override Workout CreateFromDataModel(WorkoutDocument dataModel)
        {
            return new Workout(dataModel);
        }
    }
}