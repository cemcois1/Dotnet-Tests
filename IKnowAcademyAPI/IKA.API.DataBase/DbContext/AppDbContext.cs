using IKA.API.DataBase.Entities.Course;
using IKA.API.DataBase.Entities.UserContact;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IKA.API.DataBase.DbContext;

public class AppDbContext:Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }
    public DbSet<Course> Courses { get; set; }
    public DbSet<UserContact> Users{ get; set; }
}