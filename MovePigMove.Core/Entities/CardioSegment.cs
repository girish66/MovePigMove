using System;

namespace MovePigMove.Core.Entities
{
    public class CardioSegment
    {
        public DateTime PerformedAt { get; private set; }
        public int ExerciseId { get; private set; }
        public string ExerciseDescription { get; private set; }
        public int Duration { get; private set; }
        public int Level { get; private set; }
        public string Notes { get; private set; }

        public CardioSegment(int exerciseId, string exerciseDescription, int duration, int level, string notes = "")
        {
            ExerciseId = exerciseId;
            ExerciseDescription = exerciseDescription;
            Duration = duration;
            Level = level;
            Notes = notes;
            PerformedAt = DateTime.Now;
        }
    }
}