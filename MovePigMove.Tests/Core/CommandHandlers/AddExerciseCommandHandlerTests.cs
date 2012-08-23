using Moq;
using MovePigMove.Core.CommandHandlers;
using MovePigMove.Core.Commands;
using MovePigMove.Core.Entities;
using MovePigMove.Core.Storage;
using NUnit.Framework;


namespace MovePigMove.Tests.Core.CommandHandlers
{
    [TestFixture]
    public class AddExerciseCommandHandlerTests
    {
        [Test]
        public void ANewExerciseIsAddedToTheRepository()
        {
            var repo = new Mock<IExerciseRepository>();
            var command = new AddExerciseCommand("foo", ExerciseType.Strength);
            var handler = new AddExerciseCommandHandler(repo.Object);

            repo.Setup(x => x.Add(It.Is<Exercise>(ex => ex.Description == "foo" && ex.ExerciseType == ExerciseType.Strength))).Verifiable();
            
            handler.Handle(command);

            repo.VerifyAll();
        }
    }
}