using System;
using MovePigMove.Core.Commands;
using MovePigMove.Core.Entities;

namespace MovePigMove.Core.CommandHandlers
{
    public class AddStrengthCommandHandler : ICommandHandler<AddStrengthCommand>
    {
        private readonly IWorkoutService _workoutService;

        public AddStrengthCommandHandler(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        public void Handle(AddStrengthCommand command)
        {
            var wk = _workoutService.CurrentWorkout();

            if (wk == null) throw new ApplicationException("No current workout");

            wk.AddStrengthSegment(new StrengthSegment(command.ExerciseId, command.Weight, command.Repetitions, command.Notes));
        }
    }
}