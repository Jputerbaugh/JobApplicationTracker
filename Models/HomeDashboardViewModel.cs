namespace JobApplicationTracker.Models
{
    public class HomeDashboardViewModel
    {
        public int TotalApplications { get; set; }

        public int AdvancedApplications { get; set; }

        public int InterviewOrBetterApplications { get; set; }

        public int MultipleInterviewApplications { get; set; }

        public int OfferApplications { get; set; }

        public int AcceptedApplications { get; set; }


        public List<DashboardApplicationItemViewModel> UpcomingFollowUps { get; set; } = new();
        
        public List<DashboardApplicationItemViewModel> RecentApplications { get; set; } = new();

        public double AdvancementRate =>
            CalculateRate(AdvancedApplications);

        public double InterviewOrBetterRate =>
            CalculateRate(InterviewOrBetterApplications);

        public double MultipleInterviewRate =>
            CalculateRate(MultipleInterviewApplications);

        public double OfferRate =>
            CalculateRate(OfferApplications);

        public double AcceptanceRate =>
            CalculateRate(AcceptedApplications);

        private double CalculateRate(int count)
        {
            if (TotalApplications == 0)
            {
                return 0;
            }

            return (double)count / TotalApplications * 100;
        }
    }

    public class DashboardApplicationItemViewModel
    {
        public int Id { get; set; }

        public string Company { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;

        public DateTime ApplicationDate { get; set; }

        public DateTime? FollowUpDate { get; set; }
    }
}