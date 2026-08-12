namespace JobApplicationTracker.Models;
using System.ComponentModel.DataAnnotations;
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

    [Required(ErrorMessage = "Company name is required.")]
    [StringLength(100)]
    [Display(Name = "Company Name")]
    public string Company { get; set; } = string.Empty;

    [Required(ErrorMessage = "Position is required.")]
    [StringLength(100)]
    [Display(Name = "Position")]
    public string Position { get; set; } = string.Empty;

    [Required(ErrorMessage = "Location is required.")]
    [Display(Name = "Location")]
    public string? Location { get; set; }

    [Required(ErrorMessage = "Status is required.")]
    [Display(Name = "Status")]
    public ApplicationStatus Status { get; set; }
    //Interested, Applied, Interviewing, Offer, Rejected, Withdrawn

    [Required(ErrorMessage = "Application date is required.")]
    [Display(Name = "Application Date")]
    public DateTime ApplicationDate { get; set; }

    [Url(ErrorMessage = "Please enter a valid URL.")]
    [Display(Name = "Job URL")]
    public string? JobURL { get; set; }

    [Display(Name = "Follow-Up Date")]
    public DateTime? FollowUpDate { get; set; }

    public string? Notes { get; set; }

}


