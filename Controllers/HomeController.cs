using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JobApplicationTracker.Models;
using JobApplicationTracker.Data;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Controllers;

public class HomeController(ILogger<HomeController> logger, ApplicationDbContext context) : Controller
{

    private readonly ILogger<HomeController> _logger = logger;
    private readonly ApplicationDbContext _context = context;

    public async Task<IActionResult> Index()
{
    var applications = await _context
        .Set<JobApplication>()
        .AsNoTracking()
        .ToListAsync();

    var model = new HomeDashboardViewModel
    {
        TotalApplications = applications.Count,

        AdvancedApplications = applications.Count(application =>
            application.Stage >= ApplicationStage.Assessment),

        InterviewOrBetterApplications = applications.Count(application =>
            application.Stage >= ApplicationStage.Interviewing),

        MultipleInterviewApplications = applications.Count(application =>
            application.FurthestInterviewRound >= InterviewRound.Second),

        OfferApplications = applications.Count(application =>
            application.Stage == ApplicationStage.Offer),

        AcceptedApplications = applications.Count(application =>
            application.Outcome == ApplicationOutcome.Accepted)
    };

    return View(model);
}

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
