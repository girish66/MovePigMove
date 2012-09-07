using MovePigMove.Core.Entities;

namespace MovePigMove.Core.Queries
{
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