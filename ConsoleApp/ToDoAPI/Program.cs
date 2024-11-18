using ToDoAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ToDoRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.UseHttpsRedirection();


app.MapControllers();



app.Run();

