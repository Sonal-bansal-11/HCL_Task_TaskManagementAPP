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

app.Run();