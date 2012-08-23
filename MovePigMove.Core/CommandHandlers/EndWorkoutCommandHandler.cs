using MovePigMove.Core.Commands;

namespace MovePigMove.Core.CommandHandlers
{
    public class EndWorkoutCommandHandler : ICommandHandler<EndWorkoutCommand>
    {
        private IWorkoutService _workoutService;

        public EndWorkoutCommandHandler(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        public void Handle(EndWorkoutCommand command)
        {
            _workoutService.CurrentWorkout().SetEndDate(command.EndDate);
        }
    }
}