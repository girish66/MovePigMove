using System;
using System.Linq;
using Moq;
using MovePigMove.Core;
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
    public class AddStrengthCommandHandlerTests
    {
        [Test]
        public void TheStrengthActivityIsAddedToTheCurrentWorkout()
        {
            var workOut = new Workout(new WorkoutDocument());
            var repo = new Mock<IExerciseRepository>();
            var ws = new Mock<IWorkoutService>();
            var handler = new AddStrengthCommandHandler(ws.Object, repo.Object);
            var command = new AddStrengthCommand { Weight = 20, ExerciseId = 1, Repetitions= 99, Notes = "foo" };
            
            ws.Setup(x => x.CurrentWorkout()).Returns(workOut);
            repo.Setup(x => x.Load(1)).Returns(new Exercise(new ExerciseDocument { Description = "exer" }));
            handler.Handle(command);

            workOut.StrengthSegments.Count().ShouldEqual(1);
        }

        [Test]
        public void IfThereIsNoCurrentWorkoutAnExceptionIsThrown()
        {
            var ws = new Mock<IWorkoutService>();
            var repo = new Mock<IExerciseRepository>();
            var handler = new AddStrengthCommandHandler(ws.Object, repo.Object);
            var command = new AddStrengthCommand { Weight = 20, ExerciseId = 1, Repetitions = 99, Notes = "foo" };
            
            ws.Setup(x => x.CurrentWorkout()).Returns<Workout>(null);
            repo.Setup(x => x.Load(1)).Returns(new Exercise(new ExerciseDocument { Description = "exer" }));

            Assert.Throws<ApplicationException>(() => handler.Handle(command));
        }
    }
}