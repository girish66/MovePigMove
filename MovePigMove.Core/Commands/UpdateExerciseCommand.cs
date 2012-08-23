using MovePigMove.Core.Entities;

namespace MovePigMove.Core.Commands
{
    public class UpdateExerciseCommand
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public ExerciseType Type { get; private set; }

        public UpdateExerciseCommand(int id, string description, ExerciseType type)
        {
            Id = id;
            Description = description;
            Type = type;
        }
    }
}