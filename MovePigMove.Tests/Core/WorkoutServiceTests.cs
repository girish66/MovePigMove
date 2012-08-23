using System.Collections.Generic;
using Moq;
using MovePigMove.Core;
using MovePigMove.Core.CommandHandlers;
using MovePigMove.Core.Commands;
using MovePigMove.Core.Documents;
using MovePigMove.Core.Entities;
using MovePigMove.Core.Queries;
using MovePigMove.Core.Storage;
using NUnit.Framework;
using Should;

namespace MovePigMove.Tests.Core
{
    [TestFixture]
    public class WorkoutServiceTests
    {
        [Test]
        public void IfNoOpenSessionExistsNullIsReturned()
        {
            var repo = new Mock<IWorkoutRepository>();
            var service = new WorkoutService(repo.Object, null);
            repo.Setup(x => x.Where(It.IsAny<OpenWorkoutQuery>())).Returns(It.Is<IList<Workout>>(null));

            var currentWorkout = service.CurrentWorkout();

            currentWorkout.ShouldBeNull();
            repo.VerifyAll();
        }

        [Test]
        public void IfAnOpenSessionExistsThenItIsReturned()
        {
            var repo = new Mock<IWorkoutRepository>();
            var service = new WorkoutService(repo.Object, null);
            var workDoc = new List<Workout> { new Workout(new WorkoutDocument { Id = 1 }) };
            repo.Setup(x => x.Where(It.IsAny<OpenWorkoutQuery>())).Returns(workDoc);

            var currentWorkout = service.CurrentWorkout();

            currentWorkout.WorkoutId.ShouldEqual(1);
            repo.VerifyAll();
        }

        [Test]
        public void WhenCreatingANewWorkoutTheStartDateIsSet()
        {
            var invoker = new Mock<ICommandInvoker>();
            var service = new WorkoutService(null, invoker.Object);

            service.BeginNew();

            invoker.Verify(x => x.Execute(It.IsAny<BeginWorkoutCommand>()), Times.Once());

            //var workDoc = new List<Workout> { new Workout(new WorkoutDocument { Id = "wk/1" }) };
            //repo.Setup(x => x.Where(It.IsAny<OpenWorkoutQuery>())).Returns(workDoc);

            //var currentWorkout = service.CurrentWorkout();

            //currentWorkout.WorkoutId.ShouldEqual("wk/1");
            //repo.VerifyAll();
        }

    }
}