using System.Collections.Generic;
using System.Linq;
using MovePigMove.Core.Entities;
using MovePigMove.Core.Storage;

namespace MovePigMove.Core.ViewModels
{
    public class ExerciseListViewFactory : IViewFactory<AddExerciseInputModel, ExerciseListViewModel>
    {
        private IExerciseRepository _exerciseRepository;

        public ExerciseListViewFactory(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public ExerciseListViewModel Load(AddExerciseInputModel input)
        {
            var exerices = _exerciseRepository.List()
                .OrderBy(e => e.ExerciseType)
                .ThenBy(e => e.Description)
                .ToList();

            return new ExerciseListViewModel
                {
                    ExerciseList = exerices,
                    AddExerciseInput = input
                };
        }
    }


}