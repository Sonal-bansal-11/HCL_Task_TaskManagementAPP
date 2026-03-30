using Microsoft.EntityFrameworkCore;
using TaskManagement.Api.Models;
using TaskManagement.Api.Repositories;
using TaskManagement.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container (Dependency Injection)
builder.Services.AddControllers();

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", builder =>
    {
        builder.WithOrigins("http://localhost:4200") // Angular default port
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// 2. Register Entity Framework Core In-Memory Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("TaskManagementDb"));

// Register Repository for Dependency Injection
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// Register Service
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngular"); 

// 4. Map Controller Routes
app.MapControllers();

// Data Seeding: Puts some defualt data into the in-memory database when the application starts. This is useful for testing and development purposes, so you have some initial data to work with when you run the application for the first time.
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // If there are no tasks in the database, add some default tasks
    if (!context.Tasks.Any())
    {
        context.Tasks.AddRange(
            new TaskItem { Title = "Finish HCL Hackathon", Description = "Complete the .NET and Angular integration.", IsCompleted = true },
            new TaskItem { Title = "Prepare Presentation", Description = "Create a demo video or PPT for the judges.", IsCompleted = false }
        );
        context.SaveChanges();
    }
}

app.Run();