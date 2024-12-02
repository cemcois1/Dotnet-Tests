using IKA.API.DataBase.Entities.Course;
using IKA.API.Services.Services.DataDisplayers.Course;
using Microsoft.AspNetCore.Mvc;

namespace IKA.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseDataCRUDService _courseDataCrudService;

    public CourseController(ICourseDataCRUDService courseDataCrudService)
    {
        _courseDataCrudService = courseDataCrudService;
    }

    // Show all courses
    [HttpGet]
    public IActionResult GetAllCourses()
    {
        var courses = _courseDataCrudService.GetMainPageCourseData();
        if (courses == null || !courses.Any())
        {
            return NotFound("No courses available.");
        }
        return Ok(courses);
    }

    // Show specific course details by ID
    [HttpGet("{id:int}")]
    public IActionResult GetCourseById(int id)
    {
        var course = _courseDataCrudService.GetCourseData(id);
        if (course == null)
        {
            return NotFound($"Course with ID {id} not found.");
        }
        return Ok(course);
    }
    
    [HttpPost("add")]
    public void AddCourse([FromBody] Course course)
    {
        _courseDataCrudService.AddCourse(course);
    }
    [HttpPost("update")]
    public void UpdateCourse([FromBody] Course course)
    {
        _courseDataCrudService.UpdateCourse(course);
    }
}

