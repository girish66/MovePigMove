using Moq;
using MovePigMove.Core.CommandHandlers;
using MovePigMove.Core.Commands;
using MovePigMove.Core.Documents;
using MovePigMove.Core.Entities;
using MovePigMove.Core.Storage;
using NUnit.Framework;
using Should;

namespace MovePigMove.Tests.Core.CommandHandlers
{
    [TestFixture]
    public class UpdateExerciseCommandHandlerTests
    {
        [Test]
        public void TheCorrectEntityIsUpdated()
        {
            var existing = new Exercise(new ExerciseDocument {Id = 12, Description = "bar", ExerciseType = ExerciseType.Cardio});
            var repo = new Mock<IExerciseRepository>();
            var command = new UpdateExerciseCommand(12, "new description", ExerciseType.Strength);
            var handler = new UpdateExerciseCommandHandler(repo.Object);

            repo.Setup(x => x.Load(12)).Returns(existing).Verifiable();
            handler.Handle(command);

            repo.VerifyAll();
        }

        [Test]
        public void TheChangesAreApplied()
        {
            var document = new ExerciseDocument {Id = 99, Description = "bar", ExerciseType = ExerciseType.Cardio};
            var existing = new Exercise(document);
            
            var repo = new Mock<IExerciseRepository>();
            repo.Setup(x => x.Load(99)).Returns(existing);

            var command = new UpdateExerciseCommand(99, "new description", ExerciseType.Strength);
            var handler = new UpdateExerciseCommandHandler(repo.Object);

            
            handler.Handle(command);
            
            document.Description.ShouldEqual("new description");
            document.ExerciseType.ShouldEqual(ExerciseType.Strength);
        }



    }
}