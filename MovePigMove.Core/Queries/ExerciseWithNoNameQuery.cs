using MovePigMove.Core.Entities;
using MovePigMove.Core.Storage;

namespace MovePigMove.Core.Queries
{
    public class ExerciseWithNoNameQuery : Query<Exercise>
    {
        public override bool IsMatch(Exercise entity)
        {
            return string.IsNullOrWhiteSpace(entity.Description);
        }
    }
}