using FluentValidation;
using IKA.API.DataBase.Entities.Course;
using IKA.API.Services.Services.DataDisplayers.Course;
using IKA.API.Validators;
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
    public async Task<IActionResult> GetAllCourses()
    {
        var courses = await _courseDataCrudService.GetAllCourseData();

        if (!courses.Any())
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
    public async Task<IActionResult> AddCourse([FromBody] Course course)
    {
        //add validation here
        var validator = new CourseValidator();
        var result = await validator.ValidateAsync(course, options => options.IncludeRuleSets("Add"));
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        await _courseDataCrudService.AddCourse(course);
        Console.WriteLine("Course added successfully.");
        Console.WriteLine(course);
        return Ok("Course added successfully.");
    }

    [HttpPut("update")]
    public void UpdateCourse([FromBody] Course course)
    {
        _courseDataCrudService.UpdateCourse(course);
    }

    //get all card infos
    [HttpGet("cards")]
    public IActionResult GetCardInfos()
    {
        var cards = _courseDataCrudService.GetMainPageCourseData();
        Console.WriteLine(cards);
        return Ok(cards);
    }
}