using System;

namespace MovePigMove.Core.Entities
{
    public class StrengthSegment
    {
        public DateTime PerformedAt { get; private set; }
        public string ExerciseId { get; private set; }
        public int Weight { get; set; }
        public int Repetitions { get; set; }
        public string Notes { get; private set; }

        public StrengthSegment(string exerciseId, int weight, int repetitions, string notes = "")
        {
            ExerciseId = exerciseId;
            Weight = weight;
            Repetitions = repetitions;
            Notes = notes;
            PerformedAt = DateTime.Now;
        }
    }
}