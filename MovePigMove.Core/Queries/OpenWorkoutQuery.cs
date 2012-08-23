using MovePigMove.Core.Entities;
using MovePigMove.Core.Storage;

namespace MovePigMove.Core.Queries
{
    public class OpenWorkoutQuery : Query<Workout>
    {
        public override bool IsMatch(Workout entity)
        {
            return entity.EndDate.HasValue == false;
        }
    }
}