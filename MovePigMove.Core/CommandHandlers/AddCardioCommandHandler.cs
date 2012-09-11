using System;
using MovePigMove.Core.Commands;
using MovePigMove.Core.Entities;
using MovePigMove.Core.Storage;

namespace MovePigMove.Core.CommandHandlers
{
    public class AddCardioCommandHandler : ICommandHandler<AddCardioCommand>
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IWorkoutService _workoutService;

        public AddCardioCommandHandler(IWorkoutService workoutService, IExerciseRepository exerciseRepository)
        {
            _workoutService = workoutService;
            _exerciseRepository = exerciseRepository;
        }

        public void Handle(AddCardioCommand command)
        {
            var wk = _workoutService.CurrentWorkout();
            var ex = _exerciseRepository.Load(command.ExerciseId);

            if (wk == null) throw new ApplicationException("No current workout");


            wk.AddCardioSegment(new CardioSegment(command.ExerciseId, ex.Description, command.Duration, command.Level, command.Notes));
        }
    }
}