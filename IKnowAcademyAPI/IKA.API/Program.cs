using IKA.API.Controllers;
using IKA.API.DataBase.DbContext;
using IKA.API.DataBase.Repositories;
using IKA.API.Services.Services.DataDisplayers.Course;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<ICourseDataCRUDService, CourseCrudService>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var DbPath = builder.Configuration["ConnectionStrings:DefaultConnection"];
    options.UseSqlServer(DbPath);
});


builder.Services.AddControllers();

var app = builder.Build();


app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
