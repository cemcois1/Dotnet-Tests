using IKA.API.DataBase.DbContext;
using IKA.API.DataBase.Entities.Course;

namespace IKA.API.DataBase.Repositories;

public sealed class CourseRepository : IRepository<Course, AppDbContext>
{
    public AppDbContext _DbContext { get; set; }

    public CourseRepository(AppDbContext dbContext)
    {
        _DbContext = dbContext;
    }

    public async Task Add(Course entity)
    {
        _DbContext.Courses.Add(entity);
        await _DbContext.SaveChangesAsync();
    }

    public async Task Update(Course entity)
    {
        _DbContext.Courses.Update(entity);
        await _DbContext.SaveChangesAsync();
    }

    public async Task Delete(Course entity)
    {
        _DbContext.Courses.Remove(entity);
        await _DbContext.SaveChangesAsync();
    }

    public async Task<Course?> GetById(int id)
    {
        return await _DbContext.Courses.FindAsync(id);
    }
}