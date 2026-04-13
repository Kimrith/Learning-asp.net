using Learning.Data;
using Learning.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IAuthService, Auths>();
builder.Services.AddScoped<ICatecoryService, CatecoryService>();

// Database
var dbConnection = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(dbConnection))
{
    throw new Exception("Missing database connection string");
}

builder.Services.AddDbContext<LearningDbContext>(options =>
{
    options.UseSqlServer(dbConnection);
});

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();