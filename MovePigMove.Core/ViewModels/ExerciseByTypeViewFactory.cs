using System.Collections.Generic;
using MovePigMove.Core.Entities;
using MovePigMove.Core.Queries;
using MovePigMove.Core.Storage;

namespace MovePigMove.Core.ViewModels
{
    public class ExerciseByTypeViewFactory : IViewFactory<ExerciseType, IList<Exercise>>
    {
        private IExerciseRepository _exerciseRepository;

        public ExerciseByTypeViewFactory(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public IList<Exercise> Load(ExerciseType input)
        {
            return _exerciseRepository.Where(new ExerciseTypeQuery(input));
        }
    }
}