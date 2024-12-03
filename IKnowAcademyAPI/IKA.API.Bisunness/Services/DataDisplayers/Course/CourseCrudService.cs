using IKA.API.DataBase.Entities.Course;
using IKA.API.DataBase.Repositories;
using Microsoft.EntityFrameworkCore;
using CourseData = IKA.API.DataBase.Entities.Course.Course;

namespace IKA.API.Services.Services.DataDisplayers.Course;

public class CourseCrudService : ICourseDataCRUDService
{
    public CourseRepository CourseRepository { get; set; }

    public CourseCrudService(CourseRepository courseRepository)
    {
        CourseRepository = courseRepository;
    }

    private IQueryable<DataBase.Entities.Course.Course?> GetShowableCourses =>
        CourseRepository._DbContext.Courses.Where(course => course.IsDeleted == false);

    public List<CourseCard?> GetMainPageCourseData()
    {
        return GetShowableCourses.Select(course => course.CourseCard).ToList();
    }

    public async Task<List<CourseData?>> GetAllCourseData()
    {
        return await GetShowableCourses
            .Include(course => course.CourseCard)
            .Include(course => course.RatingData)
            .Include(course => course.CourseDetails)
            .ThenInclude(details=>details.CourseContent)
            .ToListAsync();
    }


    public DataBase.Entities.Course.Course GetCourseData(int id)
    {
        return GetShowableCourses.FirstOrDefault(course => course.Id == id);
    }

    public async Task AddCourse(DataBase.Entities.Course.Course course)
    {
        course.CreatedAt = DateTime.Now;
        course.CourseCard.CreatedAt = DateTime.Now;
        course.RatingData.CreatedAt = DateTime.Now;
        course.CourseDetails.CreatedAt = DateTime.Now;


        UpdateCourseUpdateDates(course);


        await CourseRepository.Add(course);
    }

    public async void UpdateCourse(DataBase.Entities.Course.Course course)
    {
        UpdateCourseUpdateDates(course);
        await CourseRepository.Update(course);
    }

    public async void DeleteCourse(DataBase.Entities.Course.Course course)
    {
        course.IsDeleted = true;
        await CourseRepository.Update(course);
    }

    private void UpdateCourseUpdateDates(CourseData course)
    {
        course.UpdatedAt = DateTime.Now;
        course.CourseCard.UpdatedAt = DateTime.Now;
        course.CourseDetails.UpdatedAt = DateTime.Now;
        course.RatingData.UpdatedAt = DateTime.Now;
    }
}