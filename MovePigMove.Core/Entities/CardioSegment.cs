using System;

namespace MovePigMove.Core.Entities
{
    public class CardioSegment
    {
        public DateTime PerformedAt { get; private set; }
        public string ExerciseId { get; private set; }
        public int Duration { get; private set; }
        public int Level { get; private set; }
        public string Notes { get; private set; }

        public CardioSegment(string exerciseId, int duration, int level, string notes = "")
        {
            ExerciseId = exerciseId;
            Duration = duration;
            Level = level;
            Notes = notes;
            PerformedAt = DateTime.Now;
        }
    }
}