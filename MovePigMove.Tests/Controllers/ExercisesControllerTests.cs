using System.Web.Mvc;
using Moq;
using MovePigMove.Core.CommandHandlers;
using MovePigMove.Core.Commands;
using MovePigMove.Core.Entities;
using MovePigMove.Core.ViewModels;
using MovePigMove.Web.Controllers;
using NUnit.Framework;
using Should;

namespace MovePigMove.Tests.Controllers
{
    public class ExercisesControllerTests
    {
        [TestFixture]
        public class Index
        {
            [Test]
            public void AListOfExercisesIsShown()
            {
            }
        }

        [TestFixture]
        public class Add
        {
            [Test]
            public void AfterAnExcerciseIsAddedTheUserIsShownAConfirmationPage()
            {
                var model = new AddExerciseInputModel();
                var invoker = new Mock<ICommandInvoker>();
                var controller = new ExercisesController(invoker.Object, null);

                var result = (RedirectToRouteResult) controller.Add(model);
                result.RouteName.ShouldEqual("");
            }

            [Test]
            public void WhenTheInputModelIsNotValidTheUserIsShownTheAddView()
            {
                var model = new AddExerciseInputModel();
                var invoker = new Mock<ICommandInvoker>();
                var controller = new ExercisesController(invoker.Object, null);
                controller.ModelState.AddModelError("foo", "bad");

                var result = (ViewResult) controller.Add(model);
                result.ViewName.ShouldEqual("Index");
            }

            [Test]
            public void WhenTheInputModelIsValidAnExerciseIsAdded()
            {
                var inputModel = new AddExerciseInputModel {Description = "foo", Type = ExerciseType.Cardio};
                var invoker = new Mock<ICommandInvoker>();
                invoker.Setup(
                    i => i.Execute(
                        It.Is<AddExerciseCommand>(
                            c => c.Description == inputModel.Description && c.Type == inputModel.Type)));
                var controller = new ExercisesController(invoker.Object, null);


                controller.Add(inputModel);

                invoker.VerifyAll();
            }
        }

 
    }
}