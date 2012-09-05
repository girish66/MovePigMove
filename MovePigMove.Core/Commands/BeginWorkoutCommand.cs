using System;

namespace MovePigMove.Core.Commands
{
    public class BeginWorkoutCommand
    {
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }

        public BeginWorkoutCommand(string userId)
        {
            UserId = userId;
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