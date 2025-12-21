using Portfolio.Application.Abstractions;
using Portfolio.Application.Services;
using Portfolio.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Layer registrations
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<ISkillService, SkillService>();

// CORS for React
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("client", p =>
        p.WithOrigins(builder.Configuration["Client:Origin"] ?? "http://localhost:5174")
         .AllowAnyHeader()
         .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("client");
app.MapControllers();

app.Run();
