using Microsoft.EntityFrameworkCore;
using VideoVerhuur.Repositories;
using VideoVerhuurLibrary.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IKlantRepository,
 SQLKlantRepository>();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<VideoVerhuurContext>(options =>
 options.UseSqlServer(
 builder.Configuration.GetConnectionString("VideoVerhuurConnection"),
 x => x.MigrationsAssembly("VideoVerhuurLibrary"))); //(1)
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
