using System.Web.Mvc;
using MovePigMove.Core;
using MovePigMove.Core.CommandHandlers;
using MovePigMove.Core.Commands;
using MovePigMove.Core.ViewModels;

namespace MovePigMove.UI.Controllers
{
    public class ExercisesController : BaseController
    {
        private readonly ICommandInvoker _invoker;
        private readonly IViewRepository _viewRepository;


        public ExercisesController(ICommandInvoker invoker, IViewRepository viewRepository)
        {
            _invoker = invoker;
            _viewRepository = viewRepository;
        }

        [HttpGet]
        public ViewResult Index()
        {
            var model = _viewRepository.Load<AddExerciseInputModel, ExerciseListViewModel>(new AddExerciseInputModel());
            return View(model);
        }

        public ActionResult Add(AddExerciseInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                _invoker.Execute(new AddExerciseCommand(inputModel.Description, inputModel.Type));
                TempData["Message"] = "Added new {0} exercise -- {1}".ToFormat(inputModel.Type, inputModel.Description);
                return RedirectToAction("Index");                
            }
            else
            {
                return View("Index", inputModel);
            }
        }


    }
}