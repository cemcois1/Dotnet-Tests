using FluentValidation;
using IKA.API.DataBase.DbContext;
using IKA.API.DataBase.Repositories;
using IKA.API.Services.Services.DataDisplayers.Course;
using IKA.API.Validators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<ICourseDataCRUDService, CourseCrudService>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var dbPath = builder.Configuration["ConnectionStrings:DefaultConnection"];
    options.UseSqlServer(dbPath);
});

builder.Services.AddValidatorsFromAssemblyContaining<CourseValidator>();
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