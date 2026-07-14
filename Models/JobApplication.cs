namespace JobApplicationTracker.Models;

public class JobApplication
{
    public int Id { get; set; }

    public string? Company { get; set; }

    public string? Position { get; set; }

    public string? Location { get; set; }

    public enum Status {Interested, Applied, Interviewing, Offer, Rejected, Withdrawn}

    

}
