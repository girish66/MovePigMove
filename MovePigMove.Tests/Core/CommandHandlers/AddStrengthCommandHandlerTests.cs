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
    public class AddStrengthCommandHandlerTests
    {
        [Test]
        public void TheStrengthActivityIsAddedToTheCurrentWorkout()
        {
            var workOut = new Workout(new WorkoutDocument());
            var ws = new Mock<IWorkoutService>();
            var handler = new AddStrengthCommandHandler(ws.Object);
            var command = new AddStrengthCommand { Weight = 20, ExerciseId = "ex/1", Repetitions= 99, Notes = "foo" };
            ws.Setup(x => x.CurrentWorkout()).Returns(workOut);

            handler.Handle(command);

            workOut.StrengthSegments.Count().ShouldEqual(1);
        }

        [Test]
        public void IfThereIsNoCurrentWorkoutAnExceptionIsThrown()
        {
            var ws = new Mock<IWorkoutService>();
            var handler = new AddStrengthCommandHandler(ws.Object);
            var command = new AddStrengthCommand { Weight = 20, ExerciseId = "ex/1", Repetitions = 99, Notes = "foo" };
            ws.Setup(x => x.CurrentWorkout()).Returns<Workout>(null);

            Assert.Throws<ApplicationException>(() => handler.Handle(command));
        }
    }
}