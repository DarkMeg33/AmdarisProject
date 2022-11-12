using AmdarisProject.Api.Infrastructure.Extensions;
using AmdarisProject.Common.Attributes;
using AmdarisProject.Core;
using AmdarisProject.Core.Interfaces;
using AmdarisProject.Core.Services;
using AmdarisProject.DataAccess.Contexts;
using AmdarisProject.DataAccess.Interfaces;
using AmdarisProject.DataAccess.Repositories;
using AmdarisProject.Domain.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(o => o.Filters.Add(typeof(ApiExceptionFilterAttribute)));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

builder.Services.AddDbContext<HostelDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDb"));
});

var jwtAuthOptions = builder.Configuration.ConfigureJwtAuthOptions(builder.Services);

builder.Services.AddJwtAuth(jwtAuthOptions);
builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 1;
}).AddEntityFrameworkStores<HostelDbContext>();

builder.Services.AddAutoMapper(typeof(CoreAssemblyMarker));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EFCoreRepository<>));
builder.Services.AddScoped<DbContext, HostelDbContext>();
builder.Services.AddScoped<IHostelService, HostelService>();
builder.Services.AddScoped<IFloorService, FloorService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IHostelRepository, HostelRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

var app = builder.Build();

app.UseCustomExceptionHandling();
app.UseExceptionLogger();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseTransactions();

app.MapControllers();

app.Run();
