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

    public async Task<IActionResult> Index(
    string? searchTerm,
    ApplicationStage? selectedStage,
    ApplicationOutcome? selectedOutcome,
    string sortOrder = "newest")
{
    var query = _context.JobApplications
        .AsNoTracking()
        .AsQueryable();

    if (!string.IsNullOrWhiteSpace(searchTerm))
    {
        searchTerm = searchTerm.Trim();

        query = query.Where(application =>
            application.Company.Contains(searchTerm) ||
            application.Position.Contains(searchTerm));
    }

    if (selectedStage.HasValue)
    {
        query = query.Where(application =>
            application.Stage == selectedStage.Value);
    }

    if (selectedOutcome.HasValue)
    {
        query = query.Where(application =>
            application.Outcome == selectedOutcome.Value);
    }

    query = sortOrder switch
    {
        "oldest" => query
            .OrderBy(application => application.ApplicationDate),

        "company-asc" => query
            .OrderBy(application => application.Company)
            .ThenBy(application => application.Position),

        "company-desc" => query
            .OrderByDescending(application => application.Company)
            .ThenBy(application => application.Position),

        _ => query
            .OrderByDescending(application => application.ApplicationDate)
    };

    var model = new ApplicationIndexViewModel
    {
        Applications = await query.ToListAsync(),
        SearchTerm = searchTerm ?? string.Empty,
        SelectedStage = selectedStage,
        SelectedOutcome = selectedOutcome,
        SortOrder = sortOrder
    };

    return View(model);
}
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(JobApplication application)
    {
        if (ModelState.IsValid)
        {
            _context.JobApplications.Add(application);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] =
                "Application added successfully.";

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
            TempData["SuccessMessage"] =
                "Application updated successfully.";
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
        TempData["SuccessMessage"] =
            "Application deleted successfully.";
        return RedirectToAction(nameof(Index));

    }

    private bool ApplicationExists(int id)
    {
        return _context.JobApplications.Any(e => e.Id == id);
    }
}

