using MovePigMove.Core.Entities;

namespace MovePigMove.Core.Queries
{
    public class PreviousWorkoutsQuery : Query<Workout>
    {
        private string _userId;

        public PreviousWorkoutsQuery(string userId)
        {
            _userId = userId;
        }

        public override bool IsMatch(Workout entity)
        {
            return entity.EndDate.HasValue && entity.UserId.Equals(_userId);
        }
    }
}