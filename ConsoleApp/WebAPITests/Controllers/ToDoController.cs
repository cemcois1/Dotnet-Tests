using Microsoft.AspNetCore.Mvc;
using WebAPITests.Models;
using WebAPITests.Repositories;

namespace WebAPITests.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoController: ControllerBase
{
    
    private readonly ToDoRepository _repository = new();
    
    [HttpGet]
    public ActionResult<List<ToDoItem>> GetAll()
    {
        return Ok(_repository.GetAll());
    }
    
    [HttpGet("{id}")]
    public ActionResult<ToDoItem> GetById(int id)
    {
        var item = _repository.GetById(id);
        if (item == null) return NotFound();

        return Ok(item);
    }

    [HttpPost]
    public ActionResult Add(ToDoItem item)
    {
        _repository.Add(item);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }

    
    [HttpPut("{id}")]
    public ActionResult Update(int id, ToDoItem item)
    {
        if (id != item.Id) return BadRequest();

        var existingItem = _repository.GetById(id);
        if (existingItem == null) return NotFound();

        _repository.Update(item);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var existingItem = _repository.GetById(id);
        if (existingItem == null) return NotFound();

        _repository.Delete(id);
        return NoContent();
    }
    
}