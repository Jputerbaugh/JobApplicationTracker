using Microsoft.EntityFrameworkCore;
using JobApplicationTracker.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
        options.UseSqlite(
            builder.Configuration.GetConnectionString("DefaultConnection")
        )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


Console.WriteLine(
    $"Demo mode enabled: {app.Configuration.GetValue<bool>("DemoMode")}");

if (app.Configuration.GetValue<bool>("DemoMode"))
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider
        .GetRequiredService<ApplicationDbContext>();
    
    await context.Database.EnsureCreatedAsync();
    await DemoDataSeeder.SeedAsync(context);
}

app.Run();
