using ITS.IService;
using ITS.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITS.Controllers
{
    [ApiController]
    public class StepController : Controller
    {
        private readonly IStepService _step;
        public StepController(IStepService step)
        {
            _step = step;
        }


        [HttpPost, Route("api/Step/Add")]
        public IActionResult Add(StepVM model)
        {
            return Ok(_step.AddStep(model));
        }

        [HttpGet, Route("api/Step/StepsGrid")]
        public IActionResult StepsGrid()
        {
            return Ok(_step.GetSteps());
        }

        [HttpGet, Route("api/Step/DeleteStep/{id}")]
        public IActionResult DeleteStep(int id)
        {
            return Ok(_step.DeleteStep(id));
        }

    }
}