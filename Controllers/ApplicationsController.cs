using Microsoft.EntityFrameworkCore;
using JobApplicationTracker.Data;
using Microsoft.AspNetCore.Mvc;
using JobApplicationTracker.Models;

namespace JobApplicationTracker.Controllers;

public class ApplicationsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ApplicationsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var applications = await _context.JobApplications.ToListAsync();

        return View(applications);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(JobApplication application)
    {
        if (ModelState.IsValid)
        {
            _context.JobApplications.Add(application);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(application);
    }
    
}

