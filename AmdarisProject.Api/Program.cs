using AmdarisProject.Api.Infrastructure.Extensions;
using AmdarisProject.Common.Attributes;
using AmdarisProject.Core;
using AmdarisProject.Core.Interfaces;
using AmdarisProject.Core.Services;
using AmdarisProject.DataAccess.Contexts;
using AmdarisProject.DataAccess.Interfaces;
using AmdarisProject.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(o => o.Filters.Add(typeof(ApiExceptionFilterAttribute)));
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

//What are the difference of 31 and 32 lines?
builder.Services.AddAutoMapper(typeof(CoreAssemblyMarker));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EFCoreRepository<>));
builder.Services.AddScoped<DbContext, HostelDbContext>();
builder.Services.AddScoped<IHostelService, HostelService>();

var app = builder.Build();

app.UseCustomExceptionHandling();
app.UseExceptionLogger();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseTransactions();

app.MapControllers();

app.Run();
