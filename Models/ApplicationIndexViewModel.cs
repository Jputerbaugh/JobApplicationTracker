namespace JobApplicationTracker.Models
{
    public class ApplicationIndexViewModel
    {
        public List<JobApplication> Applications { get; set; } = new();

        public string SearchTerm { get; set; } = string.Empty;

        public ApplicationStage? SelectedStage { get; set; }

        public ApplicationOutcome? SelectedOutcome { get; set; }

        public string SortOrder { get; set; } = "newest";
    }
}