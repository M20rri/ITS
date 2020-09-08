using ITS.Models;
using ITS.ViewModels;
using System.Collections.Generic;

namespace ITS.IService
{
    public interface IStepService
    {
        ResponseMessage AddStep(StepVM model);
        ResponseMessage DeleteStep(int id);
        IEnumerable<StepVM> GetSteps();
    }
}
