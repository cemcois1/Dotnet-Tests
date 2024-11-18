using ToDoAPI.Models;

namespace ToDoAPI.Repositories;

public class ToDoRepository
{
    private readonly List<ToDoItem> _toDoItems = new List<ToDoItem>()
    {
        new ToDoItem { Id = 1, Title = "Learn C#", IsCompleted = false },
        new ToDoItem { Id = 2, Title = "Learn ASP.NET Core Web API", IsCompleted = false },
        new ToDoItem { Id = 3, Title = "Learn Entity Framework Core", IsCompleted = false }
    };
    
    public List<ToDoItem> GetToDoItems()
    {
        return _toDoItems;
    }
    
    public ToDoItem? GetToDoItem(int id)
    {
        return _toDoItems.FirstOrDefault(x => x.Id == id);
    }
    
    public void AddToDoItem(ToDoItem toDoItem)
    {
        _toDoItems.Add(toDoItem);
    }
    
    public void UpdateToDoItem(ToDoItem toDoItem)
    {
        var existingToDoItem = _toDoItems.FirstOrDefault(x => x.Id == toDoItem.Id);
        if (existingToDoItem != null)
        {
            existingToDoItem.Title = toDoItem.Title;
            existingToDoItem.IsCompleted = toDoItem.IsCompleted;
        }
    }
    public void DeleteToDoItem(int id)
    {
        var toDoItem = _toDoItems.FirstOrDefault(x => x.Id == id);
        if (toDoItem != null)
        {
            _toDoItems.Remove(toDoItem);
        }
    }
}