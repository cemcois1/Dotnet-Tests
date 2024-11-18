using System.Collections.Generic;
using System.Linq;
using WebAPITests.Models;

namespace WebAPITests.Repositories
{
    public class ToDoRepository
    {
        private readonly List<ToDoItem> _items = new();

        public List<ToDoItem> GetAll()
        {
            return _items;
        }

        public ToDoItem GetById(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public void Add(ToDoItem item)
        {
            _items.Add(item);
        }

        public void Update(ToDoItem item)
        {
            var existingItem = _items.FirstOrDefault(x => x.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Title = item.Title;
                existingItem.IsCompleted = item.IsCompleted;
            }
        }

        public void Delete(int id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _items.Remove(item);
            }
        }
    }
}