using System.Web.Mvc;
using MovePigMove.Core.Commands;
using MovePigMove.UI.Controllers;
using MovePigMove.UI.InputModels;
using Should;
using Moq;
using MovePigMove.Core.CommandHandlers;
using NUnit.Framework;

namespace MovePigMove.Tests.Controllers
{
    public class AddControllerTests
    {
        [TestFixture]
        public class Cardio
        {
            [Test]
            public void AnAddCommandIsSubmitted()
            {
                var invoker = new Mock<ICommandInvoker>();
                var controller = new AddController(invoker.Object, null);
                var input = new AddCardioInputModel {ExerciseId = "ex/1", Level = 1, Duration = 45, Notes = string.Empty};

                var result = controller.Cardio(input);

                invoker.Verify(i => i.Execute(It.Is<AddCardioCommand>(cmd => cmd.Duration == input.Duration && cmd.ExerciseId == input.ExerciseId && cmd.Level == input.Level && cmd.Notes == input.Notes)));

            }

            [Test]
            public void TheUserIsRedirectedToTheWorkoutSummary()
            {
                var invoker = new Mock<ICommandInvoker>();
                var controller = new AddController(invoker.Object, null);
                var input = new AddCardioInputModel { ExerciseId = "ex/1", Level = 1, Duration = 45, Notes = string.Empty };

                var result = (RedirectToRouteResult)controller.Cardio(input);
                result.RouteValues["action"].ShouldEqual("Index");
            }

            [Test]
            public void IfTheModelStateIsNotValidTheUserIsPromptedToReEnter()
            {
                var invoker = new Mock<ICommandInvoker>();
                var controller = new AddController(invoker.Object, null);
                controller.ModelState.AddModelError("Level", "foo");
                var input = new AddCardioInputModel { ExerciseId = "ex/1", Level = 1, Duration = 45, Notes = string.Empty };

                var res = (ViewResult) controller.Cardio(input);

                res.ViewName.ShouldEqual("");

            }
        }

        [TestFixture]
        public class Strength
        {
            [Test]
            public void AnAddStrengthCommandIsSubmitted()
            {
                var invoker = new Mock<ICommandInvoker>();
                var controller = new AddController(invoker.Object, null);
                var input = new AddStrengthInputModel {ExerciseId = "ex/2", Notes = "f", Repetitions = 10, Weight = 185};

                var result = controller.Strength(input);

                invoker.Verify(i =>i.Execute(It.Is<AddStrengthCommand>(cmd =>
                            cmd.ExerciseId == input.ExerciseId && cmd.Notes == input.Notes &&
                            cmd.Repetitions == input.Repetitions && cmd.Weight == input.Weight)));

            }

            [Test]
            public void TheUserIsRedirectedToTheWokoutSummary()
            {
                var invoker = new Mock<ICommandInvoker>();
                var controller = new AddController(invoker.Object, null);
                var input = new AddStrengthInputModel { ExerciseId = "ex/2", Notes = "f", Repetitions = 10, Weight = 185 };

                var result = (RedirectToRouteResult)controller.Strength(input);
                result.RouteValues["action"].ShouldEqual("Index");

            }
        }
    }
}