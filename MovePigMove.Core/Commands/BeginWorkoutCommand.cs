using System;

namespace MovePigMove.Core.Commands
{
    public class BeginWorkoutCommand
    {
        public DateTime StartDate { get; set; }

        public BeginWorkoutCommand()
        {
            StartDate = DateTime.Now;
        }
    }

    public class EndWorkoutCommand
    {
        public DateTime EndDate  {get;set;}

        public EndWorkoutCommand()
        {
            EndDate = DateTime.Now;
        }
    }
}