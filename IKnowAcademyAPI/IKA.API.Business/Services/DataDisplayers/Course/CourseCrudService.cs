using IKA.API.DataBase.Entities.Course;
using IKA.API.DataBase.Repositories;
using Microsoft.EntityFrameworkCore;
using CourseData = IKA.API.DataBase.Entities.Course.Course;

namespace IKA.API.Services.Services.DataDisplayers.Course;

public class CourseCrudService : ICourseDataCRUDService
{
    public CourseRepository CourseRepository { get; set; }
    private readonly ILogger<CourseCrudService> logger;
    public CourseCrudService(CourseRepository courseRepository,ILogger<CourseCrudService> logger)
    {
        CourseRepository = courseRepository;
        this.logger = logger;
    }

    private IQueryable<DataBase.Entities.Course.Course?> GetShowableCourses =>
        CourseRepository._DbContext.Courses.Where(course => course.IsDeleted == false);

    public List<CourseCard?> GetMainPageCourseData()
    {
        try
        {
            return GetShowableCourses
                .Include(course => course.CourseCard) // CourseCard ilişkisini dahil et
                .Select(course => course.CourseCard) // Sadece CourseCard döndür
                .ToList();
        }
        catch (Exception e)
        {
            logger.LogError("Ana Sayfa Kursları Getirilirken Hata Oluştu." + e);
            throw;
        }

    }

    public async Task<List<CourseData?>> GetAllCourseData()
    {
        try
        {
            return await GetShowableCourses
                .Include(course => course.CourseCard)
                .Include(course => course.RatingData)
                .Include(course => course.CourseDetails)
                .ThenInclude(details => details.CourseContent)
                .ToListAsync();
        }
        catch (Exception e)
        {
            logger.LogError("Tüm Kursların bilgileri Getirilirken Hata Oluştu." + e);
            throw;
        }
    }


    public DataBase.Entities.Course.Course GetCourseData(int id)
    {
        try
        {
            return GetShowableCourses.FirstOrDefault(course => course.Id == id);
        }
        catch (Exception e)
        {
            logger.LogError($"{id}Kurs bilgileri getirilirken hata oluştu." + e);
            throw;
        }
    }

    public async Task AddCourse(DataBase.Entities.Course.Course course)
    {
        try
        {
            course.CreatedAt = DateTime.Now;
            course.CourseCard.CreatedAt = DateTime.Now;
            course.RatingData.CreatedAt = DateTime.Now;
            course.CourseDetails.CreatedAt = DateTime.Now;


            UpdateCourseUpdateDates(course);


            await CourseRepository.Add(course);
        }
        catch (Exception e)
        {
            logger.LogError("Kurs eklenirken hata oluştu." + e);
            throw;
        }
    }

    public async void UpdateCourse(DataBase.Entities.Course.Course course)
    {
        try
        {
            UpdateCourseUpdateDates(course);
            await CourseRepository.Update(course);
        }
        catch (Exception e)
        {
            logger.LogError("Kurs güncellenirken hata oluştu." + e);
            throw;
        }
    }

    public async void DeleteCourse(DataBase.Entities.Course.Course course)
    {
        try
        {
            course.IsDeleted = true;
            await CourseRepository.Update(course);
        }
        catch (Exception e)
        {
            logger.LogError("Kurs silinirken hata oluştu." + e);
            throw;
        }

    }

    private void UpdateCourseUpdateDates(CourseData course)
    {
        try
        {
            course.UpdatedAt = DateTime.Now;
            course.CourseCard.UpdatedAt = DateTime.Now;
            course.CourseDetails.UpdatedAt = DateTime.Now;
            course.RatingData.UpdatedAt = DateTime.Now;
        }
        catch (Exception e)
        {
            logger.LogError("Kurs tarihleri güncellenirken hata oluştu." + e);
            throw;
        }

    }
}