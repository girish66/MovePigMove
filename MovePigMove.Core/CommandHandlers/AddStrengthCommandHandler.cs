using System;
using MovePigMove.Core.Commands;
using MovePigMove.Core.Entities;
using MovePigMove.Core.Storage;

namespace MovePigMove.Core.CommandHandlers
{
    public class AddStrengthCommandHandler : ICommandHandler<AddStrengthCommand>
    {
        private readonly IWorkoutService _workoutService;
        private readonly IExerciseRepository _exerciseRepository;

        public AddStrengthCommandHandler(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        public void Handle(AddStrengthCommand command)
        {
            var wk = _workoutService.CurrentWorkout();
            var ex = _exerciseRepository.Load(command.ExerciseId);

            if (wk == null) throw new ApplicationException("No current workout");
            wk.AddStrengthSegment(new StrengthSegment(command.ExerciseId, ex.Description, command.Weight, command.Repetitions, command.Notes));
        }
    }
}