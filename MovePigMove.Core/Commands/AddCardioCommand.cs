namespace MovePigMove.Core.Commands
{
    public class AddCardioCommand
    {
        public string ExerciseId { get; set; }
        public string Notes { get; set; }
        public int Duration { get; set; }
        public int Level { get; set; }
    }
}