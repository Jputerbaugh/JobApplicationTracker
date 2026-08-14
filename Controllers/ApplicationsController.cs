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

    public async Task<IActionResult> Edit(int id)
    {
        var application = await _context.JobApplications.FindAsync(id);
        if (application == null)
        {
            return NotFound();
        }

        return View(application);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, JobApplication application)
    {
        if (id != application.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(application);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(application.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        return View(application);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var application = await _context.JobApplications.FindAsync(id);
        if (application == null)
        {
            return NotFound();
        }
        
        return View(application);
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var application = await _context.JobApplications.FindAsync(id);
        if (application == null)
        {
            return NotFound();
        }

        _context.JobApplications.Remove(application);
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(Index));

    }

    private bool ApplicationExists(int id)
    {
        return _context.JobApplications.Any(e => e.Id == id);
    }
}

