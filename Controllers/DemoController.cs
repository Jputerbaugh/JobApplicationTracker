using JobApplicationTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Controllers;

public class DemoController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public DemoController(
        ApplicationDbContext context,
        IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Reset()
    {
        if (!_configuration.GetValue<bool>("DemoMode"))
        {
            return NotFound();
        }

        await _context.JobApplications.ExecuteDeleteAsync();
        await DemoDataSeeder.SeedAsync(_context);

        TempData["SuccessMessage"] =
            "The demonstration data has been reset.";

        return RedirectToAction("Index", "Home");
    }
}