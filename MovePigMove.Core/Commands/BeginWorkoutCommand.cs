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
}