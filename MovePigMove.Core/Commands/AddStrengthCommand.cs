namespace MovePigMove.Core.Commands
{
    public class AddStrengthCommand
    {
        public int ExerciseId { get; set; }
        public int Weight { get; set; }
        public int Repetitions { get; set; }
        public string Notes { get; set; }
    }
}