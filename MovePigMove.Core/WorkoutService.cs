using System.Collections.Generic;
using System.Linq;
using MovePigMove.Core.CommandHandlers;
using MovePigMove.Core.Commands;
using MovePigMove.Core.Entities;
using MovePigMove.Core.Queries;
using MovePigMove.Core.Storage;

namespace MovePigMove.Core
{
    public interface IWorkoutService
    {
        Workout CurrentWorkout();
        void BeginNew();
    }

    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _repository;
        private readonly ICommandInvoker _commandInvoker;

        public WorkoutService(IWorkoutRepository repository, ICommandInvoker commandInvoker)
        {
            _repository = repository;
            _commandInvoker = commandInvoker;
        }

        public Workout CurrentWorkout()
        {
            var query = new OpenWorkoutQuery();
            var current = _repository.Where(query) ?? new List<Workout>();
            return current.SingleOrDefault();
        }

        public void BeginNew()
        {
            var command = new BeginWorkoutCommand();
            _commandInvoker.Execute(command);
        }

    }
}