using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dtos;
using WebAPI.Extensions;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository itemRepository;

        public ItemsController(IItemsRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = itemRepository.GetItems().Select(item => item.AsDto());
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = itemRepository.GetItem(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(ItemCreateDto createItemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = createItemDto.Name,
                Price = createItemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            itemRepository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, ItemUpdateDto updateItemDto)
        {
            var existingItem = itemRepository.GetItem(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            Item updatedItem = existingItem with
            {
                Name = updateItemDto.Name,
                Price = updateItemDto.Price
            };

            itemRepository.UpdateItem(updatedItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = itemRepository.GetItem(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            itemRepository.DeleteItem(id);

            return NoContent();
        }
    }
}