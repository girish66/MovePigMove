using System;
using System.Collections.Generic;
using MovePigMove.Core.Documents;

namespace MovePigMove.Core.Entities
{
    public class Workout : IDomainEntity<WorkoutDocument>
    {
        private readonly WorkoutDocument _dataModel;

        public Workout(WorkoutDocument dataModel)
        {
            _dataModel = dataModel;
        }

        public DateTime?  EndDate { get { return _dataModel.EndDate; } }
        public int WorkoutId { get { return _dataModel.Id; } }

        public IEnumerable<CardioSegment> CardioSegments
        {
            get { return new List<CardioSegment>(_dataModel.Cardio); }
        }

        public IEnumerable<StrengthSegment> StrengthSegments
        {
            get { return new List<StrengthSegment>(_dataModel.Strength); }
            
        }

        public DateTime StartDate
        {
            get { return _dataModel.StartDate; }
            
        }

        public void AddCardioSegment(CardioSegment cardioSegment)
        {
            _dataModel.Cardio.Add(cardioSegment);
        }

        public void AddStrengthSegment(StrengthSegment strengthSegment)
        {
            _dataModel.Strength.Add(strengthSegment);
        }

        public void SetEndDate(DateTime endDate)
        {
            _dataModel.EndDate = endDate;
        }

        public WorkoutDocument GetInnerModel()
        {
            return _dataModel;
        }

        
    }
}