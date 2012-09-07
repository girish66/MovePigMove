using System.Collections.Generic;
using System.Web.Mvc;
using MovePigMove.Core;
using MovePigMove.Core.CommandHandlers;
using MovePigMove.Core.Commands;
using MovePigMove.Core.Entities;
using MovePigMove.Core.ViewModels;

namespace MovePigMove.Web.Controllers
{
    public class WorkoutController : BaseController
    {
        private readonly IWorkoutService _workoutService;
        private readonly ICommandInvoker _commandInvoker;
        private readonly IViewFactory<int, WorkoutSummaryViewModel> _viewFactory;
        private readonly IViewFactory<string, IList<Workout>> _workoutViewFactory;
        private readonly UserIdProvider _idProvider;

        public WorkoutController(IWorkoutService workoutService, ICommandInvoker commandInvoker, IViewFactory<int, WorkoutSummaryViewModel> viewFactory, IViewFactory<string, IList<Workout>> workoutViewFactory, UserIdProvider idProvider)
        {
            _workoutService = workoutService;
            _commandInvoker = commandInvoker;
            _viewFactory = viewFactory;
            _workoutViewFactory = workoutViewFactory;
            _idProvider = idProvider;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var wk = _workoutService.CurrentWorkout();

            if (wk != null)
            {
                var summary = _viewFactory.Load(wk.WorkoutId);
                return View(summary);
            }
            else
            {
                return View("PromptForNew");
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StartNew()
        {
            var wk = _workoutService.CurrentWorkout();

            if (wk != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                _workoutService.BeginNew();
                return RedirectToAction("Index");
            }
        }

        public ActionResult End()
        {
            var wk = _workoutService.CurrentWorkout().WorkoutId;
            
            _commandInvoker.Execute(new EndWorkoutCommand());

            return RedirectToAction("Summary", new {id = wk});
        }

        public ViewResult Summary(int id)
        {
            var model = _viewFactory.Load(id);
            return View(model);
        }

        public ViewResult BootStrap()
        {
            var list = new List<AddExerciseCommand>();

            list.Add(new AddExerciseCommand("Elliptical", ExerciseType.Cardio));
            list.Add(new AddExerciseCommand("Recumbent Bicycle", ExerciseType.Cardio));
            list.Add(new AddExerciseCommand("Treadmill", ExerciseType.Cardio));
            list.Add(new AddExerciseCommand("Bench Press", ExerciseType.Strength));
            list.Add(new AddExerciseCommand("Seated Row", ExerciseType.Strength));
            list.Add(new AddExerciseCommand("Bicep Curl", ExerciseType.Strength));
            list.Add(new AddExerciseCommand("Tricep Extension", ExerciseType.Strength));
            list.Add(new AddExerciseCommand("Shoulder Press", ExerciseType.Strength));

            _commandInvoker.Execute(list);


            return null;
        }

        [ChildActionOnly]
        public PartialViewResult _Summary()
        {
            IList<Workout> model = _workoutViewFactory.Load(_idProvider.UserId());
            return PartialView(model);
        }




    }
}