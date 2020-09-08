using ITS.IService;
using ITS.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITS.Controllers
{
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _item;
        public ItemController(IItemService item)
        {
            _item = item;
        }


        [HttpPost, Route("api/Item/Add")]
        public IActionResult Add(ItemVM model)
        {
            return Ok(_item.AddItem(model));
        }

        [HttpPost, Route("api/Item/Edit")]
        public IActionResult Edit(ItemVM model)
        {
            return Ok(_item.EditItem(model));
        }

        [HttpGet, Route("api/Item/ItemsGrid")]
        public IActionResult ItemsGrid()
        {
            return Ok(_item.GetItems());
        }

        [HttpGet, Route("api/Item/DeleteItem/{id}")]
        public IActionResult DeleteItem(int id)
        {
            return Ok(_item.DeleteItem(id));
        }

        [HttpGet, Route("api/Item/ItemsGridByTabId/{id}")]
        public IActionResult ItemsGridByTabId(int id)
        {
            return Ok(_item.GetItemsByStepID(id));
        }

    }
}