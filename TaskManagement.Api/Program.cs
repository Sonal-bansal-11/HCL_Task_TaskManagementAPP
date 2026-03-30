using Microsoft.EntityFrameworkCore;
using TaskManagement.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container (Dependency Injection)
builder.Services.AddControllers();

// 2. Register Entity Framework Core In-Memory Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("TaskManagementDb"));

// Register Repository for Dependency Injection
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// Register Service
builder.Services.AddScoped<ITaskService, TaskService>();

// 3. API Documentation Setup
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// 4. Map Controller Routes
app.MapControllers();

app.Run();