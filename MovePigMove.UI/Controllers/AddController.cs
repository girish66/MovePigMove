using System.Collections.Generic;
using System.Web.Mvc;
using MovePigMove.Core;
using MovePigMove.Core.CommandHandlers;
using MovePigMove.Core.Commands;
using MovePigMove.Core.Entities;
using MovePigMove.UI.InputModels;

namespace MovePigMove.UI.Controllers
{
    public class AddController : BaseController
    {
        private ICommandInvoker _commandInvoker;
        private IViewFactory<ExerciseType, IList<Exercise>> _viewFactory;

        public AddController(ICommandInvoker commandInvoker, IViewFactory<ExerciseType, IList<Exercise>> viewFactory)
        {
            _commandInvoker = commandInvoker;
            _viewFactory = viewFactory;
        }

        [HttpGet]
        [ActionName("Cardio")]
        public ViewResult CardioGet()
        {
            return View(new AddCardioInputModel());
        }

        [HttpPost]
        public ActionResult Cardio(AddCardioInputModel input)
        {
            if (!ModelState.IsValid) return View(input);
            
            var command = new AddCardioCommand
                {
                    Duration = input.Duration, 
                    ExerciseId = input.ExerciseId, 
                    Level = input.Level, 
                    Notes = input.Notes
                };

            _commandInvoker.Execute(command);

            return RedirectToAction("Index", "Workout");
            
        }

        [HttpGet]
        [ActionName("Strength")]
        public ViewResult StrengthGet()
        {
            return View(new AddStrengthInputModel());
        }

        [HttpPost]
        public ActionResult Strength(AddStrengthInputModel input)
        {
            if (!ModelState.IsValid) return View(input);

            var command = new AddStrengthCommand
                {
                    ExerciseId = input.ExerciseId,
                    Notes = input.Notes,
                    Repetitions = input.Repetitions,
                    Weight = input.Weight
                };

            _commandInvoker.Execute(command);

            return RedirectToAction("Index", "Workout");
        }

        public PartialViewResult CardioList()
        {
            return PartialView(_viewFactory.Load(ExerciseType.Cardio));
        } 

        public PartialViewResult StrengthList()
        {
            return PartialView(_viewFactory.Load(ExerciseType.Strength));
        }
    }
}