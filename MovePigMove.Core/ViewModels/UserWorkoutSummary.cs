using System.Collections.Generic;
using MovePigMove.Core.Entities;
using MovePigMove.Core.Queries;
using MovePigMove.Core.Storage;

namespace MovePigMove.Core.ViewModels
{
    public class UserWorkoutSummary : IViewFactory<string, IList<Workout>>
    {
        private readonly IWorkoutRepository _workoutRepository;
        
        public UserWorkoutSummary(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public IList<Workout> Load(string input)
        {
            return _workoutRepository.Where(new  Queries.PreviousWorkoutsQuery(input));
        }
    }
}