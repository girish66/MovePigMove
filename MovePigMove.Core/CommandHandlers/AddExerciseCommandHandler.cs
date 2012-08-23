using MovePigMove.Core.Commands;
using MovePigMove.Core.Documents;
using MovePigMove.Core.Entities;
using MovePigMove.Core.Storage;

namespace MovePigMove.Core.CommandHandlers
{
    public class AddExerciseCommandHandler : ICommandHandler<AddExerciseCommand>
    {
        private readonly IExerciseRepository _exerciseRepository;

        public AddExerciseCommandHandler(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public void Handle(AddExerciseCommand command)
        {
            var dataModel = new ExerciseDocument {Description = command.Description, ExerciseType = command.Type};
            _exerciseRepository.Add(new Exercise(dataModel));
        }
    }
}