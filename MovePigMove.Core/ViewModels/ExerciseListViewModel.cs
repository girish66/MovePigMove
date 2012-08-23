using System.Collections.Generic;
using MovePigMove.Core.Entities;

namespace MovePigMove.Core.ViewModels
{
    public class ExerciseListViewModel
    {
        public List<Exercise> ExerciseList { get; set; }
        public AddExerciseInputModel AddExerciseInput { get; set; }

    }
}