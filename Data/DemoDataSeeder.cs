using JobApplicationTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Data;

public static class DemoDataSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.JobApplications.AnyAsync())
        {
            return;
        }

        var today = DateTime.Today;

        var applications = new List<JobApplication>
        {
            new()
            {
                Company = "Aperture Laboratories",
                Position = "Junior Test Chamber Developer",
                Location = "Upper Michigan, MI",
                Stage = ApplicationStage.Applied,
                FurthestInterviewRound = InterviewRound.None,
                Outcome = ApplicationOutcome.Active,
                ApplicationDate = today.AddDays(-4),
                FollowUpDate = today.AddDays(3),
                Notes = "Submitted an application to maintain test-chamber automation and personality-core software."
            },
            new()
            {
                Company = "Black Mesa Research Facility",
                Position = "Anomalous Materials Researcher",
                Location = "Alamogordo, NM",
                Stage = ApplicationStage.Assessment,
                FurthestInterviewRound = InterviewRound.None,
                Outcome = ApplicationOutcome.Active,
                ApplicationDate = today.AddDays(-9),
                Notes = "Completed a assessment covering research monitoring and containment systems."
            },
            new()
            {
                Company = "Vault-Tec Corporation",
                Position = "Vault Security Analyst",
                Location = "Remote",
                Stage = ApplicationStage.RecruiterScreen,
                FurthestInterviewRound = InterviewRound.None,
                Outcome = ApplicationOutcome.Active,
                ApplicationDate = today.AddDays(-14),
                FollowUpDate = today.AddDays(1),
                Notes = "Completed a recruiter screen about protecting the systems used in underground vaults."
            },
            new()
            {
                Company = "Umbrella Corporation",
                Position = "Laboratory Systems Engineer",
                Location = "Raccoon City",
                Stage = ApplicationStage.Interviewing,
                FurthestInterviewRound = InterviewRound.First,
                Outcome = ApplicationOutcome.Active,
                ApplicationDate = today.AddDays(-18),
                Notes = "Preparing for a technical interview focused on laboratory monitoring and containment software."
            },
            new()
            {
                Company = "Ryan Industries",
                Position = "Underwater Systems Engineer",
                Location = "Rapture, Atlantic Ocean",
                Stage = ApplicationStage.Interviewing,
                FurthestInterviewRound = InterviewRound.Second,
                Outcome = ApplicationOutcome.Rejected,
                ApplicationDate = today.AddDays(-25),
                Notes = "Reached the second interview for a role maintaining Rapture's automated infrastructure before receiving a rejection."
            },
            new()
            {
                Company = "Militech",
                Position = "Combat Systems Backend Engineer",
                Location = "Night City, CA",
                Stage = ApplicationStage.Offer,
                FurthestInterviewRound = InterviewRound.Third,
                Outcome = ApplicationOutcome.Accepted,
                ApplicationDate = today.AddDays(-32),
                Notes = "Accepted the offer after three interviews covering backend services for combat systems."
            },
            new()
            {
                Company = "Joja Corporation",
                Position = "Supply Chain Software Developer",
                Location = "Stardew Valley",
                Stage = ApplicationStage.Offer,
                FurthestInterviewRound = InterviewRound.Second,
                Outcome = ApplicationOutcome.Declined,
                ApplicationDate = today.AddDays(-40),
                Notes = "Declined an offer to develop inventory and delivery software for JojaMart locations."
            },
            new()
            {
                Company = "Fazbear Entertainment",
                Position = "Night-Shift Systems Engineer",
                Location = "Hurricane, UT",
                Stage = ApplicationStage.Interested,
                FurthestInterviewRound = InterviewRound.None,
                Outcome = ApplicationOutcome.Active,
                ApplicationDate = today.AddDays(-2),
                Notes = "Saved for later review; responsible for monitoring and maintaining animatronic systems during night shifts."
            }
        };

        await context.JobApplications.AddRangeAsync(applications);
        await context.SaveChangesAsync();
    }
}