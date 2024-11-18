using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;
using ToDoAPI.Repositories;

namespace ToDoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoListController : ControllerBase
{
    private readonly ToDoRepository _toDoRepository;

    public TodoListController(ToDoRepository toDoRepository)
    {
        _toDoRepository = toDoRepository;
    }
    //bodyden alsın bilgileri yeni bir item oluştursun
    [HttpPost]
    public ActionResult CreateToDoItem([FromBody] ToDoItem toDoItem)
    {
        if (_toDoRepository.GetToDoItem(toDoItem.Id)!=null)
        {
            return BadRequest("Item already exists");
        }
        _toDoRepository.AddToDoItem(toDoItem);
        return Ok("Item added successfully");
    }
    
    [HttpGet("All")]
    public ActionResult<List<ToDoItem>> GetAllItems()
    {
        var toDoList = _toDoRepository.GetToDoItems();
        if (toDoList.Count==0)
        {
            return NotFound("No item found");
        }
        return Ok(toDoList);
    }

    
    
    [HttpGet("{id}")]
    public ActionResult<ToDoItem> GetItemById(int id)
    {
        if (_toDoRepository.GetToDoItem(id)==null)
        {
            return NotFound("No item found");
        }
        return Ok(_toDoRepository.GetToDoItem(id));
    }
      
    //update
    [HttpPut("{id}")]
    public ActionResult UpdateToDoItem(int id, [FromBody] ToDoItem toDoItem)
    {
        var existingToDoItem = _toDoRepository.GetToDoItem(id);
        if (existingToDoItem == null)
        {
            return NotFound("No item found");
        }

        //eğer bütün özellikleri aynıysa update yapmasın
        if (existingToDoItem.Equals(toDoItem))
        {
            return Ok("Nothing to update");
            
        }
        existingToDoItem.Title = toDoItem.Title;
        existingToDoItem.IsCompleted = toDoItem.IsCompleted;
        _toDoRepository.UpdateToDoItem(existingToDoItem);
        return Ok("Item updated successfully");
    }
    
    [HttpDelete("{id}")]
    public ActionResult DeleteToDoItem(int id)
    {
        if (_toDoRepository.GetToDoItem(id)==null)
        {
            return NotFound("No item found");
        }
        _toDoRepository.DeleteToDoItem(id);
        return Ok("Item deleted successfully");
    }
}