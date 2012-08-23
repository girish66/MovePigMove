using MovePigMove.Core.Commands;
using MovePigMove.Core.Documents;
using MovePigMove.Core.Entities;
using MovePigMove.Core.Storage;

namespace MovePigMove.Core.CommandHandlers
{
    public class BeginWorkoutCommandHandler : ICommandHandler<BeginWorkoutCommand>
    {
        private readonly IWorkoutRepository _workoutRepository;

        public BeginWorkoutCommandHandler(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public void Handle(BeginWorkoutCommand command)
        {
            var dataModel = new WorkoutDocument {StartDate = command.StartDate};
            _workoutRepository.Add(new Workout(dataModel));
        }
    }
}