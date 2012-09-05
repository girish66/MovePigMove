using System;

namespace MovePigMove.Core.Commands
{
    public class EndWorkoutCommand
    {
        public DateTime EndDate  {get;set;}

        public EndWorkoutCommand()
        {
            EndDate = DateTime.Now;
        }
    }
}