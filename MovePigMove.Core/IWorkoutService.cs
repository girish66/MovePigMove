using MovePigMove.Core.Entities;

namespace MovePigMove.Core
{
    public interface IWorkoutService
    {
        Workout CurrentWorkout();
        void BeginNew();
    }
}