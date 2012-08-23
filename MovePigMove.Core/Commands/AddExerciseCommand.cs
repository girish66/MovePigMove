using MovePigMove.Core.Entities;

namespace MovePigMove.Core.Commands
{
    public class AddExerciseCommand
    {
        public string Description { get; private set; }
        public ExerciseType Type { get; private set; }

        public AddExerciseCommand(string description, ExerciseType type)
        {
            Description = description;
            Type = type;
        }
    }
}