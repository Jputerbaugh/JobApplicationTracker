using Microsoft.EntityFrameworkCore;
using JobApplicationTracker.Data;
using Microsoft.Data.Sqlite;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

var demoMode = builder.Configuration.GetValue<bool>("DemoMode");

var desktopMode = !demoMode && OperatingSystem.IsWindows();
const string desktopUrl = "http://127.0.0.1:5050";

// Calculate the location of the SQLite database file based on the operating system and whether demo mode is enabled.
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "The DefaultConnection connection string is missing.");

if (desktopMode)
{
    var applicationDataDirectory = Path.Combine(
        Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData),
        "JobApplicationTracker");

    Directory.CreateDirectory(applicationDataDirectory);

    var databasePath = Path.Combine(
        applicationDataDirectory,
        "jobapplications.db");

    connectionString = new SqliteConnectionStringBuilder
    {
        DataSource = databasePath
    }.ToString();

    builder.WebHost.UseUrls(desktopUrl);
}

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlite(connectionString)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    if (!desktopMode)
    {
        app.UseHsts();
    }
}

if (!desktopMode)
{
    app.UseHttpsRedirection();
}

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


Console.WriteLine($"Demo mode enabled: {demoMode}");

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider
        .GetRequiredService<ApplicationDbContext>();

    await context.Database.EnsureCreatedAsync();

    if (demoMode)
    {
        await DemoDataSeeder.SeedAsync(context);
    }
}

if (desktopMode)
{
    app.Lifetime.ApplicationStarted.Register(() =>
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = desktopUrl,
            UseShellExecute = true
        });
    });
}

app.Run();
