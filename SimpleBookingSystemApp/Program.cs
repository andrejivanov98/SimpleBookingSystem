using Microsoft.EntityFrameworkCore;
using SimpleBookingSystem.DataAccess.EntityFramework;
using SimpleBookingSystem.DataAccess.Repositories;
using SimpleBookingSystem.DataAccess.Repositories.RepositoryInterfaces;
using SimpleBookingSystem.Domain.Models;
using SimpleBookingSystem.Services.Helpers;
using SimpleBookingSystem.Services.Services.Command.CommandInterfaces;
using SimpleBookingSystem.Services.Services.Command.CommandServices.BookingServices;
using SimpleBookingSystem.Services.Services.Query.QueryInterfaces;
using SimpleBookingSystem.Services.Services.Query.QueryServices.BookingServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// Register DbContext
builder.Services.AddDbContext<SimpleBookingSystemDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<SimpleBookingSystemDbContext>();

// Register repositories
builder.Services.AddScoped<IRepository<Resource>, ResourceRepository>();
builder.Services.AddScoped<IRepository<Booking>, BookingRepository>();
builder.Services.AddScoped<BookingRepository>();
builder.Services.AddScoped<ResourceRepository>();


// Register services
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ICreateBookingCommandService, CreateBookingCommandService>();
builder.Services.AddScoped<IGetResourcesQueryService, GetResourcesQueryService>();
builder.Services.AddScoped<CreateBookingCommandService>();
builder.Services.AddScoped<GetResourcesQueryService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
}


app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
	name: "default",
	pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
;

app.Run();
