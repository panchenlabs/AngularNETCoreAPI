using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    public interface IItemsRepository
    {
        Item GetItem(Guid id);

        IEnumerable<Item> GetItems();

        void CreateItem(Item item);

        void UpdateItem(Item item);

        void DeleteItem(Guid id);
    }
}