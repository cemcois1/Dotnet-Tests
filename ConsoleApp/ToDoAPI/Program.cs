using ToDoAPI.MiddleWare;
using ToDoAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ToDoRepository>();
builder.Services.AddSingleton<LoggingMiddleWare>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Middleware'i ekle
app.UseLogging();

app.MapControllers();
app.Run();