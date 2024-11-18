using ToDoAPI.Models;

namespace ToDoAPI.Repositories;

public class ToDoRepository
{
    private readonly List<ToDoItem> _toDoItems = new List<ToDoItem>()
    {
        new ToDoItem { id = 1, title = "Learn C#", isCompleted = false },
        new ToDoItem { id = 2, title = "Learn ASP.NET Core Web API", isCompleted = false },
        new ToDoItem { id = 3, title = "Learn Entity Framework Core", isCompleted = false }
    };
    
    public List<ToDoItem> GetToDoItems()
    {
        return _toDoItems;
    }
    
    public ToDoItem GetToDoItem(int id)
    {
        return _toDoItems.FirstOrDefault(x => x.id == id);
    }
    
    public void AddToDoItem(ToDoItem toDoItem)
    {
        _toDoItems.Add(toDoItem);
    }
    
    public void UpdateToDoItem(ToDoItem toDoItem)
    {
        var existingToDoItem = _toDoItems.FirstOrDefault(x => x.id == toDoItem.id);
        if (existingToDoItem != null)
        {
            existingToDoItem.title = toDoItem.title;
            existingToDoItem.isCompleted = toDoItem.isCompleted;
        }
    }
    public void DeleteToDoItem(int id)
    {
        var toDoItem = _toDoItems.FirstOrDefault(x => x.id == id);
        if (toDoItem != null)
        {
            _toDoItems.Remove(toDoItem);
        }
    }
}