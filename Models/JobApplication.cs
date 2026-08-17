namespace JobApplicationTracker.Models;
using System.ComponentModel.DataAnnotations;

public enum ApplicationStage
{
    [Display(Name = "Interested")]
    Interested = 0,

    [Display(Name = "Applied")]
    Applied = 1,

    [Display(Name = "Assessment")]
    Assessment = 2,

    [Display(Name = "Recruiter Screen")]
    RecruiterScreen = 3,

    [Display(Name = "Interviewing")]
    Interviewing = 4,

    [Display(Name = "Offer")]
    Offer = 5
}

public enum InterviewRound
{
    [Display(Name = "No Interview")]
    None = 0,

    [Display(Name = "First Interview")]
    First = 1,

    [Display(Name = "Second Interview")]
    Second = 2,

    [Display(Name = "Third Interview")]
    Third = 3,

    [Display(Name = "Fourth Interview")]
    Fourth = 4,

    [Display(Name = "Fifth Interview or Later")]
    FifthOrLater = 5
}

public enum ApplicationOutcome
{
    [Display(Name = "Active")]
    Active = 0,

    [Display(Name = "No Response")]
    NoResponse = 1,

    [Display(Name = "Rejected")]
    Rejected = 2,

    [Display(Name = "Withdrawn")]
    Withdrawn = 3,

    [Display(Name = "Accepted")]
    Accepted = 4,

    [Display(Name = "Declined")]
    Declined = 5
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

    [Display(Name = "Furthest Stage Reached")]
    public ApplicationStage Stage { get; set; } = ApplicationStage.Applied;

    [Display(Name = "Interview Round Reached")]
    public InterviewRound FurthestInterviewRound { get; set; }
        = InterviewRound.None;

    [Display(Name = "Outcome")]
    public ApplicationOutcome Outcome { get; set; }
        = ApplicationOutcome.Active;

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


