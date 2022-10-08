using AmdarisProject.Core;
using AmdarisProject.Core.Interfaces;
using AmdarisProject.Core.Profiles;
using AmdarisProject.Core.Services;
using AmdarisProject.DataAccess.Contexts;
using AmdarisProject.DataAccess.Interfaces;
using AmdarisProject.DataAccess.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HostelDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

//var mapperConfiguration = new MapperConfiguration(options =>
//{
//    //options.AddProfile<HostelProfile>();
//});

//builder.Services.AddSingleton(mapperConfiguration.CreateMapper());

builder.Services.AddAutoMapper(typeof(CoreAssemblyMarker));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EFCoreRepository<>));
builder.Services.AddScoped<DbContext, HostelDbContext>();
builder.Services.AddScoped<IHostelService, HostelService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
