using ITS.Models;
using ITS.ViewModels;
using System.Collections.Generic;

namespace ITS.IService
{
    public interface IItemService
    {
        ResponseMessage AddItem(ItemVM model);
        ResponseMessage EditItem(ItemVM model);
        ResponseMessage DeleteItem(int id);
        IEnumerable<ItemVM> GetItems();
        IEnumerable<ItemVM> GetItemsByStepID(int id);
    }
}
