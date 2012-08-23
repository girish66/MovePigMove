using System.Web.Mvc;
using Moq;
using MovePigMove.Core;
using MovePigMove.Core.CommandHandlers;
using MovePigMove.Core.Commands;
using MovePigMove.Core.Documents;
using MovePigMove.Core.Entities;
using MovePigMove.Core.ViewModels;
using MovePigMove.UI.Controllers;
using NUnit.Framework;
using Should;

namespace MovePigMove.Tests.Controllers
{
    public class WorkoutControllerTests
    {
        [TestFixture] 
        public class Index
        {
            [Test]
            public void IfThereIsNoCurrentWorkOutTheCreatePromptIsShown()
            {
                var service = new Mock<IWorkoutService>();
                var viewFactory = new Mock<IViewFactory<int, WorkoutSummaryViewModel>>();
                var controller = new WorkoutController(service.Object, null, viewFactory.Object);
                service.Setup(x => x.CurrentWorkout()).Returns((Workout)null);
                viewFactory.Setup(x => x.Load(It.IsAny<int>())).Returns(new WorkoutSummaryViewModel());

                var result = (ViewResult)controller.Index();

                result.ViewName.ShouldEqual("PromptForNew");
            }

            [Test]
            public void IfThereIsACurrentWorkoutTheDefaultViewIsShown()
            {
                var workout = new Workout(new WorkoutDocument());
                var service = new Mock<IWorkoutService>();
                var viewFactory = new Mock<IViewFactory<int, WorkoutSummaryViewModel>>();
                var controller = new WorkoutController(service.Object, null, viewFactory.Object);
                service.Setup(x => x.CurrentWorkout()).Returns(workout);
                viewFactory.Setup(x => x.Load(It.IsAny<int>())).Returns(new WorkoutSummaryViewModel());

                var result = (ViewResult)controller.Index();

                result.ViewName.ShouldEqual("");
            }
        }

        [TestFixture]
        public class StartNew
        {
            

            [Test]
            public void ANewWorkoutIsStarted()
            {
                var service = new Mock<IWorkoutService>();
                var controller = new WorkoutController(service.Object, null, null);
                service.Setup(x => x.CurrentWorkout()).Returns((Workout)null);
                service.Setup(x => x.BeginNew()).Verifiable();

                var result = controller.StartNew();

                service.VerifyAll();
            }

            [Test]
            public void TheUserIsRedirectedToIndex()
            {
                var service = new Mock<IWorkoutService>();
                var controller = new WorkoutController(service.Object, null, null);
                service.Setup(x => x.BeginNew()).Verifiable();
                service.Setup(x => x.CurrentWorkout()).Returns((Workout)null);

                var result = (RedirectToRouteResult)controller.StartNew();

                result.RouteValues["action"].ShouldEqual("Index");
            }

            [Test]
            public void IfAnExistingWorkoutExistsTheUserIsRedirected()
            {
                var work = new Workout(new WorkoutDocument());
                var service = new Mock<IWorkoutService>();
                var controller = new WorkoutController(service.Object, null, null);
                service.Setup(x => x.CurrentWorkout()).Returns(work);

                var result = (RedirectToRouteResult)controller.StartNew();

                result.RouteValues["action"].ShouldEqual("Index");
                service.Verify(x =>  x.BeginNew(), Times.Never());




            }
        }

        [TestFixture]
        public class End
        {
            [Test]
            public void AnEndWorkoutCommandIsSent()
            {
                var invoker = new Mock<ICommandInvoker>();
                var service = new Mock<IWorkoutService>();
                service.Setup(x => x.CurrentWorkout()).Returns(new Workout(new WorkoutDocument { Id = 1 }));
                var controller = new WorkoutController(service.Object, invoker.Object, null);

                controller.End();

                invoker.Verify(x => x.Execute(It.IsAny<EndWorkoutCommand>()));
            }

            [Test]
            public void UserIsRedirectedToSummaryPage()
            {
                var invoker = new Mock<ICommandInvoker>();
                var service = new Mock<IWorkoutService>();
                service.Setup(x => x.CurrentWorkout()).Returns(new Workout(new WorkoutDocument {Id = 1}));
                var controller = new WorkoutController(service.Object, invoker.Object, null);

                var res = (RedirectToRouteResult) controller.End();
                res.RouteValues["action"].ShouldEqual("Summary");
                res.RouteValues["id"].ShouldEqual(1);
            }

        }

    }


}