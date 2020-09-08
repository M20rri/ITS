using ITS.IService;
using ITS.Models;
using ITS.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ITS.Service
{
    public class StepService : IStepService
    {
        private readonly ApplicationDbContext _ctx;
        public StepService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ResponseMessage AddStep(StepVM model)
        {
            bool isExist = _ctx.Steps.Any(a => a.Name.Equals(model.Name));
            if (isExist)
            {
                return new ResponseMessage { Code = 0, Message = $"{model.Name} exist before" };
            }
            _ctx.Steps.Add(new Step { Name = model.Name});
            _ctx.SaveChanges();
            return new ResponseMessage { Code = 1, Message = "Saved Sucesfully" };
        }

        public ResponseMessage DeleteStep(int id)
        {
            var step = _ctx.Steps.FirstOrDefault(a => a.Id == id);
            if (step != null)
            {
                // Delete Items related with step

                var items = _ctx.Items.Where(a => a.StepId == id).ToList();
                if (items.Any())
                {
                    foreach (var item in items)
                    {
                        _ctx.Items.Remove(item);
                        _ctx.SaveChanges();
                    }
                }

                _ctx.Steps.Remove(step);
                _ctx.SaveChanges();
                return new ResponseMessage { Code = 1, Message = $"{step.Name} Deleted" };
            }
            return new ResponseMessage { Code = 0, Message = $"There were no data for this User No : {id}" };
        }

        public IEnumerable<StepVM> GetSteps()
        {
            return _ctx.Steps.Select(a => new StepVM { Id = a.Id , Name = a.Name }).ToList();
        }
    }
}
