using MovePigMove.Core.Commands;
using MovePigMove.Core.Storage;

namespace MovePigMove.Core.CommandHandlers
{
    public class UpdateExerciseCommandHandler : ICommandHandler<UpdateExerciseCommand>
    {
        private IExerciseRepository _repository;

        public UpdateExerciseCommandHandler(IExerciseRepository repository)
        {
            _repository = repository;
        }

        public void Handle(UpdateExerciseCommand command)
        {
            var current = _repository.Load(command.Id);
            current.ChangeDescription(command.Description);
            current.ChangeExerciseType(command.Type);
        }
    }
}