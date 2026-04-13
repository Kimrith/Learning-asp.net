using Learning.Data;
using Learning.Repositories;
using Learning.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services + Repository
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

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

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS (optional)
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();