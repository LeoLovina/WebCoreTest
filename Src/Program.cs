using Microsoft.EntityFrameworkCore;
using System.Reflection;
using FluentMigrator.Runner;
using WebCoreTest.Extensions;
using WebCoreTest.Interfaces;
using WebCoreTest.Models;
using WebCoreTest.Services;
using WebCoreTest.Setting;


var builder = WebApplication.CreateBuilder(args);

var appSettings = new AppSettings();
builder.Configuration.Bind(appSettings);

// Add services to the container.
builder.Services.AddControllersWithViews();

// get connection string from appsettings.json
var connection = builder.Configuration.GetConnectionString(appSettings.UseDatabase);

builder.Services.AddDbContext<ToDoContext>(options =>
    //options.UseInMemoryDatabase("db")
    options.UseSqlServer(connection)
    );

builder.Services.AddScoped<IMigratorService, MigratorService>();

//string migrationAssemblyPath = Path.Combine(appSettings.ExecutingAssembly.Location.LeftOfRightmostOf("\\"), appSettings.MigrationAssembly);
//Assembly migrationAssembly = Assembly.LoadFrom(migrationAssemblyPath);

var migrationAssembly = appSettings.ExecutingAssembly;
builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(rb => rb
        .AddSqlServer()
        .WithGlobalConnectionString(connection)
        .ScanIn(migrationAssembly).For.Migrations())
    .AddLogging(lb => lb.AddFluentMigratorConsole());

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
