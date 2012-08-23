using System;
using System.Collections.Generic;
using MovePigMove.Core.Entities;

namespace MovePigMove.Core.Documents
{
    public class WorkoutDocument
    {
        public DateTime? EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public int Id { get; set; }
        public List<CardioSegment> Cardio { get; set; }
        public List<StrengthSegment> Strength { get; set; }

        public WorkoutDocument()
        {
            Cardio = new List<CardioSegment>();
            Strength = new List<StrengthSegment>();
        }
    }
}