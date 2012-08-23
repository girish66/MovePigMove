using System.Collections.Generic;
using MovePigMove.Core.Commands;
using MovePigMove.Core.Storage;
using Raven.Abstractions.Extensions;

namespace MovePigMove.Core.CommandHandlers
{
    
    public class BootstrapCommandHandler : ICommandHandler<List<AddExerciseCommand>>
    {
        private AddExerciseCommandHandler _innerHandler;
        private IExerciseRepository _exerciseRepository;
        private IWorkoutRepository _workoutRepository;

        public BootstrapCommandHandler(AddExerciseCommandHandler innerHandler, IExerciseRepository exerciseRepository, IWorkoutRepository workoutRepository)
        {
            _innerHandler = innerHandler;
            _exerciseRepository = exerciseRepository;
            _workoutRepository = workoutRepository;
        }

        public void Handle(List<AddExerciseCommand> command)
        {
            //delete existing data via the worst possible way
            var existing = _exerciseRepository.List();
            existing.ForEach(_exerciseRepository.Remove);

            var workouts = _workoutRepository.List();
            workouts.ForEach(_workoutRepository.Remove);

            //insert new crap
            command.ForEach(_innerHandler.Handle);
        }
    }

    
}