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

    public Task Add(Course entity)
    {
        _DbContext.Courses.Add(entity);
        return _DbContext.SaveChangesAsync();
    }

    public Task Update(Course entity)
    {
        _DbContext.Courses.Update(entity);
        return _DbContext.SaveChangesAsync();
    }

    public Task Delete(Course entity)
    {
        _DbContext.Courses.Remove(entity);
        return _DbContext.SaveChangesAsync();
    }

    public async Task<Course?> GetById(int id)
    {
        return await _DbContext.Courses.FindAsync(id);
    }
}