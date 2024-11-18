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
        _toDoRepository.AddToDoItem(toDoItem);
        return Ok();
    }
    
    [HttpGet("All")]
    public ActionResult<List<ToDoItem>> GetAllItems()
    {
        var toDoList = _toDoRepository.GetToDoItems();
        if (toDoList.Count==0)
        {
            return NotFound();
        }
        return Ok(toDoList);
    }

    
    
    [HttpGet("{id}")]
    public ActionResult<ToDoItem> GetItemById(int id)
    {
        if (_toDoRepository.GetToDoItem(id)==null)
        {
            return NotFound();
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
            return NotFound();
        }
        existingToDoItem.title = toDoItem.title;
        existingToDoItem.isCompleted = toDoItem.isCompleted;
        _toDoRepository.UpdateToDoItem(existingToDoItem);
        return Ok();
    }



    
    
    
}