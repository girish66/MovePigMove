using System.Linq;
using MovePigMove.Core.Storage;

namespace MovePigMove.Core.ViewModels
{
    public class WorkoutSummaryViewFactory : IViewFactory<int, WorkoutSummaryViewModel>
    {
        private IWorkoutRepository _workoutRepository;

        public WorkoutSummaryViewFactory(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public WorkoutSummaryViewModel Load(int input)
        {
            var wk = _workoutRepository.Load(input);

            return new WorkoutSummaryViewModel
                {
                    Cardio = wk.CardioSegments.ToList(),
                    Strength = wk.StrengthSegments.ToList(),
                    EndDate = wk.EndDate,
                    StartDate = wk.StartDate,
                };

        }
    }
}