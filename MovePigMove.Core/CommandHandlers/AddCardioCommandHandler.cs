using System;
using MovePigMove.Core.Commands;
using MovePigMove.Core.Entities;

namespace MovePigMove.Core.CommandHandlers
{
    public class AddCardioCommandHandler : ICommandHandler<AddCardioCommand>
    {
        private readonly IWorkoutService _workoutService;

        public AddCardioCommandHandler(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        public void Handle(AddCardioCommand command)
        {
            var wk = _workoutService.CurrentWorkout();

            if (wk == null) throw new ApplicationException("No current workout");

            wk.AddCardioSegment(new CardioSegment(command.ExerciseId, command.Duration, command.Level, command.Notes));
        }
    }
}