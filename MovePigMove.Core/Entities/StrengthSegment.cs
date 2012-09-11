using System;

namespace MovePigMove.Core.Entities
{
    public class StrengthSegment
    {
        public DateTime PerformedAt { get; private set; }
        public int ExerciseId { get; private set; }
        public string ExerciseDescription { get; set; }
        public int Weight { get; set; }
        public int Repetitions { get; set; }
        public string Notes { get; private set; }

        public StrengthSegment(int exerciseId, string exerciseDescription, int weight, int repetitions, string notes = "")
        {
            ExerciseId = exerciseId;
            ExerciseDescription = exerciseDescription;
            Weight = weight;
            Repetitions = repetitions;
            Notes = notes;
            PerformedAt = DateTime.Now;
        }
    }
}