

using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Abstractions;
using Portfolio.Application.Mapping;
using Portfolio.Application.Services;
using Portfolio.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();

builder.Services.AddControllers();

// Layer registrations
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<IContactFormService, ContactFormService>();
builder.Services.AddScoped<IContentService, ContentService>();
builder.Services.AddScoped<IExperienceService, ExperienceService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IQualificationService, QualificationService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaService>();


// CORS for React
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("client", p =>
        p.WithOrigins(builder.Configuration["Client:Origin"] ?? "http://localhost:5174")
         .AllowAnyHeader()
         .AllowAnyMethod());
});

// Registers all Profile classes from this assembly

//builder.Services.AddAutoMapper(typeof(PortfolioMappingProfile).Assembly);

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<PortfolioMappingProfile>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("client");
app.MapControllers();

app.Run();
