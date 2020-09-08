using ITS.IService;
using ITS.Models;
using ITS.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ITS.Service
{
    public class ItemService : IItemService
    {

        private readonly ApplicationDbContext _ctx;
        public ItemService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ResponseMessage AddItem(ItemVM model)
        {
            bool isExist = _ctx.Items.Any(a => a.Title.Equals(model.Title) && a.StepId.Equals(model.StepId));
            if (isExist)
            {
                return new ResponseMessage { Code = 0, Message = $"{model.Title} exist before" };
            }
            _ctx.Items.Add(new Item { Title = model.Title , Description = model.Description , StepId = model.StepId });
            _ctx.SaveChanges();
            return new ResponseMessage { Code = 1, Message = "Saved Sucesfully" };
        }

        public ResponseMessage DeleteItem(int id)
        {
            var item = _ctx.Items.FirstOrDefault(a => a.Id == id);
            if (item != null)
            {
                _ctx.Items.Remove(item);
                _ctx.SaveChanges();
                return new ResponseMessage { Code = 1, Message = $"{item.Title} Deleted" };
            }
            return new ResponseMessage { Code = 0, Message = $"There were no data for this item No : {id}" };
        }

        public ResponseMessage EditItem(ItemVM model)
        {
            var item = _ctx.Items.FirstOrDefault(a => a.Id == model.Id);
            if (item != null)
            {
                item.Title = model.Title;
                item.Description = model.Description;

                _ctx.SaveChanges();
                return new ResponseMessage { Code = 1, Message = $"{item.Title} Updated" };

            }
            return new ResponseMessage { Code = 0, Message = $"Invalid item Id : {model.Id}" };
        }

        public IEnumerable<ItemVM> GetItems()
        {
            return _ctx.Items.Select(a => new ItemVM { Id = a.Id , Title = a.Title , Description = a.Description , StepId = a.StepId }).ToList();
        }

        public IEnumerable<ItemVM> GetItemsByStepID(int id)
        {
            return _ctx.Items.Select(a => new ItemVM { Id = a.Id, Title = a.Title, Description = a.Description, StepId = a.StepId }).Where(a => a.StepId == id).ToList();
        }
    }
}
