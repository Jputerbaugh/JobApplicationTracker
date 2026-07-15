using Microsoft.EntityFrameworkCore;
using JobApplicationTracker.Data;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationTracker.Controllers;

public class ApplicationsContoller : Controller
{
    private readonly ApplicationDbContext _context;

    public ApplicationsContoller(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var applications = await _context.JobApplications.ToListAsync();

        return View(applications);
    }
    
}