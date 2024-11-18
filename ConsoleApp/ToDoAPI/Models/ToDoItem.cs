namespace ToDoAPI.Models;

public class ToDoItem
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public bool IsCompleted { get; set; }


    private Func<ToDoItem, bool> isAllValuesSame => (otherItem) =>
        otherItem.IsCompleted == IsCompleted&&
        otherItem.Id == Id&&
        otherItem.Title == Title;
    public override bool Equals(object? obj)
    {
        if (obj==null) return false;
        var otherItem=(ToDoItem)obj;
        if (isAllValuesSame(otherItem)) return true;

        return false;
    }
}