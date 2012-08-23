using System;
using System.Collections.Generic;
using MovePigMove.Core.Entities;

namespace MovePigMove.Core.ViewModels
{
    public class WorkoutSummaryViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<CardioSegment> Cardio { get; set; }
        public List<StrengthSegment> Strength { get; set; }

        public string Elapsed
        {
            get
            {

                DateTime end = EndDate.HasValue ? EndDate.Value : DateTime.Now;

                var ts = (end - StartDate);
                return "{0} hours {1} minutes".ToFormat(ts.Hours, ts.Minutes);                    

            }
        }

        public bool PromptForEnd
        {
            get { return !EndDate.HasValue; }
        }

    }
}