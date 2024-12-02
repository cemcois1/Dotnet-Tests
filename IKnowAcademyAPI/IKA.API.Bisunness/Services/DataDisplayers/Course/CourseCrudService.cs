using IKA.API.DataBase.Entities.Course;
using IKA.API.DataBase.Repositories;
using CourseData=IKA.API.DataBase.Entities.Course.Course;
namespace IKA.API.Services.Services.DataDisplayers.Course;

public class CourseCrudService : ICourseDataCRUDService
{
    public CourseRepository CourseRepository { get; set; }

    public CourseCrudService(CourseRepository courseRepository)
    {
        CourseRepository = courseRepository;
    }

    private IQueryable<CourseData?> GetShowableCourses =>
        CourseRepository._DbContext.Courses.Where(course => course.IsDeleted == false);

    public List<CourseCard?> GetMainPageCourseData()
    {
        return GetShowableCourses.Select(course => course.CourseCard).ToList();
    }
    
    public CourseData GetCourseData(int id)
    {
        return GetShowableCourses.FirstOrDefault(course => course.Id == id);
    }

    public void AddCourse(CourseData course)
    {
        CourseRepository.Add(course);
    }

    public void UpdateCourse(CourseData course)
    {
        CourseRepository.Update(course);
    }

    public void DeleteCourse(CourseData course)
    {
        CourseRepository.Delete(course);
    }
}