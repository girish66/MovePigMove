using System;
using System.Linq;
using Moq;
using MovePigMove.Core;
using MovePigMove.Core.CommandHandlers;
using MovePigMove.Core.Commands;
using MovePigMove.Core.Documents;
using MovePigMove.Core.Entities;
using NUnit.Framework;
using Should;

namespace MovePigMove.Tests.Core.CommandHandlers
{
    [TestFixture]
    public class AddCardioCommandHandlerTests
    {
        [Test]
        public void TheCardioActivityIsAddedToTheCurrentWorkout()
        {
            var workOut = new Workout(new WorkoutDocument());
            var ws = new Mock<IWorkoutService>();
            var handler = new AddCardioCommandHandler(ws.Object);
            var command = new AddCardioCommand {Duration = 20, ExerciseId = "ex/1", Level = 99, Notes = "foo"};
            ws.Setup(x => x.CurrentWorkout()).Returns(workOut);

            handler.Handle(command);

            workOut.CardioSegments.Count().ShouldEqual(1);
        }

        [Test]
        public void IfThereIsNoCurrentWorkoutAnExceptionIsThrown()
        {
            var ws = new Mock<IWorkoutService>();
            var handler = new AddCardioCommandHandler(ws.Object);
            var command = new AddCardioCommand { Duration = 20, ExerciseId = "ex/1", Level = 99, Notes = "foo" };
            ws.Setup(x => x.CurrentWorkout()).Returns<Workout>(null);

            Assert.Throws<ApplicationException>(() => handler.Handle(command));
        }
    }
}