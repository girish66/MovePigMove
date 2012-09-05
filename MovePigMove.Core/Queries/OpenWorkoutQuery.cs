using MovePigMove.Core.Entities;
using MovePigMove.Core.Storage;

namespace MovePigMove.Core.Queries
{
    public class OpenWorkoutQuery : Query<Workout>
    {
        private readonly string _userId;

        public OpenWorkoutQuery(string userId)
        {
            _userId = userId;
        }

        public override bool IsMatch(Workout entity)
        {
            return
                entity.EndDate.HasValue == false && entity.UserId == _userId;
        }
    }
}