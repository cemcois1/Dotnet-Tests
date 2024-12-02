using IKA.API.DataBase.Entities.Course;
using IKA.API.DataBase.Repositories;
using CourseData=IKA.API.DataBase.Entities.Course.Course;
namespace IKA.API.Services.Services.DataDisplayers.Course;


public interface ICourseDataCRUDService
{
    public CourseRepository CourseRepository {
        get;
        set;
    }
    public List<CourseCard?> GetMainPageCourseData();
    CourseData? GetCourseData(int id);
    
    public void AddCourse(CourseData course);
    public void UpdateCourse(CourseData course);
    public void DeleteCourse(CourseData course);
}