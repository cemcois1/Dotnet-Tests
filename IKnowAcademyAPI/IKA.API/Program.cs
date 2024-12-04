using IKA.API.DataBase.DbContext;
using IKA.API.DataBase.Repositories;
using IKA.API.Services.Services.DataDisplayers.Course;
using IKA.API.Utilities;
using IKA.API.Utilities.HealthCheck;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<ICourseDataCRUDService, CourseCrudService>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
builder.Services.AddHealthChecks()
    .AddSqlServerHealthCheck(connectionString)
    .AddMemoryHealthCheck(100)
    .AddGoogleHealthCheck()
    .AddStorgeHealthCheck();

    //.AddSqlServer(
    //    connectionString: builder.Configuration["ConnectionStrings:DefaultConnection"],
      //  name:"SQL Server Health Check",
        //timeout: TimeSpan.FromSeconds(5),
        //failureStatus: HealthStatus.Unhealthy // Başarısızlık durumu
        //);
    


var app = builder.Build();

app.MapHealthChecks("/healthz",new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    ResponseWriter = CustomHealthCheckResponseWriter.WriteDetailedResponse
});
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();