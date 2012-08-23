using MovePigMove.Core.Documents;

namespace MovePigMove.Core.Entities
{
    public class Exercise : IDomainEntity<ExerciseDocument>
    {
        private ExerciseDocument _dataModel;

        public Exercise(ExerciseDocument dataModel)
        {
            _dataModel = dataModel;
        }

        public string Description { get { return _dataModel.Description; }}
        public ExerciseType ExerciseType { get { return _dataModel.ExerciseType; } }
        public int Id { get { return _dataModel.Id; } }


        public ExerciseDocument GetInnerModel()
        {
            return _dataModel;
        }

        public void ChangeDescription(string description)
        {
            _dataModel.Description = description;
        }

        public void ChangeExerciseType(ExerciseType type)
        {
            _dataModel.ExerciseType = type;
        }

    }
}