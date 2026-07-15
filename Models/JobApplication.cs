namespace JobApplicationTracker.Models;

public enum ApplicationStatus
{
    Interested, 
    Applied,
    Interviewing,
    Offer, 
    Rejected, 
    Withdrawn
}

public class JobApplication
{
    public int Id { get; set; }

    public string Company { get; set; } = string.Empty;

    public string Position { get; set; } = string.Empty;

    public string? Location { get; set; }

    public ApplicationStatus Status { get; set; }
    //Interested, Applied, Interviewing, Offer, Rejected, Withdrawn

    public DateTime ApplicationDate { get; set; }

    public string? JobURL { get; set; }

    public DateTime? FollowUp { get; set; }

    public string? Notes { get; set; }

}


