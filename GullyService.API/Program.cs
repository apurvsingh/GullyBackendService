using GullyService.Application.Abstractions;
using GullyService.Application.Interfaces;
using GullyService.Infrastructure.Persistence;
using GullyService.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddSwaggerGen();

// EF Core LocalDB
builder.Services.AddDbContext<GullyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI
builder.Services.AddScoped<IGullyService, GullyApplicationService>();
builder.Services.AddScoped<IGullyRepository, GullyRepository>();

var app = builder.Build();

// Middleware
app.UseHttpsRedirection();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gully API V1");
    });
}

app.MapControllers();

app.Run();
