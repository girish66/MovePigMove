using MovePigMove.Core.Entities;

namespace MovePigMove.Core.Documents
{
    public class ExerciseDocument
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ExerciseType ExerciseType { get; set; }

    }
}