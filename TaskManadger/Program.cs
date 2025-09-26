using Microsoft.EntityFrameworkCore;
using TaskManadger.Infrastructure;
using TaskManadger.Services;
using TodoApp.Services;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Сервис
builder.Services.AddScoped<ITaskService, TaskService>();

// Контроллеры и Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tasks API V1");
    c.RoutePrefix = string.Empty; // Swagger по корню
});

app.MapControllers();
app.Run();
