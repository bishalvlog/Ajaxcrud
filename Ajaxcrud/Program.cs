using Ajaxcrud.Data;
using Ajaxcrud.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

var configurations = builder.Configuration;

var connectionString = configurations.GetConnectionString("Default");

services.AddControllersWithViews();

services.AddDbContext<Applicationdb>(options =>
    options.UseSqlServer(connectionString));

services.AddTransient<IRepository,Repository>();
    
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
